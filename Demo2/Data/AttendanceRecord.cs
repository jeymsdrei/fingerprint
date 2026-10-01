using System;

namespace Demo.Data
{
    [Serializable]
    public class AttendanceRecord
    {
        public int AttendanceID { get; set; }
        public string EmployeeID { get; set; }
        public DateTime DateTime { get; set; }
        public string Action { get; set; }

        // Fingerprint match confidence reported by the SDK at identification
        // time (0 when not captured).
        public int Score { get; set; }
    }
}
