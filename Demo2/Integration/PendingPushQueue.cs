using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Demo.Integration
{
    /// <summary>
    /// A punch waiting to be pushed to the HRIS once connectivity returns.
    /// </summary>
    [Serializable]
    public class PendingPush
    {
        public int FingerprintID { get; set; }
        public DateTime PunchTime { get; set; }
        public string SourceKey { get; set; }
        public string Action { get; set; }
        public int Attempts { get; set; }
        public DateTime AddedAt { get; set; }
    }

    /// <summary>
    /// Offline queue that survives restarts (persisted to
    /// data/pending_push.xml). Records are only removed after the HRIS
    /// confirms them; already-synced records are never re-pushed because the
    /// SourceKey is stable.
    /// </summary>
    public class PendingPushQueue
    {
        private static readonly string FilePath = Path.Combine(Path.Combine(Application.StartupPath, "data"), "pending_push.xml");

        private readonly List<PendingPush> _items;
        private readonly object _lock = new object();

        public PendingPushQueue()
        {
            _items = new List<PendingPush>();
        }

        public int Count
        {
            get { lock (_lock) { return _items.Count; } }
        }

        public List<PendingPush> Snapshot()
        {
            lock (_lock) { return new List<PendingPush>(_items); }
        }

        public void Load()
        {
            try
            {
                if (!File.Exists(FilePath)) return;
                using (FileStream fs = File.OpenRead(FilePath))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<PendingPush>));
                    List<PendingPush> loaded = (List<PendingPush>)xs.Deserialize(fs);
                    if (loaded == null) return;
                    lock (_lock)
                    {
                        _items.Clear();
                        _items.AddRange(loaded);
                    }
                }
            }
            catch
            {
                // A corrupt queue must not prevent the app from starting.
            }
        }

        public void Enqueue(PendingPush item)
        {
            lock (_lock)
            {
                // Never duplicate by source key (a restart must not re-push).
                if (_items.Exists(p => p.SourceKey == item.SourceKey)) return;
                _items.Add(item);
                Save();
            }
        }

        /// <summary>
        /// Increments the stored attempt count for the given source keys
        /// (persisted so retries survive restarts).
        /// </summary>
        public void IncrementAttempts(HashSet<string> sourceKeys)
        {
            if (sourceKeys == null || sourceKeys.Count == 0) return;
            lock (_lock)
            {
                foreach (PendingPush p in _items)
                {
                    if (sourceKeys.Contains(p.SourceKey)) p.Attempts++;
                }
                Save();
            }
        }

        /// <summary>
        /// Removes records whose SourceKey matches the given set after the
        /// HRIS confirmed them.
        /// </summary>
        public void RemoveConfirmed(HashSet<string> confirmedKeys)
        {
            if (confirmedKeys == null || confirmedKeys.Count == 0) return;
            lock (_lock)
            {
                _items.RemoveAll(p => confirmedKeys.Contains(p.SourceKey));
                Save();
            }
        }

        private void Save()
        {
            try
            {
                string dir = Path.GetDirectoryName(FilePath);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                using (FileStream fs = File.Create(FilePath))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<PendingPush>));
                    xs.Serialize(fs, _items);
                }
            }
            catch
            {
                // Best effort — never crash on persistence failures.
            }
        }
    }
}