using HR.Web_UI.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Web_UI.Controllers
{
    public class BaseController : Controller
    {
        public CurrentUserModel CurrentUser
        {
            get
            {
                var user = Session["CurrentUser"] as CurrentUserModel;
                return user;
            }
            set
            {
                Session["CurrentUser"] = value;
            }
        }

        public string CurrenrUserName
        {
            get
            {
                var userName = Session["UserName"] as CurrentUserModel;
                return userName == null ? "" : userName.ToString();
            }
            set
            {
                Session["UserName"] = value;
            }
        }
    }
}