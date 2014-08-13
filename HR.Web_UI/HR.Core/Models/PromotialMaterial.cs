using HR.Core.BasicContract;
using System;

namespace HR.Core.Models
{
    public class PromotialMaterial : BaseEntity<long>
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
