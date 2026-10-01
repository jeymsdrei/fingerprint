using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Demo.Data
{
    [Serializable]
    public class MakeUpSlot
    {
        public DateTime Date { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }

    [Serializable]
    public class ScheduleSlot
    {
        public int Day { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }

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
        public string PhotoData { get; set; }

        // True for teaching staff (classification = teaching). Used to refuse
        // clock-ins when this employee has no schedule data at all.
        public bool IsTeaching { get; set; }

        // Effective clock-in windows resolved by the HRIS server, one entry per
        // (day, shift). Day matches DateTime.DayOfWeek (0=Sunday .. 6=Saturday).
        // Null/empty means the machine has no schedule data for this employee and
        // clock-in gating is disabled (legacy behaviour).
        public List<ScheduleSlot> Schedules { get; set; }

        // Approved one-off make-up classes, each on a specific date. They count
        // as valid clock-in windows for that exact date (e.g. a Saturday with a
        // make-up class). Null = none / legacy.
        public List<MakeUpSlot> MakeUpClasses { get; set; }

        public bool HasPhoto
        {
            get { return !string.IsNullOrEmpty(PhotoData); }
        }

        public Image GetPhotoImage()
        {
            if (!HasPhoto)
                return null;
            try
            {
                string data = PhotoData;
                int comma = data.IndexOf(',');
                if (comma >= 0)
                    data = data.Substring(comma + 1);
                byte[] bytes = Convert.FromBase64String(data);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    using (Image img = Image.FromStream(ms))
                    {
                        return new Bitmap(img);
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
