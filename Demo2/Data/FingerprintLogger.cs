using System;
using System.IO;
using System.Windows.Forms;

namespace Demo.Data
{
    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }

    public static class FingerprintLogger
    {
        private static readonly string _logPath;
        private static readonly object _lock = new object();
        private const long MaxSize = 1024 * 1024;

        static FingerprintLogger()
        {
            _logPath = Path.Combine(Application.StartupPath, "fingerprint_error.log");
        }

        public static void Info(string message)
        {
            Write(LogLevel.Info, message);
        }

        public static void Warning(string message)
        {
            Write(LogLevel.Warning, message);
        }

        public static void Error(string message)
        {
            Write(LogLevel.Error, message);
        }

        public static void Error(string message, Exception ex)
        {
            Write(LogLevel.Error, message + " | Exception: " + ex.Message + " | StackTrace: " + ex.StackTrace);
        }

        public static void SdkError(string context, int retCode)
        {
            string errorName = GetSdkErrorName(retCode);
            Write(LogLevel.Error, string.Format("SDK | {0} | ret={1} ({2})", context, retCode, errorName));
        }

        public static void SdkError(string context, IntPtr handle, string detail)
        {
            Write(LogLevel.Error, string.Format("SDK | {0} | handle=0x{1:X8} | {2}", context, handle.ToInt32(), detail));
        }

        private static void Write(LogLevel level, string message)
        {
            lock (_lock)
            {
                try
                {
                    string line = string.Format("{0:yyyy-MM-dd HH:mm:ss.fff} [{1,-7}] {2}",
                        DateTime.Now, level, message);

                    if (File.Exists(_logPath) && new FileInfo(_logPath).Length > MaxSize)
                        Rotate();

                    using (StreamWriter w = File.AppendText(_logPath))
                        w.WriteLine(line);
                }
                catch
                {
                }
            }
        }

        private static void Rotate()
        {
            string dir = Path.GetDirectoryName(_logPath);
            string name = Path.GetFileNameWithoutExtension(_logPath);
            string ext = Path.GetExtension(_logPath);
            string backup = Path.Combine(dir, name + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ext);
            try
            {
                File.Move(_logPath, backup);
            }
            catch
            {
            }
        }

        private static string GetSdkErrorName(int ret)
        {
            switch (ret)
            {
                case 0: return "ZKFP_ERR_OK";
                case 1: return "ZKFP_ERR_FAIL";
                case 2: return "ZKFP_ERR_INVALID_HANDLE";
                case 3: return "ZKFP_ERR_INVALID_PARAM";
                case 4: return "ZKFP_ERR_NO_DEVICE";
                case 5: return "ZKFP_ERR_NOT_OPEN";
                case 6: return "ZKFP_ERR_NOT_SUPPORTED";
                case 7: return "ZKFP_ERR_NO_TEMPLATE";
                case 8: return "ZKFP_ERR_BUFFER_TOO_SMALL";
                case 9: return "ZKFP_ERR_EXIST";
                case 10: return "ZKFP_ERR_NOT_EXIST";
                case 11: return "ZKFP_ERR_TIMEOUT";
                case 12: return "ZKFP_ERR_DEVICE_BUSY";
                case 13: return "ZKFP_ERR_INVALID_IMAGE";
                case 14: return "ZKFP_ERR_NO_FINGER";
                case 15: return "ZKFP_ERR_CANCEL";
                case 16: return "ZKFP_ERR_VERIFY";
                case 17: return "ZKFP_ERR_IDENTIFY";
                case 18: return "ZKFP_ERR_ENROLL";
                case 19: return "ZKFP_ERR_EXTRACT";
                case 20: return "ZKFP_ERR_MERGE";
                case 21: return "ZKFP_ERR_DUPLICATE";
                case 22: return "ZKFP_ERR_EMPTY";
                case 23: return "ZKFP_ERR_ALLOC";
                case 24: return "ZKFP_ERR_ACCESS";
                case 25: return "ZKFP_ERR_DB_FULL";
                default: return "UNKNOWN_" + ret;
            }
        }
    }
}
