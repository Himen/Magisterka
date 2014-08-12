using HR.Core.Enums;
using System;

namespace HR.Core.Models
{
    public class BenefitsProfit
    {
        public long Id { get; set; }
        public long IdEmployment { get; set; }
        public int DataState { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Benefit { get; set; }
        public BenefitType BenefitType { get; set; }
        
        /// <summary>
        /// raczej zatrudnienie powinno miec mapowanie
        /// </summary>
        //public virtual Employment Employment { get; set; }

    }
}
