using HR.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace HR.Web_UI.Models.ViewModels
{
    public class PersonViewModel
    {
        public string UserName { get; set; } //domyslnie bedzie: Imie_Nazwisko

        [Display(Name = "Zdjęcie")]
        public HttpPostedFileBase Photo { get; set; }

        [Display(Name="Typ konta")]
        public AccountType AccountType { get; set; }

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

        //lista szkol do dodania - zrobic takie kaskadowe dodawanie ze mozna dodawac ile sie chce
        //szef 

        public string Facebook { get; set; }
        public string Google { get; set; }
        public string Twitter { get; set; }
        public string GoldenLine { get; set; }
        public string LinkIn { get; set; }


        public List<Person> ManagerList { get; set; }

        public long ManagerId { get; set; }

        /// <summary>
        /// ciag dalszy
        /// </summary>

        [Display(Name = "Specializacja")]
        public ProfesionType Profession { get; set; }
    }
}