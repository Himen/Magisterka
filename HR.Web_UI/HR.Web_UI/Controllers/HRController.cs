using HR.Web_UI.Models.ViewModels;
using HR.Web_UI.Services.ServicesInferface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Web_UI.Controllers
{
    public class HRController : Controller
    {
        IHRServices hrServices;

        public HRController(IHRServices _hrServices)
        {
            this.hrServices = _hrServices;
        }

        // GET: HR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateWorker()
        {
            return View();
        }

        public ActionResult BackToCreateWorker(PersonViewModel vm)
        {
            return View("CreateWorker",vm);
        }

        [HttpPost]
        public ActionResult CreateWorker(PersonViewModel vm)
        {

            #warning Sprawdzic dzialanie ajaxa,  bo nie dziala
          /*  if(Request.IsAjaxRequest())
                return Content("asdasdadsa");
            return View();*/

            if (ModelState.IsValid)
            {
                hrServices.CreateWorker(vm);

                return RedirectToAction("AddWorkerAdditionalInformations",vm);
            }
            else
            {
                return View(vm);
            }
        }

        public ActionResult AddWorkerAdditionalInformations(PersonViewModel vm)
        {
            ViewBag.Message = "Dodano osobe!";
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddWorkerAdditionalInfoSend(PersonViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("AddWorkerAdditionalInformations");
            }
            else
            {
                return View(vm);
            }
        }

        public ActionResult AddEmploymentInformation(PersonViewModel vm)
        {
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddEmploymentInformationSend(PersonViewModel vm)
        {
            return View();
        }
    }
}