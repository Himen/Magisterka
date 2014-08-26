using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Web_UI.Controllers
{
    public class WorkerController : BaseController
    {
        // GET: Worker
        public ActionResult Index()
        {
            return View();
        }
    }
}