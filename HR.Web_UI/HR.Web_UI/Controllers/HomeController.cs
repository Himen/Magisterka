using HR.DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Web_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var db = new HR_DataContext())
            {
                var x = db.Account.FirstOrDefault();
                var z = x.DataState;
            }

            return View();
        }

        public ActionResult UserView()
        {
            return View();
        }

        public ActionResult ManagerView()
        {
            return View();
        }
    }
}