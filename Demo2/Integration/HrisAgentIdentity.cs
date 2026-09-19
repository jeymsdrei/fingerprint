using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Demo.Integration
{
    /// <summary>
    /// Stable agent identity that survives restarts. Generated once at first
    /// run and persisted to data/agent.txt. The computer name alone is not
    /// stable enough (renames/duplicates) so it is only used as a label.
    /// </summary>
    public static class HrisAgentIdentity
    {
        private static readonly string FilePath = Path.Combine(Path.Combine(Application.StartupPath, "data"), "agent.txt");

        public static string LoadOrCreate()
        {
            try
            {
                string dir = Path.GetDirectoryName(FilePath);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                if (File.Exists(FilePath))
                {
                    string existing = File.ReadAllText(FilePath).Trim();
                    if (existing.Length >= 8) return existing;
                }

                string agentId = NewAgentId();
                File.WriteAllText(FilePath, agentId);
                return agentId;
            }
            catch
            {
                // Fall back to a derived id rather than failing the app.
                return NewAgentId();
            }
        }

        public static string ComputerName
        {
            get
            {
                try { return Environment.MachineName; }
                catch { return "UNKNOWN"; }
            }
        }

        private static string NewAgentId()
        {
            string seed = Guid.NewGuid().ToString("N") + "|" + Environment.MachineName;
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(seed));
                StringBuilder sb = new StringBuilder(24);
                sb.Append("AG-");
                for (int i = 0; i < hash.Length && sb.Length < 24; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}