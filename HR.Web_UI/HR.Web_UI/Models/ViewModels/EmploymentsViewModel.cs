using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.Web_UI.Models.ViewModels
{
    public class EmploymentsViewModel
    {
        public long Id { get; set; }

        /// <summary>
        /// Nazwa firmy w ktorej pracuje pracownik
        /// </summary>
        [Display(Name= "Nazwa firmy")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Pozycja ktora zajmuje/mowal pracownik
        /// </summary>
        [Display(Name = "Stanowisko")]
        public string Position { get; set; }

        /// <summary>
        /// Data rozpoczecia wspolpracy z dana firma
        /// </summary>
        [Display(Name = "Początek rozpoczęcia współpracy")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Data zakonczenia wspolpracy z dana firma
        /// </summary>
        [Display(Name = "Koniec rozpoczęcia współpracy")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Opis stanowiska na ktorym sie bylo
        /// </summary>
        [Display(Name = "Opis stanowiska")]
        public string Description { get; set; }
    }
}