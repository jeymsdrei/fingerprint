using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using libzkfpcsharp;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Text;
using System.Diagnostics;
using Sample;
using Demo.Controls;
using Demo.UI;
using Demo.Data;
using Demo.Integration;

namespace Demo
{
    public partial class Form1 : Form
    {
        IntPtr mDevHandle = IntPtr.Zero;
        IntPtr mDBHandle = IntPtr.Zero;
        IntPtr FormHandle = IntPtr.Zero;
        bool bIsTimeToDie = false;
        bool IsRegister = false;
        bool bIdentify = true;
        byte[] FPBuffer;
        int RegisterCount = 0;
        const int REGISTER_FINGER_COUNT = 3;

        byte[][] RegTmps = new byte[3][];
        byte[] RegTmp = new byte[2048];
        byte[] CapTmp = new byte[2048];
        int cbCapTmp = 2048;
        int cbRegTmp = 0;
        int iFid = 1;
        Thread captureThread = null;

        private int mfpWidth = 0;
        private int mfpHeight = 0;

        const int MESSAGE_CAPTURED_OK = 0x0400 + 6;

        private Image _lastFpImage = null;
        private ToastNotification _toast;
        private bool _initializing = false;
        private DatabaseHelper _db;
        private bool _hasRegisteredFingerprints = false;
        private string _pendingAction = "Time In";
        private bool _fpLoaded = false;
        private System.Windows.Forms.Timer timerReconnect;
        private ListBox lstEmployees;
        private List<Employee> _enrollChoices = new List<Employee>();
        private Employee _enrollTarget;
        private List<AttendanceRecord> _historyRows = new List<AttendanceRecord>();
        private Label _lblHistoryCount;
        private Label _lblHistoryEmpty;

        private int _enrollFid = 0;

        private HrisConfig _hrisConfig;
        private HrisApiClient _hrisApi;
        private PendingPushQueue _pendingQueue;
        private string _agentId;
        private System.Windows.Forms.Timer timerHrisHeartbeat;
        private int _hrisSyncInProgress = 0;

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        public Form1()
        {
            InitializeComponent();
            _db = new DatabaseHelper();
            _db.LoadAll();
            InitializeHrisIntegration();
            _toast = new ToastNotification(this);
            timerReconnect = new System.Windows.Forms.Timer();
            timerReconnect.Interval = 3000;
            timerReconnect.Tick += timerReconnect_Tick;

            InitializeNavigation();
            InitializeClock();
            InitializeAnimations();
            InitializeScannerUI();
            InitializeRegisterPage();
            InitializeHistoryPage();
            try { cmbTheme.SelectedIndex = 0; }
            catch { }
            cmbTheme.SelectedIndexChanged += cmbTheme_SelectedIndexChanged;
        }

        private void bnInit_Click(object sender, EventArgs e)
        {
            cmbIdx.Items.Clear();
            int ret = zkfperrdef.ZKFP_ERR_OK;
            if ((ret = zkfp2.Init()) == zkfperrdef.ZKFP_ERR_OK)
            {
                int nCount = zkfp2.GetDeviceCount();
                if (nCount > 0)
                {
                    for (int i = 0; i < nCount; i++)
                    {
                        cmbIdx.Items.Add(i.ToString());
                    }
                    cmbIdx.SelectedIndex = 0;
                    bnInit.Enabled = false;
                    bnFree.Enabled = true;
                    bnOpen.Enabled = true;
                }
                else
                {
                    zkfp2.Terminate();
                    FingerprintLogger.Error("bnInit_Click | No device connected");
                    MessageBox.Show("No device connected!");
                }
            }
            else
            {
                FingerprintLogger.SdkError("bnInit_Click | Init", ret);
                MessageBox.Show("Initialize fail, ret=" + ret + " !");
            }
        }

        private void bnFree_Click(object sender, EventArgs e)
        {
            FingerprintLogger.Info("bnFree_Click | SDK terminated");
            zkfp2.Terminate();
            cbRegTmp = 0;
            bnInit.Enabled = true;
            bnFree.Enabled = false;
            bnOpen.Enabled = false;
            bnClose.Enabled = false;
            bnEnroll.Enabled = false;
            bnVerify.Enabled = false;
            bnIdentify.Enabled = false;
        }

