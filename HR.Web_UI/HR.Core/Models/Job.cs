using HR.Core.BasicContract;
using System;

namespace HR.Core.Models
{
    public class Job : BaseEntity<long>
    {
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
    }
}
