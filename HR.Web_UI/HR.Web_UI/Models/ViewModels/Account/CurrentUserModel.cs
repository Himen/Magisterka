using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR.Core.Enums;

namespace HR.Web_UI.Models.ViewModels.Account
{
    [Serializable]
    public class CurrentUserModel
    {
        public long PersonId { get; set; }
        public long AccountId { get; set; }

        public string UserName { get; set; }
        public bool RememberMe { get; set; }

        //[NonSerialized] 
#warning Spradzic czy bezpieczne jest serializowanie hasla
        public string Password { get; set; }
        public AccountType AccountType { get; set; }
    }
}