        private void bnOpen_Click(object sender, EventArgs e)
        {
            int ret = zkfp.ZKFP_ERR_OK;
            if (IntPtr.Zero == (mDevHandle = zkfp2.OpenDevice(cmbIdx.SelectedIndex)))
            {
                FingerprintLogger.SdkError("bnOpen_Click | OpenDevice", mDevHandle, "index=" + cmbIdx.SelectedIndex);
                MessageBox.Show("OpenDevice fail");
                return;
            }
            if (IntPtr.Zero == (mDBHandle = zkfp2.DBInit()))
            {
                FingerprintLogger.Error("bnOpen_Click | DBInit returned null handle");
                MessageBox.Show("Init DB fail");
                zkfp2.CloseDevice(mDevHandle);
                mDevHandle = IntPtr.Zero;
                return;
            }
            bnInit.Enabled = false;
            bnFree.Enabled = true;
            bnOpen.Enabled = false;
            bnClose.Enabled = true;
            bnEnroll.Enabled = true;
            bnVerify.Enabled = true;
            bnIdentify.Enabled = true;
            RegisterCount = 0;
            cbRegTmp = 0;
            iFid = 1;
            for (int i = 0; i < 3; i++)
            {
                RegTmps[i] = new byte[2048];
            }
            byte[] paramValue = new byte[4];
            int size = 4;
            zkfp2.GetParameters(mDevHandle, 1, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

            size = 4;
            zkfp2.GetParameters(mDevHandle, 2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

            FPBuffer = new byte[mfpWidth * mfpHeight];

            captureThread = new Thread(new ThreadStart(DoCapture));
            captureThread.IsBackground = true;
            captureThread.Start();
            bIsTimeToDie = false;
            textRes.Text = "Open succ";
        }

        private void DoCapture()
        {
            while (!bIsTimeToDie)
            {
                cbCapTmp = 2048;
                int ret = zkfp2.AcquireFingerprint(mDevHandle, FPBuffer, CapTmp, ref cbCapTmp);
                if (ret == zkfp.ZKFP_ERR_OK)
                {
                    SendMessage(FormHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                }
                Thread.Sleep(200);
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MESSAGE_CAPTURED_OK:
                    {
                        MemoryStream ms = new MemoryStream();
                        BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
                        Bitmap bmp = new Bitmap(ms);
                        this.picFPImg.Image = bmp;
                        _lastFpImage = bmp;
                        if (IsRegister)
                        {
                            int ret = zkfp.ZKFP_ERR_OK;
                            int fid = 0, score = 0;
                            ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);
                            if (zkfp.ZKFP_ERR_OK == ret)
                            {
                                textRes.Text = "This finger was already register by " + fid + "!";
                                return;
                            }
                            if (RegisterCount > 0 && zkfp2.DBMatch(mDBHandle, CapTmp, RegTmps[RegisterCount - 1]) <= 0)
                            {
                                FingerprintLogger.Warning("DefWndProc | DBMatch mismatch during enrollment");
                                textRes.Text = "Please press the same finger 3 times for the enrollment";
                                return;
                            }
                            Array.Copy(CapTmp, RegTmps[RegisterCount], cbCapTmp);
                            String strBase64 = zkfp2.BlobToBase64(CapTmp, cbCapTmp);
                            byte[] blob = zkfp2.Base64ToBlob(strBase64);
                            RegisterCount++;
                            textRes.Text = "RegisterCount=" + RegisterCount + " cbCapTmp=" + cbCapTmp + " cbRegTmp=" + cbRegTmp;
                            if (RegisterCount >= REGISTER_FINGER_COUNT)
                            {
                                RegisterCount = 0;
                                int mergeRet = zkfp2.DBMerge(mDBHandle, RegTmps[0], RegTmps[1], RegTmps[2], RegTmp, ref cbRegTmp);
                                textRes.Text = "DBMerge ret=" + mergeRet + " cbRegTmp=" + cbRegTmp;
                                if (zkfp.ZKFP_ERR_OK == mergeRet)
                                {
                                    int deviceFid = _enrollFid > 0 ? _enrollFid : iFid;
                                    int addRet = zkfp2.DBAdd(mDBHandle, deviceFid, RegTmp);
                                    textRes.Text = "DBAdd ret=" + addRet + " fid=" + deviceFid;
                                    if (zkfp.ZKFP_ERR_OK == addRet)
                                    {
                                        int savedFid = deviceFid;
                                        iFid++;
                                        textRes.Text = "enroll succ fid=" + savedFid;
                                        SaveFingerprintToDB(savedFid);
                                        ResetRegistrationForm();
                                    }
                                    else
                                    {
                                        FingerprintLogger.SdkError("DefWndProc | DBAdd", addRet);
                                        textRes.Text = "enroll fail, DBAdd error=" + addRet;
                                    }
                                }
                                else
                                {
                                    FingerprintLogger.SdkError("DefWndProc | DBMerge", mergeRet);
                                    textRes.Text = "enroll fail, DBMerge error=" + mergeRet;
                                }
                                IsRegister = false;
                                return;
                            }
                            else
                            {
                                textRes.Text = "You need to press the " + (REGISTER_FINGER_COUNT - RegisterCount) + " times fingerprint";
                            }
                        }
                        else
                        {
                            if (!_hasRegisteredFingerprints)
                            {
                                textRes.Text = "Please register your finger first!";
                                return;
                            }
                            if (bIdentify)
                            {
                                int ret = zkfp.ZKFP_ERR_OK;
                                int fid = 0, score = 0;
                                ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);
                                if (zkfp.ZKFP_ERR_OK == ret)
                                {
                                    textRes.Text = "Identify succ, fid= " + fid + ",score=" + score + "!";
                                    ProcessAttendance(fid);
                                    return;
                                }
                                else
                                {
                                    FingerprintLogger.SdkError("DefWndProc | DBIdentify", ret);
                                    textRes.Text = "Identify fail, ret= " + ret;
                                    return;
                                }
                            }
                            else
                            {
                                int ret = zkfp2.DBMatch(mDBHandle, CapTmp, RegTmp);
                                if (0 < ret)
                                {
                                    textRes.Text = "Match finger succ, score=" + ret + "!";
                                    return;
                                }
                                else
                                {
                                    FingerprintLogger.SdkError("DefWndProc | DBMatch", ret);
                                    textRes.Text = "Match finger fail, ret= " + ret;
                                    return;
                                }
                            }
                        }
                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormHandle = this.Handle;
            picFPImg.Parent = fpScanner;
            picFPImg.Location = new Point(60, 60);
            picFPImg.Size = new Size(200, 240);
            picFPImg.Visible = true;
            BeginInvoke(new MethodInvoker(() =>
            {
                TryAutoInitialize();
                if (mDevHandle == IntPtr.Zero)
                {
                    FingerprintLogger.Info("Form1_Load | Initial connect failed, starting retry timer");
                    timerReconnect.Start();
                }
            }));
        }

        private void InitializeHrisIntegration()
        {
            try
            {
                _hrisConfig = HrisConfig.Load();
                _agentId = HrisAgentIdentity.LoadOrCreate();
                _hrisApi = new HrisApiClient(_hrisConfig.ApiBaseUrl, _hrisConfig.ApiToken);
                _pendingQueue = new PendingPushQueue();
                _pendingQueue.Load();

                timerHrisHeartbeat = new System.Windows.Forms.Timer();
                timerHrisHeartbeat.Interval = Math.Max(10, _hrisConfig.HeartbeatIntervalSeconds) * 1000;
                timerHrisHeartbeat.Tick += timerHrisHeartbeat_Tick;
                timerHrisHeartbeat.Start();

                string status = _hrisApi.IsConfigured ? "HRIS: configured (" + _hrisConfig.ApiBaseUrl + ")" : "HRIS: not configured";
                FingerprintLogger.Info("InitializeHrisIntegration | " + status + " | agent=" + _agentId);

                // Register the agent and flush the offline queue off the UI thread.
                System.Threading.ThreadPool.QueueUserWorkItem(delegate { RegisterAgentAndFlush(); });
            }
            catch (Exception ex)
            {
                FingerprintLogger.Error("InitializeHrisIntegration", ex);
            }
        }

        private void RegisterAgentAndFlush()
        {
            try
            {
                if (_hrisApi == null || !_hrisApi.IsConfigured) return;

                string error;
                bool ok = _hrisApi.RegisterAgent(_agentId, "BioClock USB Agent", HrisAgentIdentity.ComputerName, _hrisConfig.ApiBaseUrl, out error);
                if (ok)
                {
                    FingerprintLogger.Info("RegisterAgentAndFlush | agent registered");
                    FlushPendingQueue();
                }
                else
                {
                    FingerprintLogger.Warning("RegisterAgentAndFlush | register failed: " + error);
                }
            }
            catch (Exception ex)
            {
                FingerprintLogger.Error("RegisterAgentAndFlush", ex);
            }
        }

        private void timerHrisHeartbeat_Tick(object sender, EventArgs e)
        {
            if (_hrisApi == null || !_hrisApi.IsConfigured) return;
            // Never stack background syncs if one is still running.
            if (Interlocked.Exchange(ref _hrisSyncInProgress, 1) == 1) return;
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    HeartbeatSync();
                }
                finally
                {
                    Interlocked.Exchange(ref _hrisSyncInProgress, 0);
                }
            });
        }

        private void HeartbeatSync()
        {
            if (_hrisApi == null || !_hrisApi.IsConfigured) return;
            try
            {
                string error;
                bool ok = _hrisApi.Heartbeat(_agentId, out error);
                if (!ok)
                {
                    // Server may have restarted and forgotten the agent — re-register.
                    _hrisApi.RegisterAgent(_agentId, "BioClock USB Agent", HrisAgentIdentity.ComputerName, _hrisConfig.ApiBaseUrl, out error);
                }

                // Every ping is a live sync: pull newly-added/-registered employees
                // into the enrollment list and deliver any punches stored offline.
                RefreshEmployeesFromHris();
                FlushPendingQueue();
            }
            catch (Exception ex)
            {
                FingerprintLogger.Error("timerHrisHeartbeat_Tick", ex);
            }
        }

