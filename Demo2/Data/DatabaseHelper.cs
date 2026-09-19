using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Demo.Data
{
    public class DatabaseHelper
    {
        private string _dataDir;
        private string _employeesPath;
        private string _fingerprintsPath;
        private string _attendancePath;

        private List<Employee> _employees;
        private List<FingerprintRecord> _fingerprints;
        private List<AttendanceRecord> _attendance;

        private int _nextAttendanceId = 1;

        public DatabaseHelper()
        {
            _dataDir = Path.Combine(Application.StartupPath, "data");
            Directory.CreateDirectory(_dataDir);
            _employeesPath = Path.Combine(_dataDir, "employees.xml");
            _fingerprintsPath = Path.Combine(_dataDir, "fingerprints.xml");
            _attendancePath = Path.Combine(_dataDir, "attendance.xml");

            _employees = new List<Employee>();
            _fingerprints = new List<FingerprintRecord>();
            _attendance = new List<AttendanceRecord>();
        }

        public List<Employee> Employees { get { return _employees; } }
        public List<FingerprintRecord> Fingerprints { get { return _fingerprints; } }
        public List<AttendanceRecord> Attendance { get { return _attendance; } }

        public void LoadAll()
        {
            _employees = LoadList<Employee>(_employeesPath);
            _fingerprints = LoadList<FingerprintRecord>(_fingerprintsPath);
            _attendance = LoadList<AttendanceRecord>(_attendancePath);

            foreach (var a in _attendance)
            {
                if (a.AttendanceID >= _nextAttendanceId)
                    _nextAttendanceId = a.AttendanceID + 1;
            }
        }

        public void SaveAll()
        {
            SaveList(_employeesPath, _employees);
            SaveList(_fingerprintsPath, _fingerprints);
            SaveList(_attendancePath, _attendance);
        }

        public void SaveEmployees()
        {
            SaveList(_employeesPath, _employees);
        }

        public void SaveFingerprints()
        {
            SaveList(_fingerprintsPath, _fingerprints);
        }

        public void SaveAttendance()
        {
            SaveList(_attendancePath, _attendance);
        }

        public Employee FindEmployeeById(string employeeId)
        {
            return _employees.Find(e => e.EmployeeID == employeeId);
        }

        public Employee FindEmployeeByFingerprintId(int fingerprintId)
        {
            var fp = _fingerprints.Find(f => f.FingerprintID == fingerprintId);
            if (fp == null) return null;
            return _employees.Find(e => e.EmployeeID == fp.EmployeeID);
        }

        public FingerprintRecord FindFingerprintByFid(int fid)
        {
            return _fingerprints.Find(f => f.FingerprintID == fid);
        }

        public void AddEmployee(Employee emp)
        {
            var existing = _employees.FindIndex(e => e.EmployeeID == emp.EmployeeID);
            if (existing >= 0)
                _employees[existing] = emp;
            else
                _employees.Add(emp);
        }

        public void AddFingerprint(FingerprintRecord fp)
        {
            _fingerprints.Add(fp);
        }

        public void RemoveFingerprintsForEmployee(string employeeId)
        {
            _fingerprints.RemoveAll(f => f.EmployeeID == employeeId);
        }

        public void AddAttendance(AttendanceRecord record)
        {
            record.AttendanceID = _nextAttendanceId++;
            _attendance.Add(record);
        }

        public int GetNextFingerprintId()
        {
            int max = 0;
            foreach (var f in _fingerprints)
            {
                if (f.FingerprintID > max)
                    max = f.FingerprintID;
            }
            return max + 1;
        }

        public int FingerprintCount
        {
            get { return _fingerprints.Count; }
        }

        private List<T> LoadList<T>(string path)
        {
            if (!File.Exists(path))
                return new List<T>();
            try
            {
                using (FileStream fs = File.OpenRead(path))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<T>));
                    return (List<T>)xs.Deserialize(fs);
                }
            }
            catch
            {
                return new List<T>();
            }
        }

        private void SaveList<T>(string path, List<T> list)
        {
            try
            {
                using (FileStream fs = File.Create(path))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<T>));
                    xs.Serialize(fs, list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save data: " + ex.Message);
            }
        }
    }
}
