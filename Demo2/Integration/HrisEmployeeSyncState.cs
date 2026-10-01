using System.IO;
using System.Windows.Forms;

namespace Demo.Integration
{
    /// <summary>
    /// Remembers the last-applied employee list version so the heartbeat does not
    /// re-download and re-merge the full employee list when nothing changed.
    /// Mirrors the persistence pattern used for the agent identity: a tiny file
    /// under data/ that survives restarts.
    /// </summary>
    public static class HrisEmployeeSyncState
    {
        private static readonly string FilePath = Path.Combine(Path.Combine(Application.StartupPath, "data"), "employees_sync_version.txt");

        public static string Load()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string version = File.ReadAllText(FilePath).Trim();
                    if (version.Length > 0) return version;
                }
            }
            catch
            {
            }
            return null;
        }

        public static void Save(string version)
        {
            try
            {
                string dir = Path.GetDirectoryName(FilePath);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                File.WriteAllText(FilePath, version);
            }
            catch
            {
            }
        }
    }
}