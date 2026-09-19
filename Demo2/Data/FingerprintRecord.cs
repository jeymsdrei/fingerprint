using System;

namespace Demo.Data
{
    [Serializable]
    public class FingerprintRecord
    {
        public int FingerprintID { get; set; }
        public string EmployeeID { get; set; }
        public string TemplateBase64 { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
