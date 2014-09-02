using HR.Core.Enums;
using HR.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.Web_UI.Models.ViewModels.Account
{
    public class AccountViewModel
    {
        public long Id { get; set; }
        /// <summary>
        /// Nazwa uzytkownika tworzona z polaczenia imienia i nazwiska.
        /// np. Pawel_Nowak
        /// </summary>
        [Display(Name="Nazwa użytkownika")]
        public string UserName { get; set; }

        /// <summary>
        /// Haslo do konta. Poczatkowo generowane przez system.
        /// Potem zmienione przez uzytkownika.
        /// </summary>
        [Display(Name = "Nazwa użytkownika")]
        public string Password { get; set; }

        /// <summary>
        /// Zdjecie osoby
        /// </summary>
        [Display(Name = "Zdjęcie")]
        public byte[] Photo { get; set; }

        /// <summary>
        /// Rodzaj konta. Pracownik, Kierownik, HR
        /// </summary>
        
        public AccountType AccountType { get; set; }

        public Person Person { get; set; }

        /// <summary>
        /// Logi dla konta
        /// </summary>
        public IList<AccountLog> AccountLogs { get; set; }
    }
}