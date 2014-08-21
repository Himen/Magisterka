using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR.Core.Enums;
using System.Web.Mvc;
using HR.Core.Models;

namespace HR.Web_UI.Models.ViewModels
{
    public class EmploymentViewModel
    {
        public EmploymentViewModel()
        {
            this.IsMonthBenefit = true;
        }
        public string Position { get; set; }
        public List<SelectListItem> Positions { get; set; }

        public string Organization { get; set; }
        public List<SelectListItem> Organizations { get; set; }

        public EmploymentType EmploymentType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ContractType  ContractType{ get; set; }

        public ContractDimensionType ContractDimension { get; set; }

        public bool IsMonthBenefit { get; set; }

        public double? MonthBenefit { get; set; }

        public double? BenefitPerHour { get; set; }

        public string BankName { get; set; }

        public string BankAddress { get; set; }

        public string AccountNumber { get; set; }

        public Person Person { get; set; }
    }
}