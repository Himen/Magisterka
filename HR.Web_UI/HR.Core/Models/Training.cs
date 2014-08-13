using HR.Core.BasicContract;
using System;

namespace HR.Core.Models
{
    public class Training : BaseEntity<long>
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime DateOfPass { get; set; }
    }
}
