using HR.Core.Enums;
using System;

namespace HR.Core.Models
{
    public class Employment
    {
        public long Id { get; set; }
        public long IdPerson { get; set; }
        public int DataState { get; set; }
        public string PositionCode { get; set; }
        public string OrganiziationalUnitCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ContractType ContractType { get; set; }

        public EmploymentType EmploymentType { get; set; }

        /// <summary>
        /// Opisuje czy jest 1/2 i 1/3      .. etatu
        /// </summary>
        public string ContractDimmension { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual BenefitsProfit BenefitsProfit { get; set; }

    }
}
