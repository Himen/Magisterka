using HR.Core.Enums;
using HR.Web_UI.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Web_UI.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        public UserController()
        {
#warning Zabezpieczyc jak sie skonczy sesja to ma akcji nie przepuszczac
            //Currentuser <- pobrac z serwisu dane

        }
        // GET: User
        public ActionResult Index()
        {
            var User = CurrentUser;
            if (User.AccountType == AccountType.Pracownik)
                return RedirectToAction("Index","Worker");
            else if (User.AccountType == AccountType.Kierownik)
                return RedirectToAction("StartView", "Manager");
            else
                return RedirectToAction("Index", "HR");
        }
    }
}