        private void PushPunchToHris(AttendanceRecord record, int fingerprintId)
        {
            try
            {
                if (_hrisApi == null || !_hrisApi.IsConfigured) return;

                int attendanceId = record.AttendanceID;
                string sourceKey = "att-" + attendanceId;
                if (string.IsNullOrEmpty(record.Action)) return;

                _toast.Show("Attendance recorded locally", ToastNotification.ToastType.Success);

                var batch = new List<HrisPushRecord>();
                batch.Add(new HrisPushRecord
                {
                    fingerprint_id = fingerprintId,
                    punch_time = record.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    source_key = sourceKey,
                    action = NormalizeAction(record.Action),
                });

                HrisResponse resp = _hrisApi.Push(_agentId, batch);
                if (resp.Ok)
                {
                    FingerprintLogger.Info("PushPunchToHris | pushed " + sourceKey + " imported=" + resp.Imported);
                }
                else
                {
                    // Offline / server unreachable — persist to the queue.
                    _pendingQueue.Enqueue(new PendingPush
                    {
                        FingerprintID = fingerprintId,
                        PunchTime = record.DateTime,
                        SourceKey = sourceKey,
                        Action = record.Action,
                        Attempts = 0,
                        AddedAt = DateTime.Now,
                    });
                    FingerprintLogger.Warning("PushPunchToHris | queued " + sourceKey + " (" + resp.Error + ")");
                }
            }
            catch (Exception ex)
            {
                FingerprintLogger.Error("PushPunchToHris", ex);
            }
        }

        private void FlushPendingQueue()
        {
            try
            {
                if (_hrisApi == null || !_hrisApi.IsConfigured || _pendingQueue.Count == 0) return;

                var batch = new List<HrisPushRecord>();
                List<PendingPush> snapshot = _pendingQueue.Snapshot();
                foreach (PendingPush p in snapshot)
                {
                    batch.Add(new HrisPushRecord
                    {
                        fingerprint_id = p.FingerprintID,
                        punch_time = p.PunchTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        source_key = p.SourceKey,
                        action = NormalizeAction(p.Action),
                    });
                }

                HrisResponse resp = _hrisApi.Push(_agentId, batch);
                if (resp.Ok)
                {
                    var confirmed = new HashSet<string>();
                    foreach (PendingPush p in snapshot) confirmed.Add(p.SourceKey);
                    _pendingQueue.RemoveConfirmed(confirmed);
                    FingerprintLogger.Info("FlushPendingQueue | flushed " + confirmed.Count + " pending punch(es)");
                }
                else
                {
                    // Retry later; give up after RetryAttempts so the queue
                    // cannot grow forever on a permanently wrong config.
                    var failed = new HashSet<string>();
                    foreach (PendingPush p in snapshot) failed.Add(p.SourceKey);
                    _pendingQueue.IncrementAttempts(failed);

                    // Drop records that passed RetryAttempts after incrementing.
                    var toDrop = new HashSet<string>();
                    foreach (PendingPush p in _pendingQueue.Snapshot())
                    {
                        if (p.Attempts >= _hrisConfig.RetryAttempts) toDrop.Add(p.SourceKey);
                    }
                    if (toDrop.Count > 0)
                    {
                        _pendingQueue.RemoveConfirmed(toDrop);
                        FingerprintLogger.Warning("FlushPendingQueue | dropped " + toDrop.Count + " punch(es) after " + _hrisConfig.RetryAttempts + " failed attempts");
                    }
                    FingerprintLogger.Warning("FlushPendingQueue | push failed (" + resp.Error + "), " + snapshot.Count + " queued");
                }
            }
            catch (Exception ex)
            {
                FingerprintLogger.Error("FlushPendingQueue", ex);
            }
        }

        private static string NormalizeAction(string action)
        {
            if (string.IsNullOrEmpty(action)) return null;
            string a = action.Trim();
            if (a.Equals("Time In", StringComparison.OrdinalIgnoreCase)) return "time_in";
            if (a.Equals("Time Out", StringComparison.OrdinalIgnoreCase)) return "time_out";
            return null;
        }

        private void CloseDevice()
        {
            bIsTimeToDie = true;
            if (captureThread != null && captureThread.IsAlive)
                captureThread.Join(1000);
            captureThread = null;
            if (IntPtr.Zero != mDevHandle)
            {
                zkfp2.CloseDevice(mDevHandle);
                mDevHandle = IntPtr.Zero;
            }
            mDBHandle = IntPtr.Zero;
            bIsTimeToDie = false;
            FingerprintLogger.Info("CloseDevice | Device closed");
        }

        private void bnClose_Click(object sender, EventArgs e)
        {
            CloseDevice();
            RegisterCount = 0;
            Thread.Sleep(1000);
            bnInit.Enabled = false;
            bnFree.Enabled = true;
            bnOpen.Enabled = true;
            bnClose.Enabled = false;
            bnEnroll.Enabled = false;
            bnVerify.Enabled = false;
            bnIdentify.Enabled = false;
        }

        private void bnEnroll_Click(object sender, EventArgs e)
        {
            if (!IsRegister)
            {
                IsRegister = true;
                RegisterCount = 0;
                cbRegTmp = 0;
                textRes.Text = "Please press your finger 3 times!";
            }
        }

        private void bnIdentify_Click(object sender, EventArgs e)
        {
            if (!bIdentify)
            {
                bIdentify = true;
                textRes.Text = "Please press your finger!";
            }
        }

        private void bnVerify_Click(object sender, EventArgs e)
        {
            if (bIdentify)
            {
                bIdentify = false;
                textRes.Text = "Please press your finger!";
            }
        }

        private void InitializeNavigation()
        {
            btnNavDashboard.Click += (s, e) => ShowPage(4);
            btnNavAttendance.Click += (s, e) => ShowPage(0);
            btnNavRegister.Click += (s, e) => ShowPage(1);
            btnNavHistory.Click += (s, e) => ShowPage(5);
            btnNavDevice.Click += (s, e) => ShowPage(2);
            btnNavSettings.Click += (s, e) => ShowPage(3);
            ShowPage(4);
        }

        private void InitializeClock()
        {
            timerClock.Start();
            lblTopClock.Text = DateTime.Now.ToString("HH:mm:ss");
            lblTopDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
        }

        private void InitializeAnimations()
        {
            timerAnimation.Start();
        }

        private void InitializeScannerUI()
        {
            fpScanner.ScannerState = ScannerState.Idle;
            lblScannerStatus.Text = "Place your finger on the scanner";
            lblScannerStatus.ForeColor = Color.FromArgb(148, 163, 184);
            UpdateDeviceStatus("Disconnected", ThemeManager.Error);
        }

