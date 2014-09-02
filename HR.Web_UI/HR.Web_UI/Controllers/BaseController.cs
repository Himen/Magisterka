using HR.Web_UI.Models.ViewModels.Account;
using HR.Web_UI.Services.ServicesInferface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Web_UI.Controllers
{
    public class BaseController : Controller
    {
        //http://www.strathweb.com/2012/05/using-ninject-with-the-latest-asp-net-web-api-source/
        //wstrzyknac servis ninjectem
        public CurrentUserModel CurrentUser
        {
            get
            {
                var user = Session["CurrentUser"] as CurrentUserModel;
                //user = user ?? serv
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