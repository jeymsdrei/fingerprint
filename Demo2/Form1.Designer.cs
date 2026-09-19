namespace Demo
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bnInit = new System.Windows.Forms.Button();
            this.bnOpen = new System.Windows.Forms.Button();
            this.bnEnroll = new System.Windows.Forms.Button();
            this.bnVerify = new System.Windows.Forms.Button();
            this.bnFree = new System.Windows.Forms.Button();
            this.bnClose = new System.Windows.Forms.Button();
            this.bnIdentify = new System.Windows.Forms.Button();
            this.textRes = new System.Windows.Forms.TextBox();
            this.picFPImg = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbIdx = new System.Windows.Forms.ComboBox();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblLogoSub = new System.Windows.Forms.Label();
            this.lblAppLogo = new System.Windows.Forms.Label();
            this.btnNavSettings = new Demo.Controls.NavigationButton();
            this.btnNavDevice = new Demo.Controls.NavigationButton();
            this.btnNavHistory = new Demo.Controls.NavigationButton();
            this.btnNavRegister = new Demo.Controls.NavigationButton();
            this.btnNavAttendance = new Demo.Controls.NavigationButton();
            this.btnNavDashboard = new Demo.Controls.NavigationButton();
            this.pnlMainArea = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.lblDashTitle = new System.Windows.Forms.Label();
            this.pnlDashFpCount = new Demo.Controls.RoundedPanel();
            this.lblDashFpCountValue = new System.Windows.Forms.Label();
            this.lblDashFpCountLabel = new System.Windows.Forms.Label();
            this.pnlDashEmployees = new Demo.Controls.RoundedPanel();
            this.lblDashEmpValue = new System.Windows.Forms.Label();
            this.lblDashEmpLabel = new System.Windows.Forms.Label();
            this.pnlDashToday = new Demo.Controls.RoundedPanel();
            this.lblDashTodayValue = new System.Windows.Forms.Label();
            this.lblDashTodayLabel = new System.Windows.Forms.Label();
            this.pnlDashDevice = new Demo.Controls.RoundedPanel();
            this.lblDashDeviceValue = new System.Windows.Forms.Label();
            this.lblDashDeviceLabel = new System.Windows.Forms.Label();
            this.lblDashSubtitle = new System.Windows.Forms.Label();
            this.pnlAttendance = new System.Windows.Forms.Panel();
            this.pnlAttRight = new Demo.Controls.RoundedPanel();
            this.lblAttTime = new System.Windows.Forms.Label();
            this.lblAttDate = new System.Windows.Forms.Label();
            this.lblAttPosition = new System.Windows.Forms.Label();
            this.lblAttDepartment = new System.Windows.Forms.Label();
            this.lblAttName = new System.Windows.Forms.Label();
            this.picAttPhoto = new System.Windows.Forms.PictureBox();
            this.btnAttClear = new Demo.Controls.RoundedButton();
            this.btnAttTimeOut = new Demo.Controls.RoundedButton();
            this.btnAttTimeIn = new Demo.Controls.RoundedButton();
            this.lblAttResult = new System.Windows.Forms.Label();
            this.lblScannerStatus = new System.Windows.Forms.Label();
            this.fpScanner = new Demo.Controls.FingerprintPanel();
            this.pnlRegister = new System.Windows.Forms.Panel();
            this.pnlRegEnroll = new Demo.Controls.RoundedPanel();
            this.progressEnroll = new System.Windows.Forms.ProgressBar();
            this.pnlFpPreview = new Demo.Controls.RoundedPanel();
            this.lblQuality = new System.Windows.Forms.Label();
            this.lblEnrollStep = new System.Windows.Forms.Label();
            this.lblSectionEnroll = new System.Windows.Forms.Label();
            this.pnlRegForm = new Demo.Controls.RoundedPanel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtEmployeeId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSectionInfo = new System.Windows.Forms.Label();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.btnUploadPhoto = new Demo.Controls.RoundedButton();
            this.pnlRegActions = new Demo.Controls.RoundedPanel();
            this.btnCancelReg = new Demo.Controls.RoundedButton();
            this.btnResetReg = new Demo.Controls.RoundedButton();
            this.btnRegister = new Demo.Controls.RoundedButton();
            this.pnlHistory = new System.Windows.Forms.Panel();
            this.dataGridHistory = new System.Windows.Forms.DataGridView();
            this.pnlHistoryToolbar = new Demo.Controls.RoundedPanel();
            this.btnExportCsv = new Demo.Controls.RoundedButton();
            this.btnDeleteRecord = new Demo.Controls.RoundedButton();
            this.btnRefreshHistory = new Demo.Controls.RoundedButton();
            this.txtSearchHistory = new System.Windows.Forms.TextBox();
            this.dtpHistoryTo = new System.Windows.Forms.DateTimePicker();
            this.dtpHistoryFrom = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.lblSectionHistory = new System.Windows.Forms.Label();
            this.pnlDevice = new System.Windows.Forms.Panel();
            this.pnlDevHealth = new Demo.Controls.RoundedPanel();
            this.lblDevHealthLabel = new System.Windows.Forms.Label();
            this.lblDevHealthValue = new System.Windows.Forms.Label();
            this.btnRefreshDevice = new Demo.Controls.RoundedButton();
            this.pnlDevInfo = new Demo.Controls.RoundedPanel();
            this.lblDevRegFp = new System.Windows.Forms.Label();
            this.lblDevRegUsers = new System.Windows.Forms.Label();
            this.lblDevDbStatus = new System.Windows.Forms.Label();
            this.lblDevUsb = new System.Windows.Forms.Label();
            this.lblDevSdkVer = new System.Windows.Forms.Label();
            this.lblDevReaderModel = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblSectionDevice = new System.Windows.Forms.Label();
            this.pnlDevConnection = new Demo.Controls.RoundedPanel();
            this.lblDevConnectionStatus = new System.Windows.Forms.Label();
            this.lblDevConnectionLabel = new System.Windows.Forms.Label();
            this.pnlDevStatus = new Demo.Controls.RoundedPanel();
            this.lblDevStatusText = new System.Windows.Forms.Label();
            this.lblDevStatusLabel = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.pnlSettingsAbout = new Demo.Controls.RoundedPanel();
            this.lblAbout = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pnlSettingsAppearance = new Demo.Controls.RoundedPanel();
            this.chkAnimations = new System.Windows.Forms.CheckBox();
            this.cmbTheme = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblSectionSettings = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblTopConnDot = new System.Windows.Forms.Label();
            this.lblTopConnStatus = new System.Windows.Forms.Label();
            this.lblTopDate = new System.Windows.Forms.Label();
            this.lblTopClock = new System.Windows.Forms.Label();
            this.lblTopTitle = new System.Windows.Forms.Label();
            this.pnlStatusBar = new System.Windows.Forms.Panel();
            this.lblFpCount = new System.Windows.Forms.Label();
            this.lblDbStatus = new System.Windows.Forms.Label();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.lblSdkStatus = new System.Windows.Forms.Label();
            this.pnlSidebarDivider = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picFPImg)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            this.pnlMainArea.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.pnlDashFpCount.SuspendLayout();
            this.pnlDashEmployees.SuspendLayout();
            this.pnlDashToday.SuspendLayout();
            this.pnlDashDevice.SuspendLayout();
            this.pnlAttendance.SuspendLayout();
            this.pnlAttRight.SuspendLayout();
            this.fpScanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAttPhoto)).BeginInit();
            this.pnlRegister.SuspendLayout();
            this.pnlRegEnroll.SuspendLayout();
            this.pnlFpPreview.SuspendLayout();
            this.pnlRegForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.pnlRegActions.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistory)).BeginInit();
            this.pnlHistoryToolbar.SuspendLayout();
            this.pnlDevice.SuspendLayout();
            this.pnlDevHealth.SuspendLayout();
            this.pnlDevInfo.SuspendLayout();
            this.pnlDevConnection.SuspendLayout();
            this.pnlDevStatus.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.pnlSettingsAbout.SuspendLayout();
            this.pnlSettingsAppearance.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.pnlStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnInit
            // 
            this.bnInit.Location = new System.Drawing.Point(0, 0);
            this.bnInit.Name = "bnInit";
            this.bnInit.Size = new System.Drawing.Size(75, 23);
            this.bnInit.TabIndex = 0;
            this.bnInit.Text = "Initialize";
            this.bnInit.UseVisualStyleBackColor = true;
            this.bnInit.Visible = false;
            this.bnInit.Click += new System.EventHandler(this.bnInit_Click);
            // 
            // bnOpen
            // 
            this.bnOpen.Enabled = false;
            this.bnOpen.Location = new System.Drawing.Point(0, 0);
            this.bnOpen.Name = "bnOpen";
            this.bnOpen.Size = new System.Drawing.Size(75, 23);
            this.bnOpen.TabIndex = 1;
            this.bnOpen.Text = "Open";
            this.bnOpen.UseVisualStyleBackColor = true;
            this.bnOpen.Visible = false;
            this.bnOpen.Click += new System.EventHandler(this.bnOpen_Click);
            // 
            // bnEnroll
            // 
            this.bnEnroll.Enabled = false;
            this.bnEnroll.Location = new System.Drawing.Point(0, 0);
            this.bnEnroll.Name = "bnEnroll";
            this.bnEnroll.Size = new System.Drawing.Size(75, 23);
            this.bnEnroll.TabIndex = 2;
            this.bnEnroll.Text = "Enroll";
            this.bnEnroll.UseVisualStyleBackColor = true;
            this.bnEnroll.Visible = false;
            this.bnEnroll.Click += new System.EventHandler(this.bnEnroll_Click);
            // 
            // bnVerify
            // 
            this.bnVerify.Enabled = false;
            this.bnVerify.Location = new System.Drawing.Point(0, 0);
            this.bnVerify.Name = "bnVerify";
            this.bnVerify.Size = new System.Drawing.Size(75, 23);
            this.bnVerify.TabIndex = 3;
            this.bnVerify.Text = "Verify";
            this.bnVerify.UseVisualStyleBackColor = true;
            this.bnVerify.Visible = false;
            this.bnVerify.Click += new System.EventHandler(this.bnVerify_Click);
            // 
            // bnFree
            // 
            this.bnFree.Enabled = false;
            this.bnFree.Location = new System.Drawing.Point(0, 0);
            this.bnFree.Name = "bnFree";
            this.bnFree.Size = new System.Drawing.Size(75, 23);
            this.bnFree.TabIndex = 4;
            this.bnFree.Text = "Finalize";
            this.bnFree.UseVisualStyleBackColor = true;
            this.bnFree.Visible = false;
            this.bnFree.Click += new System.EventHandler(this.bnFree_Click);
            // 
            // bnClose
            // 
            this.bnClose.Enabled = false;
            this.bnClose.Location = new System.Drawing.Point(0, 0);
            this.bnClose.Name = "bnClose";
            this.bnClose.Size = new System.Drawing.Size(75, 23);
            this.bnClose.TabIndex = 5;
            this.bnClose.Text = "Close";
            this.bnClose.UseVisualStyleBackColor = true;
            this.bnClose.Visible = false;
            this.bnClose.Click += new System.EventHandler(this.bnClose_Click);
            // 
            // bnIdentify
            // 
            this.bnIdentify.Enabled = false;
            this.bnIdentify.Location = new System.Drawing.Point(0, 0);
            this.bnIdentify.Name = "bnIdentify";
            this.bnIdentify.Size = new System.Drawing.Size(75, 23);
            this.bnIdentify.TabIndex = 6;
            this.bnIdentify.Text = "Identiy";
            this.bnIdentify.UseVisualStyleBackColor = true;
            this.bnIdentify.Visible = false;
            this.bnIdentify.Click += new System.EventHandler(this.bnIdentify_Click);
            // 
            // textRes
            // 
            this.textRes.Location = new System.Drawing.Point(400, 400);
            this.textRes.Multiline = true;
            this.textRes.Name = "textRes";
            this.textRes.ReadOnly = true;
            this.textRes.Size = new System.Drawing.Size(100, 20);
            this.textRes.TabIndex = 7;
            this.textRes.Visible = false;
            // 
            // picFPImg
            // 
            this.picFPImg.Location = new System.Drawing.Point(300, 400);
            this.picFPImg.Name = "picFPImg";
            this.picFPImg.Size = new System.Drawing.Size(100, 100);
            this.picFPImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFPImg.TabIndex = 8;
            this.picFPImg.TabStop = false;
            this.picFPImg.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Index:";
            this.label1.Visible = false;
            // 
            // cmbIdx
            // 
            this.cmbIdx.FormattingEnabled = true;
            this.cmbIdx.Location = new System.Drawing.Point(0, 0);
            this.cmbIdx.Name = "cmbIdx";
            this.cmbIdx.Size = new System.Drawing.Size(40, 20);
            this.cmbIdx.TabIndex = 10;
            this.cmbIdx.Visible = false;
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 50;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlSidebar.Controls.Add(this.pnlSidebarDivider);
            this.pnlSidebar.Controls.Add(this.lblLogoSub);
            this.pnlSidebar.Controls.Add(this.lblAppLogo);
            this.pnlSidebar.Controls.Add(this.btnNavSettings);
            this.pnlSidebar.Controls.Add(this.btnNavDevice);
            this.pnlSidebar.Controls.Add(this.btnNavHistory);
            this.pnlSidebar.Controls.Add(this.btnNavRegister);
            this.pnlSidebar.Controls.Add(this.btnNavAttendance);
            this.pnlSidebar.Controls.Add(this.btnNavDashboard);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(240, 800);
            this.pnlSidebar.TabIndex = 11;
            // 
            // lblLogoSub
            // 
            this.lblLogoSub.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);
            this.lblLogoSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblLogoSub.Location = new System.Drawing.Point(20, 68);
            this.lblLogoSub.Name = "lblLogoSub";
            this.lblLogoSub.Size = new System.Drawing.Size(200, 20);
            this.lblLogoSub.TabIndex = 1;
            this.lblLogoSub.Text = "ATTENDANCE SYSTEM";
            this.lblLogoSub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAppLogo
            // 
            this.lblAppLogo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAppLogo.ForeColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.lblAppLogo.Location = new System.Drawing.Point(20, 24);
            this.lblAppLogo.Name = "lblAppLogo";
            this.lblAppLogo.Size = new System.Drawing.Size(200, 44);
            this.lblAppLogo.TabIndex = 0;
            this.lblAppLogo.Text = "BIOCLOCK";
            this.lblAppLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNavSettings
            // 
            this.btnNavSettings.FlatAppearance.BorderSize = 0;
            this.btnNavSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSettings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavSettings.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnNavSettings.IsActive = false;
            this.btnNavSettings.Location = new System.Drawing.Point(12, 398);
            this.btnNavSettings.Name = "btnNavSettings";
            this.btnNavSettings.Size = new System.Drawing.Size(216, 46);
            this.btnNavSettings.TabIndex = 5;
            this.btnNavSettings.Text = "Settings";
            this.btnNavSettings.UseVisualStyleBackColor = true;
            this.btnNavSettings.Click += new System.EventHandler(this.btnNavSettings_Click);
            // 
            // btnNavDevice
            // 
            this.btnNavDevice.FlatAppearance.BorderSize = 0;
            this.btnNavDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDevice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavDevice.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnNavDevice.IsActive = false;
            this.btnNavDevice.Location = new System.Drawing.Point(12, 346);
            this.btnNavDevice.Name = "btnNavDevice";
            this.btnNavDevice.Size = new System.Drawing.Size(216, 46);
            this.btnNavDevice.TabIndex = 4;
            this.btnNavDevice.Text = "Device";
            this.btnNavDevice.UseVisualStyleBackColor = true;
            this.btnNavDevice.Click += new System.EventHandler(this.btnNavDevice_Click);
            // 
            // btnNavHistory
            // 
            this.btnNavHistory.FlatAppearance.BorderSize = 0;
            this.btnNavHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavHistory.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnNavHistory.IsActive = false;
            this.btnNavHistory.Location = new System.Drawing.Point(12, 294);
            this.btnNavHistory.Name = "btnNavHistory";
            this.btnNavHistory.Size = new System.Drawing.Size(216, 46);
            this.btnNavHistory.TabIndex = 3;
            this.btnNavHistory.Text = "History";
            this.btnNavHistory.UseVisualStyleBackColor = true;
            // 
            // btnNavRegister
            // 
            this.btnNavRegister.FlatAppearance.BorderSize = 0;
            this.btnNavRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavRegister.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavRegister.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnNavRegister.IsActive = false;
            this.btnNavRegister.Location = new System.Drawing.Point(12, 242);
            this.btnNavRegister.Name = "btnNavRegister";
            this.btnNavRegister.Size = new System.Drawing.Size(216, 46);
            this.btnNavRegister.TabIndex = 2;
            this.btnNavRegister.Text = "Register User";
            this.btnNavRegister.UseVisualStyleBackColor = true;
            this.btnNavRegister.Click += new System.EventHandler(this.btnNavRegister_Click);
            // 
            // btnNavAttendance
            // 
            this.btnNavAttendance.FlatAppearance.BorderSize = 0;
            this.btnNavAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAttendance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavAttendance.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnNavAttendance.IsActive = false;
            this.btnNavAttendance.Location = new System.Drawing.Point(12, 190);
            this.btnNavAttendance.Name = "btnNavAttendance";
            this.btnNavAttendance.Size = new System.Drawing.Size(216, 46);
            this.btnNavAttendance.TabIndex = 1;
            this.btnNavAttendance.Text = "Attendance";
            this.btnNavAttendance.UseVisualStyleBackColor = true;
            this.btnNavAttendance.Click += new System.EventHandler(this.btnNavAttendance_Click);
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavDashboard.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnNavDashboard.IsActive = true;
            this.btnNavDashboard.Location = new System.Drawing.Point(12, 138);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Size = new System.Drawing.Size(216, 46);
            this.btnNavDashboard.TabIndex = 0;
            this.btnNavDashboard.Text = "Dashboard";
            this.btnNavDashboard.UseVisualStyleBackColor = true;
            // 
            // pnlMainArea
            // 
            this.pnlMainArea.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlMainArea.Controls.Add(this.pnlContent);
            this.pnlMainArea.Controls.Add(this.pnlTopBar);
            this.pnlMainArea.Controls.Add(this.pnlStatusBar);
            this.pnlMainArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainArea.Name = "pnlMainArea";
            this.pnlMainArea.Size = new System.Drawing.Size(1160, 800);
            this.pnlMainArea.TabIndex = 12;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlContent.Controls.Add(this.pnlDashboard);
            this.pnlContent.Controls.Add(this.pnlAttendance);
            this.pnlContent.Controls.Add(this.pnlRegister);
            this.pnlContent.Controls.Add(this.pnlHistory);
            this.pnlContent.Controls.Add(this.pnlDevice);
            this.pnlContent.Controls.Add(this.pnlSettings);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(1160, 703);
            this.pnlContent.TabIndex = 2;
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.AutoScroll = true;
            this.pnlDashboard.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlDashboard.Controls.Add(this.lblDashSubtitle);
            this.pnlDashboard.Controls.Add(this.pnlDashDevice);
            this.pnlDashboard.Controls.Add(this.pnlDashToday);
            this.pnlDashboard.Controls.Add(this.pnlDashEmployees);
            this.pnlDashboard.Controls.Add(this.pnlDashFpCount);
            this.pnlDashboard.Controls.Add(this.lblDashTitle);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(1120, 663);
            this.pnlDashboard.TabIndex = 5;
            // 
            // lblDashTitle
            // 
            this.lblDashTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblDashTitle.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblDashTitle.Location = new System.Drawing.Point(0, 0);
            this.lblDashTitle.Name = "lblDashTitle";
            this.lblDashTitle.Size = new System.Drawing.Size(400, 44);
            this.lblDashTitle.TabIndex = 0;
            this.lblDashTitle.Text = "Dashboard";
            this.lblDashTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDashFpCount
            // 
            this.pnlDashFpCount.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlDashFpCount.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlDashFpCount.BorderRadius = 14;
            this.pnlDashFpCount.BorderWidth = 1;
            this.pnlDashFpCount.Controls.Add(this.lblDashFpCountValue);
            this.pnlDashFpCount.Controls.Add(this.lblDashFpCountLabel);
            this.pnlDashFpCount.DrawBorder = true;
            this.pnlDashFpCount.Location = new System.Drawing.Point(0, 100);
            this.pnlDashFpCount.Name = "pnlDashFpCount";
            this.pnlDashFpCount.Size = new System.Drawing.Size(255, 120);
            this.pnlDashFpCount.TabIndex = 1;
            // 
            // lblDashFpCountValue
            // 
            this.lblDashFpCountValue.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblDashFpCountValue.ForeColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.lblDashFpCountValue.Location = new System.Drawing.Point(15, 20);
            this.lblDashFpCountValue.Name = "lblDashFpCountValue";
            this.lblDashFpCountValue.Size = new System.Drawing.Size(100, 50);
            this.lblDashFpCountValue.TabIndex = 1;
            this.lblDashFpCountValue.Text = "0";
            this.lblDashFpCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDashFpCountLabel
            // 
            this.lblDashFpCountLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblDashFpCountLabel.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDashFpCountLabel.Location = new System.Drawing.Point(15, 75);
            this.lblDashFpCountLabel.Name = "lblDashFpCountLabel";
            this.lblDashFpCountLabel.Size = new System.Drawing.Size(225, 30);
            this.lblDashFpCountLabel.TabIndex = 0;
            this.lblDashFpCountLabel.Text = "Fingerprint Templates";
            this.lblDashFpCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDashEmployees
            // 
            this.pnlDashEmployees.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlDashEmployees.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlDashEmployees.BorderRadius = 14;
            this.pnlDashEmployees.BorderWidth = 1;
            this.pnlDashEmployees.Controls.Add(this.lblDashEmpValue);
            this.pnlDashEmployees.Controls.Add(this.lblDashEmpLabel);
            this.pnlDashEmployees.DrawBorder = true;
            this.pnlDashEmployees.Location = new System.Drawing.Point(285, 100);
            this.pnlDashEmployees.Name = "pnlDashEmployees";
            this.pnlDashEmployees.Size = new System.Drawing.Size(255, 120);
            this.pnlDashEmployees.TabIndex = 2;
            // 
            // lblDashEmpValue
            // 
            this.lblDashEmpValue.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblDashEmpValue.ForeColor = System.Drawing.Color.FromArgb(0, 212, 255);
            this.lblDashEmpValue.Location = new System.Drawing.Point(15, 20);
            this.lblDashEmpValue.Name = "lblDashEmpValue";
            this.lblDashEmpValue.Size = new System.Drawing.Size(100, 50);
            this.lblDashEmpValue.TabIndex = 1;
            this.lblDashEmpValue.Text = "0";
            this.lblDashEmpValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDashEmpLabel
            // 
            this.lblDashEmpLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblDashEmpLabel.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDashEmpLabel.Location = new System.Drawing.Point(15, 75);
            this.lblDashEmpLabel.Name = "lblDashEmpLabel";
            this.lblDashEmpLabel.Size = new System.Drawing.Size(225, 30);
            this.lblDashEmpLabel.TabIndex = 0;
            this.lblDashEmpLabel.Text = "Registered Employees";
            this.lblDashEmpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDashToday
            // 
            this.pnlDashToday.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlDashToday.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlDashToday.BorderRadius = 14;
            this.pnlDashToday.BorderWidth = 1;
            this.pnlDashToday.Controls.Add(this.lblDashTodayValue);
            this.pnlDashToday.Controls.Add(this.lblDashTodayLabel);
            this.pnlDashToday.DrawBorder = true;
            this.pnlDashToday.Location = new System.Drawing.Point(570, 100);
            this.pnlDashToday.Name = "pnlDashToday";
            this.pnlDashToday.Size = new System.Drawing.Size(255, 120);
            this.pnlDashToday.TabIndex = 3;
            // 
            // lblDashTodayValue
            // 
            this.lblDashTodayValue.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblDashTodayValue.ForeColor = System.Drawing.Color.FromArgb(0, 255, 198);
            this.lblDashTodayValue.Location = new System.Drawing.Point(15, 20);
            this.lblDashTodayValue.Name = "lblDashTodayValue";
            this.lblDashTodayValue.Size = new System.Drawing.Size(100, 50);
            this.lblDashTodayValue.TabIndex = 1;
            this.lblDashTodayValue.Text = "0";
            this.lblDashTodayValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDashTodayLabel
            // 
            this.lblDashTodayLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblDashTodayLabel.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDashTodayLabel.Location = new System.Drawing.Point(15, 75);
            this.lblDashTodayLabel.Name = "lblDashTodayLabel";
            this.lblDashTodayLabel.Size = new System.Drawing.Size(225, 30);
            this.lblDashTodayLabel.TabIndex = 0;
            this.lblDashTodayLabel.Text = "Today's Attendance";
            this.lblDashTodayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDashDevice
            // 
            this.pnlDashDevice.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlDashDevice.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlDashDevice.BorderRadius = 14;
            this.pnlDashDevice.BorderWidth = 1;
            this.pnlDashDevice.Controls.Add(this.lblDashDeviceValue);
            this.pnlDashDevice.Controls.Add(this.lblDashDeviceLabel);
            this.pnlDashDevice.DrawBorder = true;
            this.pnlDashDevice.Location = new System.Drawing.Point(855, 100);
            this.pnlDashDevice.Name = "pnlDashDevice";
            this.pnlDashDevice.Size = new System.Drawing.Size(255, 120);
            this.pnlDashDevice.TabIndex = 4;
            // 
            // lblDashDeviceValue
            // 
            this.lblDashDeviceValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDashDeviceValue.ForeColor = System.Drawing.Color.FromArgb(0, 230, 118);
            this.lblDashDeviceValue.Location = new System.Drawing.Point(15, 20);
            this.lblDashDeviceValue.Name = "lblDashDeviceValue";
            this.lblDashDeviceValue.Size = new System.Drawing.Size(225, 50);
            this.lblDashDeviceValue.TabIndex = 1;
            this.lblDashDeviceValue.Text = "Disconnected";
            this.lblDashDeviceValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDashDeviceLabel
            // 
            this.lblDashDeviceLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblDashDeviceLabel.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDashDeviceLabel.Location = new System.Drawing.Point(15, 75);
            this.lblDashDeviceLabel.Name = "lblDashDeviceLabel";
            this.lblDashDeviceLabel.Size = new System.Drawing.Size(225, 30);
            this.lblDashDeviceLabel.TabIndex = 0;
            this.lblDashDeviceLabel.Text = "Device Status";
            this.lblDashDeviceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDashSubtitle
            // 
            this.lblDashSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblDashSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDashSubtitle.Location = new System.Drawing.Point(0, 44);
            this.lblDashSubtitle.Name = "lblDashSubtitle";
            this.lblDashSubtitle.Size = new System.Drawing.Size(500, 30);
            this.lblDashSubtitle.TabIndex = 5;
            this.lblDashSubtitle.Text = "Overview of your biometric attendance system";
            this.lblDashSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAttendance
            // 
            this.pnlAttendance.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlAttendance.Controls.Add(this.pnlAttRight);
            this.pnlAttendance.Controls.Add(this.fpScanner);
            this.pnlAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttendance.Name = "pnlAttendance";
            this.pnlAttendance.Size = new System.Drawing.Size(1120, 663);
            this.pnlAttendance.TabIndex = 0;
            this.pnlAttendance.Visible = false;
            // 
            // pnlAttRight
            // 
            this.pnlAttRight.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlAttRight.BorderColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.pnlAttRight.BorderRadius = 20;
            this.pnlAttRight.BorderWidth = 1;
            this.pnlAttRight.GlassEffect = true;
            this.pnlAttRight.GlowBorder = true;
            this.pnlAttRight.GlowColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.pnlAttRight.Controls.Add(this.lblAttTime);
            this.pnlAttRight.Controls.Add(this.lblAttDate);
            this.pnlAttRight.Controls.Add(this.lblAttPosition);
            this.pnlAttRight.Controls.Add(this.lblAttDepartment);
            this.pnlAttRight.Controls.Add(this.lblAttName);
            this.pnlAttRight.Controls.Add(this.picAttPhoto);
            this.pnlAttRight.Controls.Add(this.btnAttClear);
            this.pnlAttRight.Controls.Add(this.btnAttTimeOut);
            this.pnlAttRight.Controls.Add(this.btnAttTimeIn);
            this.pnlAttRight.Controls.Add(this.lblAttResult);
            this.pnlAttRight.DrawBorder = true;
            this.pnlAttRight.Location = new System.Drawing.Point(390, 20);
            this.pnlAttRight.Name = "pnlAttRight";
            this.pnlAttRight.Padding = new System.Windows.Forms.Padding(20);
            this.pnlAttRight.Size = new System.Drawing.Size(710, 420);
            this.pnlAttRight.TabIndex = 1;
            // 

            // 
            // lblAttTime
            // 
            this.lblAttTime.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblAttTime.ForeColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.lblAttTime.Location = new System.Drawing.Point(460, 20);
            this.lblAttTime.Name = "lblAttTime";
            this.lblAttTime.Size = new System.Drawing.Size(220, 40);
            this.lblAttTime.TabIndex = 10;
            this.lblAttTime.Text = "00:00:00";
            this.lblAttTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAttDate
            // 
            this.lblAttDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            this.lblAttDate.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblAttDate.Location = new System.Drawing.Point(460, 60);
            this.lblAttDate.Name = "lblAttDate";
            this.lblAttDate.Size = new System.Drawing.Size(220, 30);
            this.lblAttDate.TabIndex = 9;
            this.lblAttDate.Text = "Monday, January 01, 2026";
            this.lblAttDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAttPosition
            // 
            this.lblAttPosition.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblAttPosition.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblAttPosition.Location = new System.Drawing.Point(120, 168);
            this.lblAttPosition.Name = "lblAttPosition";
            this.lblAttPosition.Size = new System.Drawing.Size(200, 22);
            this.lblAttPosition.TabIndex = 8;
            this.lblAttPosition.Text = "Position";
            this.lblAttPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 

            // 
            // lblAttDepartment
            // 
            this.lblAttDepartment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblAttDepartment.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblAttDepartment.Location = new System.Drawing.Point(120, 146);
            this.lblAttDepartment.Name = "lblAttDepartment";
            this.lblAttDepartment.Size = new System.Drawing.Size(200, 22);
            this.lblAttDepartment.TabIndex = 7;
            this.lblAttDepartment.Text = "Department";
            this.lblAttDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 

            // 
            // lblAttName
            // 
            this.lblAttName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAttName.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblAttName.Location = new System.Drawing.Point(120, 95);
            this.lblAttName.Name = "lblAttName";
            this.lblAttName.Size = new System.Drawing.Size(320, 28);
            this.lblAttName.TabIndex = 6;
            this.lblAttName.Text = "No employee detected";
            this.lblAttName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picAttPhoto
            // 
            this.picAttPhoto.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.picAttPhoto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.picAttPhoto.Location = new System.Drawing.Point(30, 100);
            this.picAttPhoto.Name = "picAttPhoto";
            this.picAttPhoto.Size = new System.Drawing.Size(75, 75);
            this.picAttPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAttPhoto.TabIndex = 5;
            this.picAttPhoto.TabStop = false;
            // 
            // btnAttClear
            // 
            this.btnAttClear.BorderRadius = 10;
            this.btnAttClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAttClear.ForeColor = System.Drawing.Color.White;
            this.btnAttClear.HoverColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnAttClear.Location = new System.Drawing.Point(370, 250);
            this.btnAttClear.Name = "btnAttClear";
            this.btnAttClear.NeonGlow = false;
            this.btnAttClear.NormalColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnAttClear.Size = new System.Drawing.Size(110, 44);
            this.btnAttClear.TabIndex = 4;
            this.btnAttClear.Text = "Clear";
            this.btnAttClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAttTimeOut
            // 
            this.btnAttTimeOut.BorderRadius = 10;
            this.btnAttTimeOut.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAttTimeOut.ForeColor = System.Drawing.Color.White;
            this.btnAttTimeOut.HoverColor = System.Drawing.Color.FromArgb(200, 130, 20);
            this.btnAttTimeOut.Location = new System.Drawing.Point(200, 250);
            this.btnAttTimeOut.Name = "btnAttTimeOut";
            this.btnAttTimeOut.NeonGlow = false;
            this.btnAttTimeOut.NormalColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnAttTimeOut.Size = new System.Drawing.Size(150, 44);
            this.btnAttTimeOut.TabIndex = 3;
            this.btnAttTimeOut.Text = "Time Out";
            this.btnAttTimeOut.Click += new System.EventHandler(this.btnTimeOut_Click);
            // 
            // btnAttTimeIn
            // 
            this.btnAttTimeIn.BorderRadius = 10;
            this.btnAttTimeIn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAttTimeIn.ForeColor = System.Drawing.Color.White;
            this.btnAttTimeIn.HoverColor = System.Drawing.Color.FromArgb(0, 130, 220);
            this.btnAttTimeIn.Location = new System.Drawing.Point(30, 250);
            this.btnAttTimeIn.Name = "btnAttTimeIn";
            this.btnAttTimeIn.NeonGlow = true;
            this.btnAttTimeIn.NormalColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.btnAttTimeIn.Size = new System.Drawing.Size(150, 44);
            this.btnAttTimeIn.TabIndex = 2;
            this.btnAttTimeIn.Text = "Time In";
            this.btnAttTimeIn.Click += new System.EventHandler(this.btnTimeIn_Click);
            // 
            // lblAttResult
            // 
            this.lblAttResult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblAttResult.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblAttResult.Location = new System.Drawing.Point(30, 208);
            this.lblAttResult.Name = "lblAttResult";
            this.lblAttResult.Size = new System.Drawing.Size(460, 30);
            this.lblAttResult.TabIndex = 1;
            this.lblAttResult.Text = "Ready";
            this.lblAttResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fpScanner
            // 
            this.fpScanner.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.fpScanner.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.fpScanner.BorderRadius = 16;
            this.fpScanner.BorderWidth = 2;
            this.fpScanner.DrawBorder = true;
            this.fpScanner.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fpScanner.GlassEffect = false;
            this.fpScanner.GlowBorder = true;
            this.fpScanner.GlowColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.fpScanner.Location = new System.Drawing.Point(30, 20);
            this.fpScanner.Name = "fpScanner";
            this.fpScanner.ScannerState = Demo.Controls.ScannerState.Idle;
            this.fpScanner.Size = new System.Drawing.Size(320, 400);
            this.fpScanner.StatusText = "Place your finger on the scanner";
            // 
            // lblScannerStatus
            // 
            this.lblScannerStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblScannerStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblScannerStatus.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblScannerStatus.Location = new System.Drawing.Point(0, 370);
            this.lblScannerStatus.Name = "lblScannerStatus";
            this.lblScannerStatus.Size = new System.Drawing.Size(320, 22);
            this.lblScannerStatus.TabIndex = 0;
            this.lblScannerStatus.Text = "Place your finger on the scanner";
            this.lblScannerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fpScanner.Controls.Add(this.lblScannerStatus);
            // 
            // pnlRegister
            // 
            this.pnlRegister.AutoScroll = true;
            this.pnlRegister.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlRegister.Controls.Add(this.pnlRegEnroll);
            this.pnlRegister.Controls.Add(this.pnlRegForm);
            this.pnlRegister.Controls.Add(this.pnlRegActions);
            this.pnlRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRegister.Name = "pnlRegister";
            this.pnlRegister.Size = new System.Drawing.Size(1120, 663);
            this.pnlRegister.TabIndex = 1;
            this.pnlRegister.Visible = false;
            // 
            // pnlRegEnroll
            // 
            this.pnlRegEnroll.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlRegEnroll.BorderColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.pnlRegEnroll.BorderRadius = 14;
            this.pnlRegEnroll.BorderWidth = 1;
            this.pnlRegEnroll.GlassEffect = true;
            this.pnlRegEnroll.GlowBorder = true;
            this.pnlRegEnroll.GlowColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.pnlRegEnroll.Controls.Add(this.progressEnroll);
            this.pnlRegEnroll.Controls.Add(this.pnlFpPreview);
            this.pnlRegEnroll.Controls.Add(this.lblQuality);
            this.pnlRegEnroll.Controls.Add(this.lblEnrollStep);
            this.pnlRegEnroll.Controls.Add(this.lblSectionEnroll);
            this.pnlRegEnroll.DrawBorder = true;
            this.pnlRegEnroll.Location = new System.Drawing.Point(540, 0);
            this.pnlRegEnroll.Name = "pnlRegEnroll";
            this.pnlRegEnroll.Size = new System.Drawing.Size(560, 490);
            this.pnlRegEnroll.TabIndex = 2;
            // 
            // progressEnroll
            // 
            this.progressEnroll.ForeColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.progressEnroll.Location = new System.Drawing.Point(28, 390);
            this.progressEnroll.Name = "progressEnroll";
            this.progressEnroll.Size = new System.Drawing.Size(506, 20);
            this.progressEnroll.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressEnroll.TabIndex = 4;
            // 
            // pnlFpPreview
            // 
            this.pnlFpPreview.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlFpPreview.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlFpPreview.BorderRadius = 12;
            this.pnlFpPreview.BorderWidth = 1;
            this.pnlFpPreview.DrawBorder = true;
            this.pnlFpPreview.GlassEffect = false;
            this.pnlFpPreview.GlowBorder = true;
            this.pnlFpPreview.GlowColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.pnlFpPreview.Location = new System.Drawing.Point(28, 56);
            this.pnlFpPreview.Name = "pnlFpPreview";
            this.pnlFpPreview.Size = new System.Drawing.Size(160, 160);
            this.pnlFpPreview.TabIndex = 3;
            // 
            // lblQuality
            // 
            this.lblQuality.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblQuality.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblQuality.Location = new System.Drawing.Point(28, 246);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(506, 30);
            this.lblQuality.TabIndex = 2;
            this.lblQuality.Text = "Fingerprint Quality: Waiting...";
            this.lblQuality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEnrollStep
            // 
            this.lblEnrollStep.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblEnrollStep.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblEnrollStep.Location = new System.Drawing.Point(28, 286);
            this.lblEnrollStep.Name = "lblEnrollStep";
            this.lblEnrollStep.Size = new System.Drawing.Size(506, 40);
            this.lblEnrollStep.TabIndex = 1;
            this.lblEnrollStep.Text = "Press finger 1 of 3";
            this.lblEnrollStep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSectionEnroll
            // 
            this.lblSectionEnroll.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSectionEnroll.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblSectionEnroll.Location = new System.Drawing.Point(28, 20);
            this.lblSectionEnroll.Name = "lblSectionEnroll";
            this.lblSectionEnroll.Size = new System.Drawing.Size(300, 26);
            this.lblSectionEnroll.TabIndex = 0;
            this.lblSectionEnroll.Text = "Fingerprint Enrollment";
            // 
            // pnlRegForm
            // 
            this.pnlRegForm.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlRegForm.BorderColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.pnlRegForm.BorderRadius = 14;
            this.pnlRegForm.BorderWidth = 1;
            this.pnlRegForm.GlassEffect = true;
            this.pnlRegForm.GlowColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.pnlRegForm.Controls.Add(this.txtPhone);
            this.pnlRegForm.Controls.Add(this.txtEmail);
            this.pnlRegForm.Controls.Add(this.txtPosition);
            this.pnlRegForm.Controls.Add(this.txtDepartment);
            this.pnlRegForm.Controls.Add(this.txtLastName);
            this.pnlRegForm.Controls.Add(this.txtMiddleName);
            this.pnlRegForm.Controls.Add(this.txtFirstName);
            this.pnlRegForm.Controls.Add(this.txtEmployeeId);
            this.pnlRegForm.Controls.Add(this.label11);
            this.pnlRegForm.Controls.Add(this.label10);
            this.pnlRegForm.Controls.Add(this.label9);
            this.pnlRegForm.Controls.Add(this.label8);
            this.pnlRegForm.Controls.Add(this.label7);
            this.pnlRegForm.Controls.Add(this.label6);
            this.pnlRegForm.Controls.Add(this.label5);
            this.pnlRegForm.Controls.Add(this.label4);
            this.pnlRegForm.Controls.Add(this.lblSectionInfo);
            this.pnlRegForm.Controls.Add(this.picPhoto);
            this.pnlRegForm.Controls.Add(this.btnUploadPhoto);
            this.pnlRegForm.DrawBorder = true;
            this.pnlRegForm.Location = new System.Drawing.Point(0, 0);
            this.pnlRegForm.Name = "pnlRegForm";
            this.pnlRegForm.Size = new System.Drawing.Size(510, 490);
            this.pnlRegForm.TabIndex = 1;
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.txtPhone.Location = new System.Drawing.Point(118, 380);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(240, 25);
            this.txtPhone.TabIndex = 18;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.txtEmail.Location = new System.Drawing.Point(118, 340);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(240, 25);
            this.txtEmail.TabIndex = 17;
            // 
            // txtPosition
            // 
            this.txtPosition.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPosition.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPosition.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.txtPosition.Location = new System.Drawing.Point(118, 300);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(240, 25);
            this.txtPosition.TabIndex = 16;
            // 
            // txtDepartment
            // 
            this.txtDepartment.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepartment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDepartment.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.txtDepartment.Location = new System.Drawing.Point(118, 260);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(240, 25);
            this.txtDepartment.TabIndex = 15;
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLastName.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.txtLastName.Location = new System.Drawing.Point(118, 220);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(240, 25);
            this.txtLastName.TabIndex = 14;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMiddleName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMiddleName.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.txtMiddleName.Location = new System.Drawing.Point(118, 180);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(240, 25);
            this.txtMiddleName.TabIndex = 13;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFirstName.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.txtFirstName.Location = new System.Drawing.Point(118, 140);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(240, 25);
            this.txtFirstName.TabIndex = 12;
            // 
            // txtEmployeeId
            // 
            this.txtEmployeeId.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtEmployeeId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployeeId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmployeeId.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.txtEmployeeId.Location = new System.Drawing.Point(118, 100);
            this.txtEmployeeId.Name = "txtEmployeeId";
            this.txtEmployeeId.Size = new System.Drawing.Size(240, 25);
            this.txtEmployeeId.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label11.Location = new System.Drawing.Point(32, 378);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 25);
            this.label11.TabIndex = 10;
            this.label11.Text = "Phone";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label10.Location = new System.Drawing.Point(32, 338);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 25);
            this.label10.TabIndex = 9;
            this.label10.Text = "Email";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label9.Location = new System.Drawing.Point(32, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 25);
            this.label9.TabIndex = 8;
            this.label9.Text = "Position";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label8.Location = new System.Drawing.Point(32, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Department";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label7.Location = new System.Drawing.Point(32, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Last Name";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label6.Location = new System.Drawing.Point(32, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Middle Name";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label5.Location = new System.Drawing.Point(32, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "First Name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label4.Location = new System.Drawing.Point(32, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Employee ID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSectionInfo
            // 
            this.lblSectionInfo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSectionInfo.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblSectionInfo.Location = new System.Drawing.Point(30, 20);
            this.lblSectionInfo.Name = "lblSectionInfo";
            this.lblSectionInfo.Size = new System.Drawing.Size(300, 26);
            this.lblSectionInfo.TabIndex = 2;
            this.lblSectionInfo.Text = "Employee Information";
            // 
            // picPhoto
            // 
            this.picPhoto.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPhoto.Location = new System.Drawing.Point(380, 56);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(100, 100);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPhoto.TabIndex = 1;
            this.picPhoto.TabStop = false;
            // 
            // btnUploadPhoto
            // 
            this.btnUploadPhoto.BorderRadius = 10;
            this.btnUploadPhoto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnUploadPhoto.ForeColor = System.Drawing.Color.White;
            this.btnUploadPhoto.HoverColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnUploadPhoto.Location = new System.Drawing.Point(380, 162);
            this.btnUploadPhoto.Name = "btnUploadPhoto";
            this.btnUploadPhoto.NormalColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnUploadPhoto.Size = new System.Drawing.Size(100, 30);
            this.btnUploadPhoto.TabIndex = 0;
            this.btnUploadPhoto.Text = "Upload";
            this.btnUploadPhoto.Click += new System.EventHandler(this.btnUploadPhoto_Click);
            // 
            // pnlRegActions
            // 
            this.pnlRegActions.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlRegActions.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlRegActions.BorderRadius = 14;
            this.pnlRegActions.BorderWidth = 1;
            this.pnlRegActions.Controls.Add(this.btnCancelReg);
            this.pnlRegActions.Controls.Add(this.btnResetReg);
            this.pnlRegActions.Controls.Add(this.btnRegister);
            this.pnlRegActions.DrawBorder = true;
            this.pnlRegActions.Location = new System.Drawing.Point(0, 510);
            this.pnlRegActions.Name = "pnlRegActions";
            this.pnlRegActions.Size = new System.Drawing.Size(1100, 70);
            this.pnlRegActions.TabIndex = 0;
            // 
            // btnCancelReg
            // 
            this.btnCancelReg.BorderRadius = 10;
            this.btnCancelReg.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelReg.ForeColor = System.Drawing.Color.White;
            this.btnCancelReg.HoverColor = System.Drawing.Color.FromArgb(180, 60, 60);
            this.btnCancelReg.Location = new System.Drawing.Point(440, 14);
            this.btnCancelReg.Name = "btnCancelReg";
            this.btnCancelReg.NormalColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnCancelReg.Size = new System.Drawing.Size(150, 44);
            this.btnCancelReg.TabIndex = 2;
            this.btnCancelReg.Text = "Cancel";
            this.btnCancelReg.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnResetReg
            // 
            this.btnResetReg.BorderRadius = 10;
            this.btnResetReg.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnResetReg.ForeColor = System.Drawing.Color.White;
            this.btnResetReg.HoverColor = System.Drawing.Color.FromArgb(180, 130, 20);
            this.btnResetReg.Location = new System.Drawing.Point(240, 14);
            this.btnResetReg.Name = "btnResetReg";
            this.btnResetReg.NormalColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnResetReg.Size = new System.Drawing.Size(150, 44);
            this.btnResetReg.TabIndex = 1;
            this.btnResetReg.Text = "Refresh";
            this.btnResetReg.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BorderRadius = 10;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.HoverColor = System.Drawing.Color.FromArgb(0, 130, 220);
            this.btnRegister.Location = new System.Drawing.Point(40, 14);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.NeonGlow = true;
            this.btnRegister.NormalColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.btnRegister.Size = new System.Drawing.Size(150, 44);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "Register";
            this.btnRegister.Click += new System.EventHandler(this.btnRegisterNew_Click);
            // 
            // pnlHistory
            // 
            this.pnlHistory.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlHistory.Controls.Add(this.dataGridHistory);
            this.pnlHistory.Controls.Add(this.pnlHistoryToolbar);
            this.pnlHistory.Controls.Add(this.lblSectionHistory);
            this.pnlHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(1120, 663);
            this.pnlHistory.TabIndex = 6;
            this.pnlHistory.Visible = false;
            // 
            // dataGridHistory
            // 
            this.dataGridHistory.AllowUserToAddRows = false;
            this.dataGridHistory.AllowUserToDeleteRows = false;
            this.dataGridHistory.AllowUserToResizeRows = false;
            this.dataGridHistory.BackgroundColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dataGridHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridHistory.ColumnHeadersHeight = 40;
            this.dataGridHistory.GridColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.dataGridHistory.Location = new System.Drawing.Point(0, 100);
            this.dataGridHistory.MultiSelect = false;
            this.dataGridHistory.Name = "dataGridHistory";
            this.dataGridHistory.ReadOnly = true;
            this.dataGridHistory.RowHeadersVisible = false;
            this.dataGridHistory.RowTemplate.Height = 36;
            this.dataGridHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridHistory.Size = new System.Drawing.Size(1120, 560);
            this.dataGridHistory.TabIndex = 2;
            // 
            // pnlHistoryToolbar
            // 
            this.pnlHistoryToolbar.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlHistoryToolbar.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlHistoryToolbar.BorderRadius = 14;
            this.pnlHistoryToolbar.BorderWidth = 1;
            this.pnlHistoryToolbar.Controls.Add(this.btnExportCsv);
            this.pnlHistoryToolbar.Controls.Add(this.btnDeleteRecord);
            this.pnlHistoryToolbar.Controls.Add(this.btnRefreshHistory);
            this.pnlHistoryToolbar.Controls.Add(this.txtSearchHistory);
            this.pnlHistoryToolbar.Controls.Add(this.dtpHistoryTo);
            this.pnlHistoryToolbar.Controls.Add(this.dtpHistoryFrom);
            this.pnlHistoryToolbar.Controls.Add(this.label21);
            this.pnlHistoryToolbar.DrawBorder = true;
            this.pnlHistoryToolbar.Location = new System.Drawing.Point(0, 44);
            this.pnlHistoryToolbar.Name = "pnlHistoryToolbar";
            this.pnlHistoryToolbar.Size = new System.Drawing.Size(1120, 48);
            this.pnlHistoryToolbar.TabIndex = 1;
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.BorderRadius = 8;
            this.btnExportCsv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportCsv.ForeColor = System.Drawing.Color.White;
            this.btnExportCsv.HoverColor = System.Drawing.Color.FromArgb(0, 180, 100);
            this.btnExportCsv.Location = new System.Drawing.Point(860, 8);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.NormalColor = System.Drawing.Color.FromArgb(0, 230, 118);
            this.btnExportCsv.Size = new System.Drawing.Size(80, 32);
            this.btnExportCsv.TabIndex = 6;
            this.btnExportCsv.Text = "Export";
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.BorderRadius = 8;
            this.btnDeleteRecord.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteRecord.ForeColor = System.Drawing.Color.White;
            this.btnDeleteRecord.HoverColor = System.Drawing.Color.FromArgb(200, 60, 60);
            this.btnDeleteRecord.Location = new System.Drawing.Point(950, 8);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.NormalColor = System.Drawing.Color.FromArgb(255, 82, 82);
            this.btnDeleteRecord.Size = new System.Drawing.Size(80, 32);
            this.btnDeleteRecord.TabIndex = 5;
            this.btnDeleteRecord.Text = "Delete";
            // 
            // btnRefreshHistory
            // 
            this.btnRefreshHistory.BorderRadius = 8;
            this.btnRefreshHistory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshHistory.ForeColor = System.Drawing.Color.White;
            this.btnRefreshHistory.HoverColor = System.Drawing.Color.FromArgb(0, 130, 220);
            this.btnRefreshHistory.Location = new System.Drawing.Point(1040, 8);
            this.btnRefreshHistory.Name = "btnRefreshHistory";
            this.btnRefreshHistory.NormalColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.btnRefreshHistory.Size = new System.Drawing.Size(60, 32);
            this.btnRefreshHistory.TabIndex = 4;
            this.btnRefreshHistory.Text = "Refresh";
            // 
            // txtSearchHistory
            // 
            this.txtSearchHistory.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtSearchHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearchHistory.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.txtSearchHistory.Location = new System.Drawing.Point(20, 10);
            this.txtSearchHistory.Name = "txtSearchHistory";
            this.txtSearchHistory.Size = new System.Drawing.Size(180, 25);
            this.txtSearchHistory.TabIndex = 3;
            // 
            // dtpHistoryTo
            // 
            this.dtpHistoryTo.CalendarForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.dtpHistoryTo.CalendarMonthBackground = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dtpHistoryTo.CalendarTitleForeColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.dtpHistoryTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHistoryTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHistoryTo.Location = new System.Drawing.Point(310, 10);
            this.dtpHistoryTo.Name = "dtpHistoryTo";
            this.dtpHistoryTo.Size = new System.Drawing.Size(120, 25);
            this.dtpHistoryTo.TabIndex = 2;
            // 
            // dtpHistoryFrom
            // 
            this.dtpHistoryFrom.CalendarForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.dtpHistoryFrom.CalendarMonthBackground = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dtpHistoryFrom.CalendarTitleForeColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.dtpHistoryFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHistoryFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHistoryFrom.Location = new System.Drawing.Point(210, 10);
            this.dtpHistoryFrom.Name = "dtpHistoryFrom";
            this.dtpHistoryFrom.Size = new System.Drawing.Size(90, 25);
            this.dtpHistoryFrom.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.label21.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label21.Location = new System.Drawing.Point(210, 10);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 25);
            this.label21.TabIndex = 0;
            this.label21.Text = "From:          To:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label21.Visible = false;
            // 
            // lblSectionHistory
            // 
            this.lblSectionHistory.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblSectionHistory.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblSectionHistory.Location = new System.Drawing.Point(0, 0);
            this.lblSectionHistory.Name = "lblSectionHistory";
            this.lblSectionHistory.Size = new System.Drawing.Size(300, 44);
            this.lblSectionHistory.TabIndex = 0;
            this.lblSectionHistory.Text = "Attendance History";
            this.lblSectionHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDevice
            // 
            this.pnlDevice.AutoScroll = true;
            this.pnlDevice.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlDevice.Controls.Add(this.pnlDevHealth);
            this.pnlDevice.Controls.Add(this.btnRefreshDevice);
            this.pnlDevice.Controls.Add(this.pnlDevInfo);
            this.pnlDevice.Controls.Add(this.lblSectionDevice);
            this.pnlDevice.Controls.Add(this.pnlDevConnection);
            this.pnlDevice.Controls.Add(this.pnlDevStatus);
            this.pnlDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDevice.Name = "pnlDevice";
            this.pnlDevice.Size = new System.Drawing.Size(1120, 663);
            this.pnlDevice.TabIndex = 2;
            this.pnlDevice.Visible = false;
            // 
            // pnlDevHealth
            // 
            this.pnlDevHealth.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlDevHealth.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlDevHealth.BorderRadius = 14;
            this.pnlDevHealth.BorderWidth = 1;
            this.pnlDevHealth.Controls.Add(this.lblDevHealthLabel);
            this.pnlDevHealth.Controls.Add(this.lblDevHealthValue);
            this.pnlDevHealth.DrawBorder = true;
            this.pnlDevHealth.Location = new System.Drawing.Point(860, 100);
            this.pnlDevHealth.Name = "pnlDevHealth";
            this.pnlDevHealth.Size = new System.Drawing.Size(240, 120);
            this.pnlDevHealth.TabIndex = 5;
            // 
            // lblDevHealthLabel
            // 
            this.lblDevHealthLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblDevHealthLabel.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDevHealthLabel.Location = new System.Drawing.Point(18, 75);
            this.lblDevHealthLabel.Name = "lblDevHealthLabel";
            this.lblDevHealthLabel.Size = new System.Drawing.Size(200, 30);
            this.lblDevHealthLabel.TabIndex = 1;
            this.lblDevHealthLabel.Text = "Device Health";
            this.lblDevHealthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDevHealthValue
            // 
            this.lblDevHealthValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDevHealthValue.ForeColor = System.Drawing.Color.FromArgb(0, 230, 118);
            this.lblDevHealthValue.Location = new System.Drawing.Point(18, 25);
            this.lblDevHealthValue.Name = "lblDevHealthValue";
            this.lblDevHealthValue.Size = new System.Drawing.Size(200, 40);
            this.lblDevHealthValue.TabIndex = 0;
            this.lblDevHealthValue.Text = "Excellent";
            this.lblDevHealthValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRefreshDevice
            // 
            this.btnRefreshDevice.BorderRadius = 10;
            this.btnRefreshDevice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshDevice.ForeColor = System.Drawing.Color.White;
            this.btnRefreshDevice.HoverColor = System.Drawing.Color.FromArgb(0, 130, 220);
            this.btnRefreshDevice.Location = new System.Drawing.Point(20, 440);
            this.btnRefreshDevice.Name = "btnRefreshDevice";
            this.btnRefreshDevice.NeonGlow = false;
            this.btnRefreshDevice.NormalColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.btnRefreshDevice.Size = new System.Drawing.Size(150, 44);
            this.btnRefreshDevice.TabIndex = 4;
            this.btnRefreshDevice.Text = "Refresh";
            this.btnRefreshDevice.Click += new System.EventHandler(this.btnRefreshDevice_Click);
            // 
            // pnlDevInfo
            // 
            this.pnlDevInfo.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlDevInfo.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlDevInfo.BorderRadius = 14;
            this.pnlDevInfo.BorderWidth = 1;
            this.pnlDevInfo.Controls.Add(this.lblDevRegFp);
            this.pnlDevInfo.Controls.Add(this.lblDevRegUsers);
            this.pnlDevInfo.Controls.Add(this.lblDevDbStatus);
            this.pnlDevInfo.Controls.Add(this.lblDevUsb);
            this.pnlDevInfo.Controls.Add(this.lblDevSdkVer);
            this.pnlDevInfo.Controls.Add(this.lblDevReaderModel);
            this.pnlDevInfo.Controls.Add(this.label33);
            this.pnlDevInfo.Controls.Add(this.label32);
            this.pnlDevInfo.Controls.Add(this.label31);
            this.pnlDevInfo.Controls.Add(this.label30);
            this.pnlDevInfo.Controls.Add(this.label29);
            this.pnlDevInfo.Controls.Add(this.label28);
            this.pnlDevInfo.DrawBorder = true;
            this.pnlDevInfo.Location = new System.Drawing.Point(20, 100);
            this.pnlDevInfo.Name = "pnlDevInfo";
            this.pnlDevInfo.Size = new System.Drawing.Size(520, 320);
            this.pnlDevInfo.TabIndex = 2;
            // 
            // lblDevRegFp
            // 
            this.lblDevRegFp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblDevRegFp.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblDevRegFp.Location = new System.Drawing.Point(200, 170);
            this.lblDevRegFp.Name = "lblDevRegFp";
            this.lblDevRegFp.Size = new System.Drawing.Size(300, 22);
            this.lblDevRegFp.TabIndex = 11;
            this.lblDevRegFp.Text = "0";
            this.lblDevRegFp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDevRegUsers
            // 
            this.lblDevRegUsers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblDevRegUsers.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblDevRegUsers.Location = new System.Drawing.Point(200, 135);
            this.lblDevRegUsers.Name = "lblDevRegUsers";
            this.lblDevRegUsers.Size = new System.Drawing.Size(300, 22);
            this.lblDevRegUsers.TabIndex = 10;
            this.lblDevRegUsers.Text = "0";
            this.lblDevRegUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDevDbStatus
            // 
            this.lblDevDbStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblDevDbStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblDevDbStatus.Location = new System.Drawing.Point(200, 100);
            this.lblDevDbStatus.Name = "lblDevDbStatus";
            this.lblDevDbStatus.Size = new System.Drawing.Size(300, 22);
            this.lblDevDbStatus.TabIndex = 9;
            this.lblDevDbStatus.Text = "Not initialized";
            this.lblDevDbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDevUsb
            // 
            this.lblDevUsb.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblDevUsb.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblDevUsb.Location = new System.Drawing.Point(200, 65);
            this.lblDevUsb.Name = "lblDevUsb";
            this.lblDevUsb.Size = new System.Drawing.Size(300, 22);
            this.lblDevUsb.TabIndex = 8;
            this.lblDevUsb.Text = "Disconnected";
            this.lblDevUsb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDevSdkVer
            // 
            this.lblDevSdkVer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblDevSdkVer.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblDevSdkVer.Location = new System.Drawing.Point(200, 30);
            this.lblDevSdkVer.Name = "lblDevSdkVer";
            this.lblDevSdkVer.Size = new System.Drawing.Size(300, 22);
            this.lblDevSdkVer.TabIndex = 7;
            this.lblDevSdkVer.Text = "ZKFinger 5.3.0.33";
            this.lblDevSdkVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDevReaderModel
            // 
            this.lblDevReaderModel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblDevReaderModel.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblDevReaderModel.Location = new System.Drawing.Point(200, 240);
            this.lblDevReaderModel.Name = "lblDevReaderModel";
            this.lblDevReaderModel.Size = new System.Drawing.Size(300, 22);
            this.lblDevReaderModel.TabIndex = 6;
            this.lblDevReaderModel.Text = "N/A";
            this.lblDevReaderModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label33.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label33.Location = new System.Drawing.Point(28, 240);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(160, 22);
            this.label33.TabIndex = 5;
            this.label33.Text = "Reader Model:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label32.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label32.Location = new System.Drawing.Point(28, 170);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(160, 22);
            this.label32.TabIndex = 4;
            this.label32.Text = "Registered FP:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label31.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label31.Location = new System.Drawing.Point(28, 135);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(160, 22);
            this.label31.TabIndex = 3;
            this.label31.Text = "Registered Users:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label30.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label30.Location = new System.Drawing.Point(28, 100);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(160, 22);
            this.label30.TabIndex = 2;
            this.label30.Text = "Database Status:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label29.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label29.Location = new System.Drawing.Point(28, 65);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(160, 22);
            this.label29.TabIndex = 1;
            this.label29.Text = "USB Connection:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label28.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label28.Location = new System.Drawing.Point(28, 30);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(160, 22);
            this.label28.TabIndex = 0;
            this.label28.Text = "SDK Version:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSectionDevice
            // 
            this.lblSectionDevice.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblSectionDevice.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblSectionDevice.Location = new System.Drawing.Point(0, 0);
            this.lblSectionDevice.Name = "lblSectionDevice";
            this.lblSectionDevice.Size = new System.Drawing.Size(300, 44);
            this.lblSectionDevice.TabIndex = 0;
            this.lblSectionDevice.Text = "Device";
            this.lblSectionDevice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDevConnection
            // 
            this.pnlDevConnection.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlDevConnection.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlDevConnection.BorderRadius = 14;
            this.pnlDevConnection.BorderWidth = 1;
            this.pnlDevConnection.Controls.Add(this.lblDevConnectionStatus);
            this.pnlDevConnection.Controls.Add(this.lblDevConnectionLabel);
            this.pnlDevConnection.DrawBorder = true;
            this.pnlDevConnection.Location = new System.Drawing.Point(580, 100);
            this.pnlDevConnection.Name = "pnlDevConnection";
            this.pnlDevConnection.Size = new System.Drawing.Size(240, 120);
            this.pnlDevConnection.TabIndex = 1;
            // 
            // lblDevConnectionStatus
            // 
            this.lblDevConnectionStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDevConnectionStatus.ForeColor = System.Drawing.Color.FromArgb(255, 82, 82);
            this.lblDevConnectionStatus.Location = new System.Drawing.Point(25, 25);
            this.lblDevConnectionStatus.Name = "lblDevConnectionStatus";
            this.lblDevConnectionStatus.Size = new System.Drawing.Size(190, 35);
            this.lblDevConnectionStatus.TabIndex = 1;
            this.lblDevConnectionStatus.Text = "Disconnected";
            this.lblDevConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDevConnectionLabel
            // 
            this.lblDevConnectionLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblDevConnectionLabel.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDevConnectionLabel.Location = new System.Drawing.Point(25, 75);
            this.lblDevConnectionLabel.Name = "lblDevConnectionLabel";
            this.lblDevConnectionLabel.Size = new System.Drawing.Size(190, 30);
            this.lblDevConnectionLabel.TabIndex = 0;
            this.lblDevConnectionLabel.Text = "Connection Status";
            this.lblDevConnectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDevStatus
            // 
            this.pnlDevStatus.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlDevStatus.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlDevStatus.BorderRadius = 14;
            this.pnlDevStatus.BorderWidth = 1;
            this.pnlDevStatus.Controls.Add(this.lblDevStatusText);
            this.pnlDevStatus.Controls.Add(this.lblDevStatusLabel);
            this.pnlDevStatus.DrawBorder = true;
            this.pnlDevStatus.Location = new System.Drawing.Point(580, 240);
            this.pnlDevStatus.Name = "pnlDevStatus";
            this.pnlDevStatus.Size = new System.Drawing.Size(520, 120);
            this.pnlDevStatus.TabIndex = 3;
            // 
            // lblDevStatusText
            // 
            this.lblDevStatusText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDevStatusText.ForeColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.lblDevStatusText.Location = new System.Drawing.Point(25, 25);
            this.lblDevStatusText.Name = "lblDevStatusText";
            this.lblDevStatusText.Size = new System.Drawing.Size(470, 35);
            this.lblDevStatusText.TabIndex = 1;
            this.lblDevStatusText.Text = "Online";
            this.lblDevStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDevStatusLabel
            // 
            this.lblDevStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblDevStatusLabel.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDevStatusLabel.Location = new System.Drawing.Point(25, 75);
            this.lblDevStatusLabel.Name = "lblDevStatusLabel";
            this.lblDevStatusLabel.Size = new System.Drawing.Size(470, 30);
            this.lblDevStatusLabel.TabIndex = 0;
            this.lblDevStatusLabel.Text = "Device is operating normally";
            this.lblDevStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlSettings.Controls.Add(this.pnlSettingsAbout);
            this.pnlSettings.Controls.Add(this.pnlSettingsAppearance);
            this.pnlSettings.Controls.Add(this.lblSectionSettings);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(1120, 663);
            this.pnlSettings.TabIndex = 3;
            this.pnlSettings.Visible = false;
            // 
            // pnlSettingsAbout
            // 
            this.pnlSettingsAbout.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlSettingsAbout.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlSettingsAbout.BorderRadius = 14;
            this.pnlSettingsAbout.BorderWidth = 1;
            this.pnlSettingsAbout.Controls.Add(this.lblAbout);
            this.pnlSettingsAbout.Controls.Add(this.label20);
            this.pnlSettingsAbout.DrawBorder = true;
            this.pnlSettingsAbout.Location = new System.Drawing.Point(0, 260);
            this.pnlSettingsAbout.Name = "pnlSettingsAbout";
            this.pnlSettingsAbout.Size = new System.Drawing.Size(500, 160);
            this.pnlSettingsAbout.TabIndex = 2;
            // 
            // lblAbout
            // 
            this.lblAbout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblAbout.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblAbout.Location = new System.Drawing.Point(28, 60);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(440, 70);
            this.lblAbout.TabIndex = 1;
            this.lblAbout.Text = "BioClock - Biometric Attendance System\nVersion 2.0\nPowered by ZKFinger Standard SDK 5.3.0.33";
            this.lblAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.label20.Location = new System.Drawing.Point(28, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(200, 30);
            this.label20.TabIndex = 0;
            this.label20.Text = "About System";
            // 
            // pnlSettingsAppearance
            // 
            this.pnlSettingsAppearance.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlSettingsAppearance.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlSettingsAppearance.BorderRadius = 14;
            this.pnlSettingsAppearance.BorderWidth = 1;
            this.pnlSettingsAppearance.Controls.Add(this.chkAnimations);
            this.pnlSettingsAppearance.Controls.Add(this.cmbTheme);
            this.pnlSettingsAppearance.Controls.Add(this.label19);
            this.pnlSettingsAppearance.DrawBorder = true;
            this.pnlSettingsAppearance.Location = new System.Drawing.Point(0, 100);
            this.pnlSettingsAppearance.Name = "pnlSettingsAppearance";
            this.pnlSettingsAppearance.Size = new System.Drawing.Size(500, 140);
            this.pnlSettingsAppearance.TabIndex = 1;
            // 
            // chkAnimations
            // 
            this.chkAnimations.Checked = true;
            this.chkAnimations.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAnimations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.chkAnimations.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.chkAnimations.Location = new System.Drawing.Point(28, 70);
            this.chkAnimations.Name = "chkAnimations";
            this.chkAnimations.Size = new System.Drawing.Size(160, 25);
            this.chkAnimations.TabIndex = 2;
            this.chkAnimations.Text = "Enable Animations";
            this.chkAnimations.UseVisualStyleBackColor = true;
            this.chkAnimations.CheckedChanged += new System.EventHandler(this.chkAnimations_CheckedChanged);
            // 
            // cmbTheme
            // 
            this.cmbTheme.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.cmbTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTheme.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTheme.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.cmbTheme.Items.AddRange(new object[] { "Cyber Blue", "Dark", "Light" });
            this.cmbTheme.Location = new System.Drawing.Point(120, 30);
            this.cmbTheme.Name = "cmbTheme";
            this.cmbTheme.Size = new System.Drawing.Size(160, 25);
            this.cmbTheme.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label19.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label19.Location = new System.Drawing.Point(28, 28);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 25);
            this.label19.TabIndex = 0;
            this.label19.Text = "Theme:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSectionSettings
            // 
            this.lblSectionSettings.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblSectionSettings.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblSectionSettings.Location = new System.Drawing.Point(0, 0);
            this.lblSectionSettings.Name = "lblSectionSettings";
            this.lblSectionSettings.Size = new System.Drawing.Size(300, 44);
            this.lblSectionSettings.TabIndex = 0;
            this.lblSectionSettings.Text = "Settings";
            this.lblSectionSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlTopBar.Controls.Add(this.lblTopConnDot);
            this.pnlTopBar.Controls.Add(this.lblTopConnStatus);
            this.pnlTopBar.Controls.Add(this.lblTopDate);
            this.pnlTopBar.Controls.Add(this.lblTopClock);
            this.pnlTopBar.Controls.Add(this.lblTopTitle);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1160, 65);
            this.pnlTopBar.TabIndex = 0;
            // 
            // lblTopConnDot
            // 
            this.lblTopConnDot.BackColor = System.Drawing.Color.FromArgb(255, 82, 82);
            this.lblTopConnDot.Location = new System.Drawing.Point(1020, 26);
            this.lblTopConnDot.Name = "lblTopConnDot";
            this.lblTopConnDot.Size = new System.Drawing.Size(12, 12);
            this.lblTopConnDot.TabIndex = 4;
            // 
            // lblTopConnStatus
            // 
            this.lblTopConnStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblTopConnStatus.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblTopConnStatus.Location = new System.Drawing.Point(1038, 20);
            this.lblTopConnStatus.Name = "lblTopConnStatus";
            this.lblTopConnStatus.Size = new System.Drawing.Size(110, 25);
            this.lblTopConnStatus.TabIndex = 3;
            this.lblTopConnStatus.Text = "Disconnected";
            this.lblTopConnStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTopDate
            // 
            this.lblTopDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblTopDate.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblTopDate.Location = new System.Drawing.Point(620, 36);
            this.lblTopDate.Name = "lblTopDate";
            this.lblTopDate.Size = new System.Drawing.Size(300, 20);
            this.lblTopDate.TabIndex = 2;
            this.lblTopDate.Text = "Monday, January 01, 2026";
            this.lblTopDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTopClock
            // 
            this.lblTopClock.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTopClock.ForeColor = System.Drawing.Color.FromArgb(0, 163, 255);
            this.lblTopClock.Location = new System.Drawing.Point(620, 8);
            this.lblTopClock.Name = "lblTopClock";
            this.lblTopClock.Size = new System.Drawing.Size(300, 34);
            this.lblTopClock.TabIndex = 1;
            this.lblTopClock.Text = "00:00:00";
            this.lblTopClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTopTitle
            // 
            this.lblTopTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTopTitle.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblTopTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTopTitle.Name = "lblTopTitle";
            this.lblTopTitle.Size = new System.Drawing.Size(500, 38);
            this.lblTopTitle.TabIndex = 0;
            this.lblTopTitle.Text = "Biometric Attendance System";
            this.lblTopTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlStatusBar
            // 
            this.pnlStatusBar.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlStatusBar.Controls.Add(this.lblFpCount);
            this.pnlStatusBar.Controls.Add(this.lblDbStatus);
            this.pnlStatusBar.Controls.Add(this.lblConnectionStatus);
            this.pnlStatusBar.Controls.Add(this.lblSdkStatus);
            this.pnlStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatusBar.Name = "pnlStatusBar";
            this.pnlStatusBar.Size = new System.Drawing.Size(1160, 32);
            this.pnlStatusBar.TabIndex = 1;
            // 
            // lblFpCount
            // 
            this.lblFpCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblFpCount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblFpCount.Location = new System.Drawing.Point(680, 6);
            this.lblFpCount.Name = "lblFpCount";
            this.lblFpCount.Size = new System.Drawing.Size(200, 20);
            this.lblFpCount.TabIndex = 3;
            this.lblFpCount.Text = "Fingerprints: 0";
            this.lblFpCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDbStatus
            // 
            this.lblDbStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblDbStatus.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDbStatus.Location = new System.Drawing.Point(460, 6);
            this.lblDbStatus.Name = "lblDbStatus";
            this.lblDbStatus.Size = new System.Drawing.Size(220, 20);
            this.lblDbStatus.TabIndex = 2;
            this.lblDbStatus.Text = "Database: Not initialized";
            this.lblDbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblConnectionStatus.Location = new System.Drawing.Point(240, 6);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(220, 20);
            this.lblConnectionStatus.TabIndex = 1;
            this.lblConnectionStatus.Text = "Device: Disconnected";
            this.lblConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSdkStatus
            // 
            this.lblSdkStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblSdkStatus.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSdkStatus.Location = new System.Drawing.Point(20, 6);
            this.lblSdkStatus.Name = "lblSdkStatus";
            this.lblSdkStatus.Size = new System.Drawing.Size(220, 20);
            this.lblSdkStatus.TabIndex = 0;
            this.lblSdkStatus.Text = "SDK: Not initialized";
            this.lblSdkStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSidebarDivider
            // 
            this.pnlSidebarDivider.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlSidebarDivider.Location = new System.Drawing.Point(20, 96);
            this.pnlSidebarDivider.Name = "pnlSidebarDivider";
            this.pnlSidebarDivider.Size = new System.Drawing.Size(200, 1);
            this.pnlSidebarDivider.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.pnlMainArea);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.bnInit);
            this.Controls.Add(this.bnOpen);
            this.Controls.Add(this.bnEnroll);
            this.Controls.Add(this.bnVerify);
            this.Controls.Add(this.bnFree);
            this.Controls.Add(this.bnClose);
            this.Controls.Add(this.bnIdentify);
            this.Controls.Add(this.textRes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbIdx);
            this.Controls.Add(this.picFPImg);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BioClock - Biometric Attendance System";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFPImg)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlMainArea.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlDashboard.ResumeLayout(false);
            this.pnlDashFpCount.ResumeLayout(false);
            this.pnlDashEmployees.ResumeLayout(false);
            this.pnlDashToday.ResumeLayout(false);
            this.pnlDashDevice.ResumeLayout(false);
            this.pnlAttendance.ResumeLayout(false);
            this.pnlAttRight.ResumeLayout(false);
            this.fpScanner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAttPhoto)).EndInit();
            this.pnlRegister.ResumeLayout(false);
            this.pnlRegEnroll.ResumeLayout(false);
            this.pnlFpPreview.ResumeLayout(false);
            this.pnlRegForm.ResumeLayout(false);
            this.pnlRegForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.pnlRegActions.ResumeLayout(false);
            this.pnlHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistory)).EndInit();
            this.pnlHistoryToolbar.ResumeLayout(false);
            this.pnlHistoryToolbar.PerformLayout();
            this.pnlDevice.ResumeLayout(false);
            this.pnlDevHealth.ResumeLayout(false);
            this.pnlDevInfo.ResumeLayout(false);
            this.pnlDevConnection.ResumeLayout(false);
            this.pnlDevStatus.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettingsAbout.ResumeLayout(false);
            this.pnlSettingsAppearance.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlStatusBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button bnInit;
        private System.Windows.Forms.Button bnOpen;
        private System.Windows.Forms.Button bnEnroll;
        private System.Windows.Forms.Button bnVerify;
        private System.Windows.Forms.Button bnFree;
        private System.Windows.Forms.Button bnClose;
        private System.Windows.Forms.Button bnIdentify;
        private System.Windows.Forms.TextBox textRes;
        private System.Windows.Forms.PictureBox picFPImg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbIdx;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlMainArea;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Panel pnlStatusBar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlSidebarDivider;
        private System.Windows.Forms.Label lblAppLogo;
        private System.Windows.Forms.Label lblLogoSub;
        private Controls.NavigationButton btnNavDashboard;
        private Controls.NavigationButton btnNavAttendance;
        private Controls.NavigationButton btnNavRegister;
        private Controls.NavigationButton btnNavHistory;
        private Controls.NavigationButton btnNavDevice;
        private Controls.NavigationButton btnNavSettings;
        private System.Windows.Forms.Label lblTopTitle;
        private System.Windows.Forms.Label lblTopClock;
        private System.Windows.Forms.Label lblTopDate;
        private System.Windows.Forms.Label lblTopConnStatus;
        private System.Windows.Forms.Label lblTopConnDot;
        private System.Windows.Forms.Label lblSdkStatus;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Label lblDbStatus;
        private System.Windows.Forms.Label lblFpCount;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Label lblDashTitle;
        private System.Windows.Forms.Label lblDashSubtitle;
        private Controls.RoundedPanel pnlDashFpCount;
        private System.Windows.Forms.Label lblDashFpCountValue;
        private System.Windows.Forms.Label lblDashFpCountLabel;
        private Controls.RoundedPanel pnlDashEmployees;
        private System.Windows.Forms.Label lblDashEmpValue;
        private System.Windows.Forms.Label lblDashEmpLabel;
        private Controls.RoundedPanel pnlDashToday;
        private System.Windows.Forms.Label lblDashTodayValue;
        private System.Windows.Forms.Label lblDashTodayLabel;
        private Controls.RoundedPanel pnlDashDevice;
        private System.Windows.Forms.Label lblDashDeviceValue;
        private System.Windows.Forms.Label lblDashDeviceLabel;
        private Controls.FingerprintPanel fpScanner;
        private System.Windows.Forms.Panel pnlAttendance;
        private Controls.RoundedPanel pnlAttRight;
        private System.Windows.Forms.Label lblAttResult;
        private System.Windows.Forms.Label lblScannerStatus;
        private Controls.RoundedButton btnAttTimeIn;
        private Controls.RoundedButton btnAttTimeOut;
        private Controls.RoundedButton btnAttClear;
        private System.Windows.Forms.PictureBox picAttPhoto;
        private System.Windows.Forms.Label lblAttName;
        private System.Windows.Forms.Label lblAttDepartment;
        private System.Windows.Forms.Label lblAttPosition;
        private System.Windows.Forms.Label lblAttDate;
        private System.Windows.Forms.Label lblAttTime;
        private System.Windows.Forms.Panel pnlRegister;
        private Controls.RoundedPanel pnlRegForm;
        private System.Windows.Forms.Label lblSectionInfo;
        private System.Windows.Forms.PictureBox picPhoto;
        private Controls.RoundedButton btnUploadPhoto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEmployeeId;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private Controls.RoundedPanel pnlRegEnroll;
        private System.Windows.Forms.Label lblSectionEnroll;
        private System.Windows.Forms.Label lblEnrollStep;
        private System.Windows.Forms.Label lblQuality;
        private Controls.RoundedPanel pnlFpPreview;
        private System.Windows.Forms.ProgressBar progressEnroll;
        private Controls.RoundedPanel pnlRegActions;
        private Controls.RoundedButton btnRegister;
        private Controls.RoundedButton btnResetReg;
        private Controls.RoundedButton btnCancelReg;
        private System.Windows.Forms.Panel pnlHistory;
        private System.Windows.Forms.Label lblSectionHistory;
        private Controls.RoundedPanel pnlHistoryToolbar;
        private System.Windows.Forms.DateTimePicker dtpHistoryFrom;
        private System.Windows.Forms.DateTimePicker dtpHistoryTo;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtSearchHistory;
        private Controls.RoundedButton btnRefreshHistory;
        private Controls.RoundedButton btnDeleteRecord;
        private Controls.RoundedButton btnExportCsv;
        private System.Windows.Forms.DataGridView dataGridHistory;
        private System.Windows.Forms.Panel pnlDevice;
        private System.Windows.Forms.Label lblSectionDevice;
        private Controls.RoundedPanel pnlDevConnection;
        private System.Windows.Forms.Label lblDevConnectionLabel;
        private System.Windows.Forms.Label lblDevConnectionStatus;
        private Controls.RoundedPanel pnlDevInfo;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label lblDevReaderModel;
        private System.Windows.Forms.Label lblDevSdkVer;
        private System.Windows.Forms.Label lblDevUsb;
        private System.Windows.Forms.Label lblDevDbStatus;
        private System.Windows.Forms.Label lblDevRegUsers;
        private System.Windows.Forms.Label lblDevRegFp;
        private Controls.RoundedButton btnRefreshDevice;
        private Controls.RoundedPanel pnlDevStatus;
        private System.Windows.Forms.Label lblDevStatusLabel;
        private System.Windows.Forms.Label lblDevStatusText;
        private Controls.RoundedPanel pnlDevHealth;
        private System.Windows.Forms.Label lblDevHealthLabel;
        private System.Windows.Forms.Label lblDevHealthValue;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Label lblSectionSettings;
        private Controls.RoundedPanel pnlSettingsAppearance;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbTheme;
        private System.Windows.Forms.CheckBox chkAnimations;
        private Controls.RoundedPanel pnlSettingsAbout;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Timer timerAnimation;
    }
}
