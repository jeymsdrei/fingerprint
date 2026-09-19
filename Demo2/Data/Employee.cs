using System;

namespace Demo.Data
{
    [Serializable]
    public class Employee
    {
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhotoPath { get; set; }
    }
}
