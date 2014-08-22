using HR.Core.Models;
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
            if (ModelState.IsValid)
            {
                Person p = new Person();
                p = hrServices.CreateWorker(vm);
                if (p!=null)
                {
                    Session["Person"] = p;
                    return RedirectToAction("AddWorkerAdditionalInformations");
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

        public ActionResult AddWorkerAdditionalInformations()
        {
            ViewBag.Message = "Dodano osobe!";
            return View();
        }

        [HttpPost]
        public ActionResult AddWorkerAdditionalInfoSend(AdditionalInformationViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Person p = Session["Person"] as Person;
                AdditionalInformation ai = hrServices.CreateAdditionalInfo(vm, p);
                if(ai != null)
                {
                    return RedirectToAction("AddEmploymentInformation");
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

        public ActionResult AddEmploymentInformation()
        {
            EmploymentViewModel eVM = new EmploymentViewModel();
            /*eVM.Positions = hrServices.PositionsSelectListItem();
            eVM.Organizations = hrServices.OrganizationalUnitSelectListItem();*/
            eVM.Positions = new List<SelectListItem> { new SelectListItem{Text = "Java Developer", Value="1"} } ;
            eVM.Organizations = new List<SelectListItem> { new SelectListItem { Text = "JAVA TEAM", Value = "1" } };

            return View(eVM);
        }

        [HttpPost]
        public ActionResult AddEmploymentInformationSend(EmploymentViewModel eVM)
        {
            if (ModelState.IsValid)
            {
                Person p = Session["Person"] as Person;
                Employment e = hrServices.CreateEmployment(eVM, p);
                if (e!= null)
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
            ViewBag.Message = "Dodano informacje o zatrudnieniu pracownika!";
            return View();
        }

        [HttpPost]
        public ActionResult ContactPersonSave(ContactPersonViewModel cpVM)
        {
            if (ModelState.IsValid)
            {
                Person p = Session["Person"] as Person;
                ContactPerson cp = hrServices.CreateContactPerson(cpVM,p);
                if (cp!= null)
                {
                    return RedirectToAction("DisplaySuccessOfAddWorker");
                }
                else
                {
                    ModelState.AddModelError("", "Nieznany blad");
                    return View("AddEmploymentInformation", cpVM);
                }
            }
            else
            {
                return View("AddEmploymentInformation", cpVM);
            }
        }
        
        //potem mozna jeszcze dac zatwierdzanie osoby ze wszystko sie zgadza

        /// <summary>
        /// HR ma mozliwosc edycji danych
        /// </summary>
        /// <returns></returns>
        public ActionResult DisplaySuccessOfAddWorker()
        {
            Person p = Session["Person"] as Person;

            PersonDisplayViewModel pdVM = hrServices.GetAllPersonData(p.Id);
            
            if (p != null)
            {
                ViewBag.Message = "Osoba została pomyslnie dodana: " + p.FirstName + " " + p.Surname;
            }
            //globalny ViewModelZrobic
            return View(pdVM);
        }
    }
}