using HR.Web_UI.Services.ServicesInferface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Web_UI.Controllers
{
    [Authorize(Roles="Kierownik")]
    public class ManagerController : BaseController
    {

        IManagerService managerServices;

        public ManagerController(IManagerService _managerServices)
        {
            this.managerServices = _managerServices;
        }

        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayWorkers()
        {
            var x = managerServices.GetAllWorkersFromTeam(CurrentUser.PersonId);

            return View(x);
        }

        public ActionResult DisplayPromotialMaterials()
        {
            return View();
        }
    }
}