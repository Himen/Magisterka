using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Web_UI.Controllers
{
    //[Authorize(Roles="Kierownik")]
    public class ManagerController : BaseController
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
    }
}