        private void TryAutoInitialize()
        {
            if (_initializing) return;
            _initializing = true;

            try
            {
                if (mDevHandle != IntPtr.Zero || mDBHandle != IntPtr.Zero)
                {
                    bIsTimeToDie = true;
                    if (captureThread != null && captureThread.IsAlive)
                        captureThread.Join(1000);
                    captureThread = null;
                    if (mDevHandle != IntPtr.Zero)
                    {
                        zkfp2.CloseDevice(mDevHandle);
                        mDevHandle = IntPtr.Zero;
                    }
                    mDBHandle = IntPtr.Zero;
                    bIsTimeToDie = false;
                    RegisterCount = 0;
                    cbRegTmp = 0;
                    _hasRegisteredFingerprints = false;
                    _fpLoaded = false;
                }

                int ret = zkfp2.Init();
                if (ret != zkfperrdef.ZKFP_ERR_OK && ret != zkfperrdef.ZKFP_ERR_ALREADY_INIT)
                {
                    FingerprintLogger.SdkError("TryAutoInitialize | Init", ret);
                    UpdateDeviceStatus("Disconnected", ThemeManager.Error);
                    UpdateStatusBar();
                    _initializing = false;
                    return;
                }

                lblSdkStatus.Text = "SDK: Ready";
                int nCount = 0;
                for (int attempt = 1; attempt <= 5; attempt++)
                {
                    nCount = zkfp2.GetDeviceCount();
                    if (nCount > 0) break;
                    FingerprintLogger.Warning("TryAutoInitialize | Device scan attempt " + attempt + "/5 returned 0");
                    Thread.Sleep(500);
                }

                if (nCount <= 0)
                {
                    FingerprintLogger.Warning("TryAutoInitialize | No device found after 5 attempts");
                    UpdateDeviceStatus("Disconnected", ThemeManager.Error);
                    UpdateStatusBar();
                    _initializing = false;
                    return;
                }

                cmbIdx.Items.Clear();
                for (int i = 0; i < nCount; i++)
                    cmbIdx.Items.Add(i.ToString());
                cmbIdx.SelectedIndex = 0;

                mDevHandle = zkfp2.OpenDevice(0);
                if (mDevHandle == IntPtr.Zero)
                {
                    FingerprintLogger.SdkError("TryAutoInitialize | OpenDevice", mDevHandle, "index=0");
                    UpdateDeviceStatus("Disconnected", ThemeManager.Error);
                    UpdateStatusBar();
                    _initializing = false;
                    return;
                }

                mDBHandle = zkfp2.DBInit();
                if (mDBHandle == IntPtr.Zero)
                {
                    FingerprintLogger.Error("TryAutoInitialize | DBInit returned null handle");
                    zkfp2.CloseDevice(mDevHandle);
                    mDevHandle = IntPtr.Zero;
                    UpdateDeviceStatus("Disconnected", ThemeManager.Error);
                    UpdateStatusBar();
                    _initializing = false;
                    return;
                }

                RegisterCount = 0; cbRegTmp = 0; iFid = 1;
                for (int i = 0; i < 3; i++)
                    RegTmps[i] = new byte[2048];

                byte[] paramValue = new byte[4]; int size = 4;
                zkfp2.GetParameters(mDevHandle, 1, paramValue, ref size);
                zkfp2.ByteArray2Int(paramValue, ref mfpWidth);
                size = 4;
                zkfp2.GetParameters(mDevHandle, 2, paramValue, ref size);
                zkfp2.ByteArray2Int(paramValue, ref mfpHeight);
                FPBuffer = new byte[mfpWidth * mfpHeight];

                captureThread = new Thread(new ThreadStart(DoCapture));
                captureThread.IsBackground = true;
                captureThread.Start();
                bIsTimeToDie = false;
                textRes.Text = "Open succ";

                LoadFingerprintsFromDB();
                UpdateDeviceStatus("Connected", ThemeManager.Success);
                UpdateStatusBar();
                _toast.Show("Device connected", ToastNotification.ToastType.Success);
                FingerprintLogger.Info("TryAutoInitialize | Device connected successfully");
            }
            catch (Exception ex)
            {
                FingerprintLogger.Error("TryAutoInitialize | Exception", ex);
                UpdateDeviceStatus("Disconnected", ThemeManager.Error);
                UpdateStatusBar();
            }
            _initializing = false;
        }

        private void UpdateStatusBar()
        {
            if (mDevHandle != IntPtr.Zero)
            {
                lblSdkStatus.Text = "SDK: Ready";
                lblDbStatus.Text = "Database: Initialized";
                lblConnectionStatus.Text = "Device: Connected";
                lblConnectionStatus.ForeColor = ThemeManager.Success;
            }
            else
            {
                lblSdkStatus.Text = "SDK: Ready";
                lblDbStatus.Text = "Database: Not initialized";
                lblConnectionStatus.Text = "Device: Disconnected";
                lblConnectionStatus.ForeColor = ThemeManager.Error;
            }
        }

        private void UpdateDeviceStatus(string status, Color color)
        {
            lblTopConnStatus.Text = status;
            lblTopConnStatus.ForeColor = color;
            lblTopConnDot.BackColor = color;
        }

        private void ShowPage(int index)
        {
            UpdateStats();
            pnlDashboard.Visible = (index == 4);
            pnlAttendance.Visible = (index == 0);
            pnlRegister.Visible = (index == 1);
            pnlHistory.Visible = (index == 5);
            pnlDevice.Visible = (index == 2);
            pnlSettings.Visible = (index == 3);

            if (index == 4) pnlDashboard.BringToFront();
            else if (index == 0) pnlAttendance.BringToFront();
            else if (index == 1) pnlRegister.BringToFront();
            else if (index == 5) pnlHistory.BringToFront();
            else if (index == 2) pnlDevice.BringToFront();
            else if (index == 3) pnlSettings.BringToFront();

            btnNavDashboard.IsActive = (index == 4);
            btnNavAttendance.IsActive = (index == 0);
            btnNavRegister.IsActive = (index == 1);
            btnNavHistory.IsActive = (index == 5);
            btnNavDevice.IsActive = (index == 2);
            btnNavSettings.IsActive = (index == 3);

            if (index == 1)
            {
                LoadEmployeeChoices();
                RefreshEmployeesFromHris();
            }
            if (index == 2) UpdateDeviceInfo();
            if (index == 5) RefreshHistory();
        }

        private void UpdateDeviceInfo()
        {
            lblDevSdkVer.Text = "ZKFinger 5.3.0.33";
            lblDevReaderModel.Text = mDevHandle != IntPtr.Zero ? "ZKTeco USB" : "Not connected";
            lblDevUsb.Text = mDevHandle != IntPtr.Zero ? "Active (USB)" : "Disconnected";
            lblDevDbStatus.Text = mDBHandle != IntPtr.Zero ? "Initialized" : "Not initialized";
            lblDevRegUsers.Text = _db.Employees.Count.ToString();
            lblDevRegFp.Text = _db.FingerprintCount.ToString();
            lblDevConnectionStatus.Text = mDevHandle != IntPtr.Zero ? "Connected" : "Disconnected";
            lblDevConnectionStatus.ForeColor = mDevHandle != IntPtr.Zero ? ThemeManager.Success : ThemeManager.Error;
            lblDevStatusText.Text = mDevHandle != IntPtr.Zero ? "Online" : "Offline";
            lblDevStatusText.ForeColor = mDevHandle != IntPtr.Zero ? ThemeManager.Primary : ThemeManager.Error;
            lblDevHealthValue.Text = mDevHandle != IntPtr.Zero ? "Excellent" : "N/A";
            lblDevHealthValue.ForeColor = mDevHandle != IntPtr.Zero ? ThemeManager.Success : ThemeManager.TextSecondary;
        }

