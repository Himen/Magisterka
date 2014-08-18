using HR.Web_UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Web_UI.Controllers
{
    public class HRController : Controller
    {
        // GET: HR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateWorker()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateWorker(PersonViewModel vm)
        {
            return View();
        }
    }
}