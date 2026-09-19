using System;
using System.IO;
using System.Windows.Forms;

namespace Demo.Integration
{
    /// <summary>
    /// HRIS connection settings, loaded from hris.config next to the exe.
    /// Never hard-coded; a local file so the server can be pointed at a LAN
    /// IP or production HTTPS domain without recompiling.
    /// </summary>
    public class HrisConfig
    {
        public const string DefaultBaseUrl = "http://127.0.0.1:8000/api";
        public const string DefaultToken = "hris-device-token";
        public const int DefaultRetryAttempts = 10;
        public const int DefaultHeartbeatIntervalSeconds = 10;

        private static readonly string FilePath = Path.Combine(Application.StartupPath, "hris.config");

        public string ApiBaseUrl { get; set; }
        public string ApiToken { get; set; }
        public int RetryAttempts { get; set; }
        public int HeartbeatIntervalSeconds { get; set; }

        public HrisConfig()
        {
            ApiBaseUrl = DefaultBaseUrl;
            ApiToken = DefaultToken;
            RetryAttempts = DefaultRetryAttempts;
            HeartbeatIntervalSeconds = DefaultHeartbeatIntervalSeconds;
        }

        public static HrisConfig Load()
        {
            HrisConfig cfg = new HrisConfig();
            try
            {
                if (File.Exists(FilePath))
                {
                    foreach (string raw in File.ReadAllLines(FilePath))
                    {
                        string line = raw.Trim();
                        if (line.Length == 0 || line.StartsWith("#") || line.StartsWith(";")) continue;
                        int sep = line.IndexOf('=');
                        if (sep <= 0) continue;
                        string key = line.Substring(0, sep).Trim();
                        string value = line.Substring(sep + 1).Trim();
                        if (key == "ApiBaseUrl" && value.Length > 0) cfg.ApiBaseUrl = value;
                        else if (key == "ApiToken" && value.Length > 0) cfg.ApiToken = value;
                        else if (key == "RetryAttempts") { int n; if (int.TryParse(value, out n) && n > 0) cfg.RetryAttempts = n; }
                        else if (key == "HeartbeatIntervalSeconds") { int n; if (int.TryParse(value, out n) && n > 0) cfg.HeartbeatIntervalSeconds = n; }
                    }
                }
                else
                {
                    // First run: write the default config file so the admin
                    // edits hris.config once instead of the source.
                    string template = "# HRIS biometric agent connection settings\n"
                        + "ApiBaseUrl=" + DefaultBaseUrl + "\n"
                        + "ApiToken=" + DefaultToken + "\n"
                        + "RetryAttempts=" + DefaultRetryAttempts + "\n"
                        + "HeartbeatIntervalSeconds=" + DefaultHeartbeatIntervalSeconds + "\n";
                    File.WriteAllText(FilePath, template);
                }
            }
            catch
            {
                // Fall back to defaults if the file is unreadable.
            }
            return cfg;
        }
    }
}