        private void btnNavAttendance_Click(object sender, EventArgs e) { ShowPage(0); }
        private void btnNavRegister_Click(object sender, EventArgs e) { ShowPage(1); }
        private void btnNavDevice_Click(object sender, EventArgs e) { ShowPage(2); }
        private void btnNavSettings_Click(object sender, EventArgs e) { ShowPage(3); }

        private void btnTimeIn_Click(object sender, EventArgs e)
        {
            if (mDevHandle == IntPtr.Zero)
            {
                _toast.Show("Connect device first", ToastNotification.ToastType.Warning);
                return;
            }
            if (cbRegTmp <= 0)
            {
                _toast.Show("No fingerprints registered", ToastNotification.ToastType.Warning);
                return;
            }
            bIdentify = true;
            _pendingAction = "Time In";
            UpdateScannerState("Place your finger for Time In", ThemeManager.Primary);
        }

        private void btnTimeOut_Click(object sender, EventArgs e)
        {
            if (mDevHandle == IntPtr.Zero)
            {
                _toast.Show("Connect device first", ToastNotification.ToastType.Warning);
                return;
            }
            if (cbRegTmp <= 0)
            {
                _toast.Show("No fingerprints registered", ToastNotification.ToastType.Warning);
                return;
            }
            bIdentify = true;
            _pendingAction = "Time Out";
            UpdateScannerState("Place your finger for Time Out", ThemeManager.Primary);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblAttName.Text = "No employee detected";
            lblAttResult.Text = "Ready";
            lblAttResult.ForeColor = ThemeManager.TextSecondary;
            lblScannerStatus.Text = "Place your finger on the scanner";
            lblScannerStatus.ForeColor = Color.FromArgb(148, 163, 184);
            fpScanner.ScannerState = ScannerState.Idle;
            picAttPhoto.Image = null;
            picFPImg.Image = null;
        }

        private void btnRegisterNew_Click(object sender, EventArgs e)
        {
            if (mDevHandle == IntPtr.Zero)
            {
                _toast.Show("Connect device first", ToastNotification.ToastType.Warning);
                return;
            }
            if (_enrollTarget == null)
            {
                _toast.Show("Select an employee first", ToastNotification.ToastType.Warning);
                return;
            }
            if (IsRegister) return;

            // Ask the HRIS for a stable fingerprint id for this employee
            // (source of truth). Falls back to the local counter when offline.
            _enrollFid = ResolveHrisFingerprintId(_enrollTarget.EmployeeID);

            IsRegister = true;
            RegisterCount = 0;
            cbRegTmp = 0;
            progressEnroll.Value = 0;
            lblEnrollStep.Text = "Press finger 1 of 3 for " + FullName(_enrollTarget);
            lblQuality.Text = "Fingerprint Quality: Waiting...";
            UpdateScannerState("Enrollment started", ThemeManager.Primary);
        }

        private int ResolveHrisFingerprintId(string employeeId)
        {
            try
            {
                if (_hrisApi == null || !_hrisApi.IsConfigured) return 0;
                HrisResponse resp = _hrisApi.AssignFingerprint(employeeId);
                if (resp.Ok && resp.FingerprintId.HasValue && resp.FingerprintId.Value > 0)
                {
                    FingerprintLogger.Info("ResolveHrisFingerprintId | " + employeeId + " -> fid " + resp.FingerprintId.Value);
                    return resp.FingerprintId.Value;
                }
                FingerprintLogger.Warning("ResolveHrisFingerprintId | " + employeeId + " -> " + (resp.Error ?? "no id"));
            }
            catch (Exception ex)
            {
                FingerprintLogger.Error("ResolveHrisFingerprintId", ex);
            }
            return 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetRegistrationForm();
        }

