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
    }
}
