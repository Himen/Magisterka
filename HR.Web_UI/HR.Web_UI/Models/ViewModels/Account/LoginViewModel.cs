using HR.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.Web_UI.Models.ViewModels.Account
{
    public class LoginViewModel
    {
        [Display(Name="Nazwa użytkownika")]
        public string UserName { get; set; }

        /// <summary>
        /// Haslo do konta. Poczatkowo generowane przez system.
        /// Potem zmienione przez uzytkownika.
        /// </summary>
        [Display(Name="Hasło")]
        public string Password { get; set; }

        /// <summary>
        /// Rodzaj konta. Pracownik, Kierownik, HR
        /// </summary>
        public AccountType AccountType { get; set; }

        [Display(Name="Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}