        private void ResetRegistrationForm()
        {
            _enrollTarget = null;
            _enrollFid = 0;
            if (lstEmployees != null) lstEmployees.SelectedIndex = -1;
            progressEnroll.Value = 0;
            lblEnrollStep.Text = "Press finger 1 of 3";
            lblQuality.Text = "Fingerprint Quality: Waiting...";
            IsRegister = false;
            RegisterCount = 0;
            cbRegTmp = 0;
            LoadEmployeeChoices();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsRegister = false;
            RegisterCount = 0;
            cbRegTmp = 0;
            progressEnroll.Value = 0;
            lblEnrollStep.Text = "Press finger 1 of 3";
            UpdateScannerState("Enrollment cancelled", Color.FromArgb(148, 163, 184));
            ShowPage(1);
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                dlg.Title = "Select Employee Photo";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    picPhoto.Image = Image.FromFile(dlg.FileName);
                }
            }
        }

        private void InitializeRegisterPage()
        {
            lblSectionInfo.Text = "Select Employee";
            Control[] toHide = new Control[] {
                txtEmployeeId, txtFirstName, txtMiddleName, txtLastName,
                txtDepartment, txtPosition, txtEmail, txtPhone,
                label4, label5, label6, label7, label8, label9, label10, label11,
                picPhoto, btnUploadPhoto
            };
            foreach (Control c in toHide) { c.Visible = false; }

            lstEmployees = new ListBox();
            lstEmployees.Name = "lstEmployees";
            lstEmployees.BackColor = Color.FromArgb(15, 23, 42);
            lstEmployees.ForeColor = Color.White;
            lstEmployees.BorderStyle = BorderStyle.FixedSingle;
            lstEmployees.Font = new Font("Segoe UI", 10F);
            lstEmployees.IntegralHeight = false;
            lstEmployees.Location = new Point(30, 56);
            lstEmployees.Size = new Size(450, 400);
            lstEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstEmployees.SelectedIndexChanged += lstEmployees_SelectedIndexChanged;
            pnlRegForm.Controls.Add(lstEmployees);
            lstEmployees.BringToFront();
        }

        private void LoadEmployeeChoices()
        {
            if (lstEmployees == null) return;
            _enrollTarget = null;
            _enrollChoices.Clear();
            lstEmployees.Items.Clear();

            foreach (Employee e in _db.Employees)
            {
                if (_db.Fingerprints.Exists(f => f.EmployeeID == e.EmployeeID)) continue;
                _enrollChoices.Add(e);
                lstEmployees.Items.Add(FormatChoice(e));
            }

            lblQuality.Text = _enrollChoices.Count + " employee(s) available for registration.";
        }

        /// <summary>
        /// Pulls the active employee list from the HRIS (source of truth) and
        /// caches it locally so the enrollment page lists the current staff.
        /// Offline-safe: falls back to the last cached XML list.
        /// </summary>
        private void RefreshEmployeesFromHris()
        {
            if (_hrisApi == null || !_hrisApi.IsConfigured) return;
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    List<System.Collections.Generic.Dictionary<string, object>> employees;
                    HrisResponse resp = _hrisApi.GetEmployees(out employees);
                    if (!resp.Ok || employees == null || employees.Count == 0)
                    {
                        FingerprintLogger.Warning("RefreshEmployeesFromHris | " + (resp.Error ?? "empty list"));
                        return;
                    }

                    // Do not delete any local entries while a fetch fails or
                    // returns nothing — the HRIS list is only authoritative when
                    // a real, non-empty active list comes back.
                    var hrisIds = new HashSet<string>();
                    foreach (var entry in employees)
                    {
                        string employeeId = GetString(entry, "employee_id");
                        if (!string.IsNullOrEmpty(employeeId)) hrisIds.Add(employeeId);
                    }

                    // Apply the merge + reconciliation on the UI thread so the
                    // device DB, local XML stores and the listbox stay consistent.
                    BeginInvoke(new MethodInvoker(delegate { ApplyEmployeeSync(employees, hrisIds); }));
                    FingerprintLogger.Info("RefreshEmployeesFromHris | fetched " + hrisIds.Count + " employees");
                }
                catch (Exception ex)
                {
                    FingerprintLogger.Error("RefreshEmployeesFromHris", ex);
                }
            });
        }

        /// <summary>
        /// Merge the HRIS active employee list into the local store and remove
        /// local employees that are no longer active in the HRIS (deleted or
        /// deactivated). Their enrolled fingerprint templates are also deleted
        /// from the device database so a removed employee can no longer clock in.
        /// Runs on the UI thread (device SDK + local stores are UI-thread owned).
        /// </summary>
        private void ApplyEmployeeSync(
            List<System.Collections.Generic.Dictionary<string, object>> employees,
            HashSet<string> hrisIds)
        {
            try
            {
                foreach (var entry in employees)
                {
                    string employeeId = GetString(entry, "employee_id");
                    if (string.IsNullOrEmpty(employeeId)) continue;

                    Employee emp = new Employee
                    {
                        EmployeeID = employeeId,
                        FirstName = GetString(entry, "first_name"),
                        MiddleName = GetString(entry, "middle_name"),
                        LastName = GetString(entry, "last_name"),
                        Department = GetString(entry, "department"),
                        Position = GetString(entry, "position"),
                    };

                    Employee existing = _db.FindEmployeeById(employeeId);
                    if (existing != null)
                    {
                        emp.Email = existing.Email;
                        emp.Phone = existing.Phone;
                        emp.PhotoPath = existing.PhotoPath;
                    }

                    _db.AddEmployee(emp);
                }

                // Employees present locally but absent from the HRIS active list
                // were deleted/deactivated in the system — remove them together
                // with their enrolled fingerprints.
                var toRemove = new List<Employee>();
                foreach (Employee e in _db.Employees)
                {
                    if (!hrisIds.Contains(e.EmployeeID)) toRemove.Add(e);
                }
                foreach (Employee e in toRemove)
                {
                    foreach (FingerprintRecord fp in _db.Fingerprints.ToList())
                    {
                        if (fp.EmployeeID == e.EmployeeID)
                        {
                            if (mDBHandle != IntPtr.Zero)
                            {
                                int delRet = zkfp2.DBDel(mDBHandle, fp.FingerprintID);
                                if (delRet != zkfp.ZKFP_ERR_OK)
                                    FingerprintLogger.SdkError("ApplyEmployeeSync | DBDel fid=" + fp.FingerprintID, delRet);
                            }
                            _db.Fingerprints.Remove(fp);
                        }
                    }
                    _db.Employees.Remove(e);
                    FingerprintLogger.Info("ApplyEmployeeSync | removed inactive employee " + e.EmployeeID);
                }

                _db.SaveEmployees();
                _db.SaveFingerprints();
                LoadEmployeeChoices();
                UpdateStats();
            }
            catch (Exception ex)
            {
                FingerprintLogger.Error("ApplyEmployeeSync", ex);
            }
        }

        private static string GetString(System.Collections.Generic.Dictionary<string, object> dict, string key)
        {
            object value;
            if (dict.TryGetValue(key, out value) && value != null)
                return Convert.ToString(value);
            return null;
        }

        private static string FormatChoice(Employee e)
        {
            string name = (e.FirstName + " " + e.LastName).Trim();
            string dept = string.IsNullOrEmpty(e.Department) ? "" : "  -  " + e.Department;
            return e.EmployeeID + "   |   " + name + dept;
        }

        private static string FullName(Employee e)
        {
            string mid = string.IsNullOrEmpty(e.MiddleName) ? "" : " " + e.MiddleName;
            return (e.FirstName + mid + " " + e.LastName).Trim();
        }

        private void lstEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = lstEmployees.SelectedIndex;
            if (idx < 0 || idx >= _enrollChoices.Count)
            {
                _enrollTarget = null;
                return;
            }
            _enrollTarget = _enrollChoices[idx];
            lblEnrollStep.Text = "Selected: " + FullName(_enrollTarget);
            lblQuality.Text = "Click Register to enroll this employee's fingerprint.";
        }

        private void timerReconnect_Tick(object sender, EventArgs e)
        {
            if (mDevHandle != IntPtr.Zero)
            {
                timerReconnect.Stop();
                return;
            }
            TryAutoInitialize();
            if (mDevHandle != IntPtr.Zero)
            {
                timerReconnect.Stop();
                UpdateDeviceInfo();
            }
        }

        private void btnRefreshDevice_Click(object sender, EventArgs e)
        {
            if (mDevHandle == IntPtr.Zero)
                TryAutoInitialize();
            UpdateDeviceInfo();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblTopClock.Text = DateTime.Now.ToString("HH:mm:ss");
            lblTopDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            lblAttTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblAttDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            string status = textRes.Text;

            if (status.StartsWith("enroll succ"))
            {
                progressEnroll.Value = 100;
                lblEnrollStep.Text = "Enrollment Successful!";
                UpdateScannerState("Enrollment completed", ThemeManager.Success);
                return;
            }

            if (IsRegister)
            {
                UpdateScannerState("Scanning...", ThemeManager.Primary);

                if (RegisterCount == 0)
                {
                    progressEnroll.Value = 0;
                    lblEnrollStep.Text = "Press finger 1 of 3";
                }
                else if (RegisterCount == 1)
                {
                    progressEnroll.Value = 33;
                    lblEnrollStep.Text = "Press finger 2 of 3";
                }
                else if (RegisterCount == 2)
                {
                    progressEnroll.Value = 66;
                    lblEnrollStep.Text = "Press finger 3 of 3";
                }
                return;
            }

            if (string.IsNullOrEmpty(status) || status == "Open succ")
            {
                if (fpScanner.ScannerState != ScannerState.Idle)
                {
                    fpScanner.ScannerState = ScannerState.Idle;
                    lblScannerStatus.Text = "Place your finger on the scanner";
                    lblScannerStatus.ForeColor = Color.FromArgb(148, 163, 184);
                }
                return;
            }

            if (status.Contains("succ") || status.Contains("Welcome"))
            {
                UpdateScannerState("Verified", ThemeManager.Success);
                if (!lblAttResult.Text.StartsWith("Time In") && !lblAttResult.Text.StartsWith("Time Out")
                    && !lblAttResult.Text.StartsWith("Already recorded"))
                {
                    lblAttResult.Text = status;
                    lblAttResult.ForeColor = ThemeManager.Success;
                }
                return;
            }

            if (status.Contains("fail") || status.Contains("already register"))
            {
                UpdateScannerState("Failed", ThemeManager.Error);
                lblAttResult.Text = status;
                lblAttResult.ForeColor = ThemeManager.Error;
                return;
            }

            if (status.Contains("Please press"))
            {
                UpdateScannerState("Scanning...", ThemeManager.Primary);
                return;
            }
        }

        private void UpdateScannerState(string message, Color color)
        {
            lblScannerStatus.Text = message;
            lblScannerStatus.ForeColor = color;

            if (color == ThemeManager.Success)
                fpScanner.ScannerState = ScannerState.Verified;
            else if (color == ThemeManager.Error)
                fpScanner.ScannerState = ScannerState.Failed;
            else if (message.Contains("finger") || message.Contains("Scanning"))
                fpScanner.ScannerState = ScannerState.Scanning;
            else
                fpScanner.ScannerState = ScannerState.Idle;
        }

        private void UpdateEmployeeInfo(Employee emp)
        {
            if (emp != null)
            {
                lblAttName.Text = string.Format("{0} {1}", emp.FirstName, emp.LastName);
                lblAttDepartment.Text = emp.Department;
                lblAttPosition.Text = emp.Position;
            }
        }

        private void ShowEmployeePhoto(string photoPath)
        {
            if (!string.IsNullOrEmpty(photoPath) && File.Exists(photoPath))
            {
                try { picAttPhoto.Image = Image.FromFile(photoPath); }
                catch { picAttPhoto.Image = null; }
            }
            else
            {
                picAttPhoto.Image = null;
            }
        }

        private void SaveFingerprintToDB(int fid)
        {
            Employee target = _enrollTarget;
            if (target == null)
            {
                FingerprintLogger.Warning("SaveFingerprintToDB | No employee selected; skipping save");
                return;
            }

            string templateBase64 = zkfp2.BlobToBase64(RegTmp, cbRegTmp);

            _db.AddFingerprint(new FingerprintRecord
            {
                FingerprintID = fid,
                EmployeeID = target.EmployeeID,
                TemplateBase64 = templateBase64,
                RegisterDate = DateTime.Now
            });

            Employee emp = new Employee
            {
                EmployeeID = target.EmployeeID,
                FirstName = target.FirstName,
                MiddleName = target.MiddleName,
                LastName = target.LastName,
                Department = target.Department,
                Position = target.Position,
                Email = target.Email,
                Phone = target.Phone,
                PhotoPath = target.PhotoPath
            };

            _db.AddEmployee(emp);
            _db.SaveFingerprints();
            _db.SaveEmployees();

            _hasRegisteredFingerprints = true;
            if (cbRegTmp <= 0) cbRegTmp = 2048;
            UpdateStats();

            _toast.Show("Fingerprint saved for " + FullName(emp), ToastNotification.ToastType.Success);
        }

        private void LoadFingerprintsFromDB()
        {
            if (_fpLoaded) return;
            _fpLoaded = true;

            int loadedCount = 0;
            foreach (var fp in _db.Fingerprints)
            {
                byte[] template = zkfp2.Base64ToBlob(fp.TemplateBase64);
                int ret = zkfp2.DBAdd(mDBHandle, fp.FingerprintID, template);
                if (ret == zkfp.ZKFP_ERR_OK)
                {
                    loadedCount++;
                }
                else
                {
                    FingerprintLogger.SdkError("LoadFingerprintsFromDB | DBAdd fid=" + fp.FingerprintID, ret);
                }
            }

            iFid = _db.GetNextFingerprintId();
            if (iFid < 1) iFid = 1;

            textRes.Text = "Loaded " + loadedCount + " fingerprints, next fid=" + iFid;
            lblDbStatus.Text = "DB: " + _db.FingerprintCount + " templates";
            lblFpCount.Text = "Fingerprints: " + _db.FingerprintCount;

            if (loadedCount > 0)
            {
                cbRegTmp = 2048;
                _hasRegisteredFingerprints = true;
            }

            UpdateStats();
        }

        private void UpdateStats()
        {
            int todayCount = 0;
            DateTime today = DateTime.Now.Date;
            foreach (AttendanceRecord r in _db.Attendance)
            {
                if (r.DateTime.Date == today) todayCount++;
            }

            lblDashFpCountValue.Text = _db.FingerprintCount.ToString();
            lblDashEmpValue.Text = _db.Employees.Count.ToString();
            lblDashTodayValue.Text = todayCount.ToString();
            lblFpCount.Text = "Fingerprints: " + _db.FingerprintCount;

            bool connected = (mDevHandle != IntPtr.Zero);
            lblDashDeviceValue.Text = connected ? "Connected" : "Disconnected";
            lblDashDeviceValue.ForeColor = connected ? ThemeManager.Success : ThemeManager.Error;
        }

        private void InitializeHistoryPage()
        {
            if (dataGridHistory.Columns.Count == 0)
            {
                dataGridHistory.Columns.Add("colDate", "Date");
                dataGridHistory.Columns.Add("colTime", "Time");
                dataGridHistory.Columns.Add("colEmpId", "Employee ID");
                dataGridHistory.Columns.Add("colName", "Employee");
                dataGridHistory.Columns.Add("colAction", "Action");

                dataGridHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridHistory.Columns["colDate"].FillWeight = 15;
                dataGridHistory.Columns["colTime"].FillWeight = 13;
                dataGridHistory.Columns["colEmpId"].FillWeight = 15;
                dataGridHistory.Columns["colName"].FillWeight = 37;
                dataGridHistory.Columns["colAction"].FillWeight = 20;
            }

            dataGridHistory.EnableHeadersVisualStyles = false;
            dataGridHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dataGridHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(148, 163, 184);
            dataGridHistory.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 41, 59);
            dataGridHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridHistory.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dataGridHistory.DefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dataGridHistory.DefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dataGridHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 99, 235);
            dataGridHistory.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridHistory.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dataGridHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 33, 50);
            dataGridHistory.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dataGridHistory.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 99, 235);
            dataGridHistory.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            dataGridHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridHistory.GridColor = Color.FromArgb(51, 65, 85);

            dataGridHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlHistoryToolbar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            try { dtpHistoryFrom.Value = new DateTime(2000, 1, 1); }
            catch { }

            _lblHistoryCount = new Label();
            _lblHistoryCount.Location = new Point(450, 10);
            _lblHistoryCount.Size = new Size(390, 25);
            _lblHistoryCount.ForeColor = Color.FromArgb(148, 163, 184);
            _lblHistoryCount.Font = new Font("Segoe UI", 9F);
            _lblHistoryCount.TextAlign = ContentAlignment.MiddleLeft;
            pnlHistoryToolbar.Controls.Add(_lblHistoryCount);

            _lblHistoryEmpty = new Label();
            _lblHistoryEmpty.Text = "No attendance records found";
            _lblHistoryEmpty.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            _lblHistoryEmpty.ForeColor = Color.FromArgb(100, 116, 139);
            _lblHistoryEmpty.Location = new Point(0, 180);
            _lblHistoryEmpty.Size = new Size(pnlHistory.Width, 60);
            _lblHistoryEmpty.TextAlign = ContentAlignment.MiddleCenter;
            _lblHistoryEmpty.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _lblHistoryEmpty.Visible = false;
            pnlHistory.Controls.Add(_lblHistoryEmpty);
            _lblHistoryEmpty.BringToFront();

            btnRefreshHistory.Click += btnRefreshHistory_Click;
            btnDeleteRecord.Click += btnDeleteRecord_Click;
            btnExportCsv.Click += btnExportCsv_Click;
            txtSearchHistory.TextChanged += delegate { RefreshHistory(); };
            dtpHistoryFrom.ValueChanged += delegate { RefreshHistory(); };
            dtpHistoryTo.ValueChanged += delegate { RefreshHistory(); };
        }

        private void RefreshHistory()
        {
            if (dataGridHistory.Columns.Count == 0) return;

            DateTime from = dtpHistoryFrom.Value.Date;
            DateTime to = dtpHistoryTo.Value.Date;
            string q = txtSearchHistory.Text.Trim().ToLower();

            dataGridHistory.Rows.Clear();
            _historyRows.Clear();

            for (int i = _db.Attendance.Count - 1; i >= 0; i--)
            {
                AttendanceRecord r = _db.Attendance[i];
                DateTime d = r.DateTime.Date;
                if (d < from || d > to) continue;

                Employee emp = _db.FindEmployeeById(r.EmployeeID);
                string name = emp != null ? FullName(emp) : "(unknown)";
                string hay = (r.EmployeeID + " " + name + " " + r.Action).ToLower();
                if (q.Length > 0 && !hay.Contains(q)) continue;

                _historyRows.Add(r);
                int idx = dataGridHistory.Rows.Add(
                    d.ToString("yyyy-MM-dd"),
                    r.DateTime.ToString("HH:mm:ss"),
                    r.EmployeeID,
                    name,
                    r.Action);
                Color c = r.Action == "Time In" ? Color.FromArgb(0, 230, 118) : Color.FromArgb(255, 184, 0);
                dataGridHistory.Rows[idx].Cells["colAction"].Style.ForeColor = c;
            }

            int n = dataGridHistory.Rows.Count;
            if (_lblHistoryCount != null)
                _lblHistoryCount.Text = n + (n == 1 ? " record" : " records");
            if (_lblHistoryEmpty != null)
                _lblHistoryEmpty.Visible = (n == 0);
        }

        private void btnRefreshHistory_Click(object sender, EventArgs e)
        {
            RefreshHistory();
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if (dataGridHistory.SelectedRows.Count == 0)
            {
                _toast.Show("Select a record to delete", ToastNotification.ToastType.Warning);
                return;
            }
            int idx = dataGridHistory.SelectedRows[0].Index;
            if (idx < 0 || idx >= _historyRows.Count) return;

            AttendanceRecord r = _historyRows[idx];
            _db.Attendance.Remove(r);
            _db.SaveAttendance();
            UpdateStats();
            RefreshHistory();
            _toast.Show("Record deleted", ToastNotification.ToastType.Success);
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "CSV Files|*.csv";
                dlg.FileName = "attendance_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
                if (dlg.ShowDialog() != DialogResult.OK) return;
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Date,Time,Employee ID,Employee,Action");
                    foreach (DataGridViewRow row in dataGridHistory.Rows)
                    {
                        string name = row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString().Replace("\"", "\"\"");
                        sb.AppendLine(string.Format("{0},{1},{2},\"{3}\",{4}",
                            row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, name, row.Cells[4].Value));
                    }
                    File.WriteAllText(dlg.FileName, sb.ToString());
                    _toast.Show("Exported to CSV", ToastNotification.ToastType.Success);
                }
                catch (Exception ex)
                {
                    FingerprintLogger.Error("btnExportCsv_Click | Export failed", ex);
                    _toast.Show("Export failed", ToastNotification.ToastType.Error);
                }
            }
        }

        private void ProcessAttendance(int fid)
        {
            var emp = _db.FindEmployeeByFingerprintId(fid);
            if (emp != null)
            {
                UpdateEmployeeInfo(emp);
                ShowEmployeePhoto(emp.PhotoPath);
                string action = _pendingAction;
                if (HasRecentAttendance(emp.EmployeeID, action, 20))
                {
                    lblAttResult.Text = "Already recorded - " + action + " at " + DateTime.Now.ToString("HH:mm:ss");
                    lblAttResult.ForeColor = ThemeManager.TextSecondary;
                    return;
                }
                var record = new AttendanceRecord
                {
                    EmployeeID = emp.EmployeeID,
                    DateTime = DateTime.Now,
                    Action = action
                };
                _db.AddAttendance(record);
                _db.SaveAttendance();
                PushPunchToHris(record, fid);
                UpdateStats();
                lblAttResult.Text = string.Format("{0} Successful - {1}",
                    action, DateTime.Now.ToString("HH:mm:ss"));
                lblAttResult.ForeColor = ThemeManager.Success;
            }
            else
            {
                FingerprintLogger.Warning("ProcessAttendance | Employee #" + fid + " not found in DB");
                lblAttName.Text = "Employee #" + fid + " (not registered in DB)";
                picAttPhoto.Image = null;
                lblAttResult.Text = "Verified";
                lblAttResult.ForeColor = ThemeManager.Success;
            }
        }

        private bool HasRecentAttendance(string employeeId, string action, int withinSeconds)
        {
            DateTime cutoff = DateTime.Now.AddSeconds(-withinSeconds);
            for (int i = _db.Attendance.Count - 1; i >= 0; i--)
            {
                var r = _db.Attendance[i];
                if (r.DateTime < cutoff) break;
                if (r.EmployeeID == employeeId && r.Action == action)
                    return true;
            }
            return false;
        }

        private void chkAnimations_CheckedChanged(object sender, EventArgs e)
        {
            timerAnimation.Enabled = chkAnimations.Checked;
        }

        private void cmbTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            string theme = cmbTheme.SelectedItem.ToString();
            AppTheme selected;
            if (theme == "Dark") selected = AppTheme.Dark;
            else if (theme == "Light") selected = AppTheme.Light;
            else selected = AppTheme.Cyber;
            ThemeManager.ApplyTheme(this, selected);
            _toast.Show("Theme changed to " + theme, ToastNotification.ToastType.Success);
        }



        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            FingerprintLogger.Info("OnFormClosing | Application shutting down");
            timerReconnect.Stop();
            if (timerHrisHeartbeat != null) timerHrisHeartbeat.Stop();
            _db.SaveFingerprints();
            _db.SaveEmployees();
            _db.SaveAttendance();
            try { RegisterAgentAndFlush(); } catch { }
            CloseDevice();
            zkfp2.Terminate();
            base.OnFormClosing(e);
        }
    }


}
