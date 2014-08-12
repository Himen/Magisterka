using HR.DataAccess.EF;
using HR.DataAccess.EF.UnityOfWorks;
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
            UnityOfWork u = new UnityOfWork();
            var account = u.AccountRepository.GetAll().ToList();

            using (var db = new HR_DataContext())
            {
                var x = db.Account.ToList();
                var z = x.Count;
            }

            return View();
        }

        public ActionResult UserView()
        {
            return View();
        }

        public ActionResult ManagerView()
        {

            using (var db = new HR_DataContext())
            {
                var x = db.Persons.ToList();
                var z = x.Count;
            }
            return View();
        }
    }
}