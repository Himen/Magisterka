using System;

namespace HR.Core.Models
{
    public class Job
    {
        public long Id { get; set; }
        public int DataState { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
    }
}
