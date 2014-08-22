using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.Web_UI.Models.ViewModels
{
    public class ContactPersonViewModel
    {
        /// <summary>
        /// Imie osoby kontaktowej
        /// </summary>
        [Display(Name="Imię osoby kontaktowej")]
        public string FirstName { get; set; }

        /// <summary>
        /// Nazwisko osoby kontaktowej
        /// </summary>
        [Display(Name = "Nazwisko osoby kontaktowej")]
        public string Surname { get; set; }

        /// <summary>
        /// Miasto
        /// </summary>
        [Display(Name = "Miasto")]
        public string City { get; set; }

        /// <summary>
        /// Kod pocztowy
        /// </summary>
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Ulica
        /// </summary>
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        /// <summary>
        /// Numer budynku
        /// </summary>
        [Display(Name = "Numer budynku")]
        public int BuildingNumber { get; set; }

        /// <summary>
        /// Numer mieszkania
        /// </summary>
        [Display(Name = "Numer mieszkania")]
        public int ApartmentNumber { get; set; }

        /// <summary>
        /// Telefon
        /// </summary>
        [Display(Name = "Telefon")]
        public long Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}