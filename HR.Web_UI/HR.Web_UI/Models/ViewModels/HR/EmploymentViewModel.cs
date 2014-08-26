using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR.Core.Enums;
using System.Web.Mvc;
using HR.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace HR.Web_UI.Models.ViewModels.HR
{
    public class EmploymentViewModel
    {
        public EmploymentViewModel()
        {
            this.IsMonthBenefit = true;
        }

        public string Position { get; set; }

        [Display(Name="Zajmowana pozycja")]
        public List<SelectListItem> Positions { get; set; }

        [Display(Name = "Dział")]
        public string Organization { get; set; }
        public List<SelectListItem> Organizations { get; set; }

        [Display(Name = "Kierownik")]
        public string Manager { get; set; }

        public List<SelectListItem> ListOfManagers { get; set; }

        [Display(Name = "Rodzaj zatrudnienia")]
        public EmploymentType EmploymentType { get; set; }

        [Display(Name = "Data rozpoczecia współpracy")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Data zakończenia współpracy")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Rodzaj umowy")]
        public ContractType  ContractType{ get; set; }

        [Display(Name = "Wymiar pracy")]
        public ContractDimensionType ContractDimension { get; set; }

        [Display(Name = "Pensja ma byc wyplacana miesiecznie?")]
        public bool IsMonthBenefit { get; set; }

        [Display(Name = "Miesieczna pensja brutto")]
        public double? MonthBenefit { get; set; }

        [Display(Name = "Godzinowe wynagrodzenie brutto")]
        public double? BenefitPerHour { get; set; }

        [Display(Name = "Nazwa banku")]
        public string BankName { get; set; }

        [Display(Name = "Adres banku")]
        public string BankAddress { get; set; }

        [Display(Name = "Numer konta")]
        public string AccountNumber { get; set; }

    }
}