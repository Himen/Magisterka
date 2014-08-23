using HR.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.Web_UI.Models.ViewModels
{
    public class PersonDisplayViewModel
    {

        [Display(Name = "Zdjęcie")]
        public byte[] Photo { get; set; }

        [Display(Name = "Typ konta")]
        public AccountType accountType{ get; set; }

        public string AccountType
        {
            get
            {
                return Enum.GetName(accountType.GetType(), accountType);
            }
            // potem pomyslec nad tym ze mozna edytowac
        }

        [Required]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Data urodzenia")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Numer budynku")]
        public int BuildingNumber { get; set; }

        [Display(Name = "Numer mieszkania")]
        public int ApartmentNumber { get; set; }

        [Display(Name = "Telefon")]
        public long Phone { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "NIP")]
        public long NIP { get; set; }

        [Required]
        [Display(Name = "Numer dowodu")]
        public string IDCard { get; set; }

        [Required]
        [Display(Name = "PESEL")]
        public string PESEL { get; set; }

        public string Facebook { get; set; }
        public string Google { get; set; }
        public string Twitter { get; set; }
        public string GoldenLine { get; set; }
        public string LinkIn { get; set; }


        
        [Display(Name = "Pozycja")]
        public string Position { get; set; }

        [Display(Name = "Dział")]
        public string Organization { get; set; }

        [Display(Name = "Rodzaj zatrudnienia")]
        public EmploymentType EmploymentType { get; set; }

        [Display(Name = "Data rozpoczecia współpracy")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Data zakończenia współpracy")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Rodzaj umowy")]
        public ContractType ContractType { get; set; }

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



        /// <summary>
        /// Imie osoby kontaktowej
        /// </summary>
        [Display(Name = "Imię osoby kontaktowej")]
        public string ContactPersonFirstName { get; set; }

        /// <summary>
        /// Nazwisko osoby kontaktowej
        /// </summary>
       [Display(Name = "Nazwisko osoby kontaktowej")]
        public string ContactPersonSurname { get; set; }

        /// <summary>
        /// Miasto
        /// </summary>
        [Display(Name = "Miasto")]
        public string ContactPersonCity { get; set; }

        /// <summary>
        /// Kod pocztowy
        /// </summary>
        [Display(Name = "Kod pocztowy")]
        public string ContactPersonPostalCode { get; set; }

        /// <summary>
        /// Ulica
        /// </summary>
        [Display(Name = "Ulica")]
        public string ContactPersonStreet { get; set; }

        /// <summary>
        /// Numer budynku
        /// </summary>
        [Display(Name = "Numer budynku")]
        public int ContactPersonBuildingNumber { get; set; }

        /// <summary>
        /// Numer mieszkania
        /// </summary>
        [Display(Name = "Numer mieszkania")]
        public int ContactPersonApartmentNumber { get; set; }

        /// <summary>
        /// Telefon
        /// </summary>
        [Display(Name = "Telefon")]
        public long ContactPersonPhone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Display(Name = "Email")]
        public string ContactPersonEmail { get; set; }

    }
}