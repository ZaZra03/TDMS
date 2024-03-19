using System;

namespace TDMS.Model
{
    public class Timecard
    {
        public int TimecardId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime WorkDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal HoursWorked { get; set; }
    }
}
