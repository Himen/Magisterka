using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.Web_UI.Models.ViewModels.Account
{
    public class ChangePasswordViewModel
    {
        [Display(Name="Stare hasło")]
        public string OldPassword { get; set; }
        [Display(Name = "Nowe hasło")]
        public string NewPassword { get; set; }
        [Display(Name = "Powtórz nowe hasło")]
        public string NewPasswordAgain { get; set; }
    }
}