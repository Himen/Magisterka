using HR.Core.Enums;
using HR.Core.Models;
using HR.Web_UI.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Web_UI.Services.ServicesInferface
{
    public interface IAccountService
    {
        Account GetUserByName(string name);
        CurrentUserModel MapAccount(Account ac);
        bool LogAction_LOGIN(Account ac,string clientIP);
        bool LogAction_LOGOUT(CurrentUserModel ac, string clientIP);
    }
}
