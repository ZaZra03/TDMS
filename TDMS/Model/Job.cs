using System;

namespace TDMS.Model
{
    public class Job
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
        public int? CustomerId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public int EstimatedHours { get; set; }
        public int ActualHours { get; set; }
    }
}
