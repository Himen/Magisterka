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


        /// <summary>
        /// Caly proces powinien byc odwracalny ale nie mamy na to czasu.
        /// Powinien byc jedne viewModel do wszystkiego.
        /// Jak starczy czasu to poprawic to.
        /// </summary>
        /// <returns></returns>
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
                if (hrServices.CreateWorker(vm))
                {
                    return RedirectToAction("AddWorkerAdditionalInformations", vm);
                }
                else
                {
                    ModelState.AddModelError("", "Uzytkownik nie zostal dodany. Prosze powtorz dodanie uzytkownika");
                    return View(vm);
                }
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
                return RedirectToAction("AddEmploymentInformation",vm);
            }
            else
            {
                return View(vm);
            }
        }

        public ActionResult AddEmploymentInformation()
        {
            EmploymentViewModel eVM = new EmploymentViewModel();
            /*eVM.Positions = hrServices.PositionsSelectListItem();
            eVM.Organizations = hrServices.OrganizationalUnitSelectListItem();*/
            eVM.Positions = new List<SelectListItem> { new SelectListItem{Text = "asd", Value="1"} } ;
            eVM.Organizations = new List<SelectListItem> { new SelectListItem { Text = "asd", Value = "1" } };

            return View(eVM);
        }

        [HttpPost]
        public ActionResult AddEmploymentInformationSend(EmploymentViewModel eVM)
        {
            if (ModelState.IsValid)
            {
                if (hrServices.CreateEmployment(eVM))
                {
                    return RedirectToAction("AddContactPerson");
                }
                else
                {
                    ModelState.AddModelError("","Nieznany blad");
                    return View("AddEmploymentInformation",eVM);
                }
            }
            else
            {
                return View("AddEmploymentInformation", eVM);
            }
        }

        public ActionResult AddContactPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactPersonSave(ContactPersonViewModel cpVM)
        {
            return View();
        }

        public ActionResult DisplaySuccessOfAddWorker()
        {
            return View();
        }
    }
}