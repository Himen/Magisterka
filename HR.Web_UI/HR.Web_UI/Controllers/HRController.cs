using HR.Core.Models;
using HR.Web_UI.Models.ViewModels;
using HR.Web_UI.Services.ServicesInferface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

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
            eVM.Positions = hrServices.PositionsSelectListItem();
            eVM.Organizations = hrServices.OrganizationalUnitSelectListItem();
            eVM.ListOfManagers = hrServices.GetAllManagersSelectList();
            /*eVM.Positions = new List<SelectListItem> { new SelectListItem{Text = "Java Developer", Value="1"} } ;
            eVM.Organizations = new List<SelectListItem> { new SelectListItem { Text = "JAVA TEAM", Value = "1" } };*/

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
                eVM.Positions = hrServices.PositionsSelectListItem();
                eVM.Organizations = hrServices.OrganizationalUnitSelectListItem();
                eVM.ListOfManagers = hrServices.GetAllManagersSelectList();

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

            if (p == null)
            {
                p = new Person();
                p.Id = 6;
            }

            PersonDisplayViewModel pdVM = hrServices.GetAllPersonData(p.Id);

            if (p != null)
            {
                ViewBag.Message = "Osoba została pomyslnie dodana: " + p.FirstName + " " + p.Surname;
            }
            //globalny ViewModelZrobic
            return View(pdVM);
        }

        public ActionResult AddCollage(CollegesViewModel cVM)
        {
            if (ModelState.IsValid)
            {
                Person p = Session["Person"] as Person;

                if(hrServices.AddNewPersonCollage(cVM,p))
                {

                    return RedirectToAction("DisplaySuccessOfAddWorker");
                }
                else
                {
                    ModelState.AddModelError("", "Nieznany blad");
                    return View("DisplaySuccessOfAddWorker");
                }
            }
            else
            {
 
            }

            return View();
        }

        public ActionResult DisplayAllCollages()
        {
            Person p = Session["Person"] as Person;

            if (p == null)
            {
                p = new Person();
                p.Id = 6;
            }

            var x=hrServices.GetAllColleges(p.Id);

            return PartialView("_LearnHistory",x);
        }

        public ActionResult AddJob(EmploymentsViewModel cVM)
        {

            if (ModelState.IsValid)
            {
                Person p = Session["Person"] as Person;

                if (hrServices.AddNewPersonJob(cVM, p))
                {

                    return RedirectToAction("DisplaySuccessOfAddWorker");
                }
                else
                {
                    ModelState.AddModelError("", "Nieznany blad");
                    return View("DisplaySuccessOfAddWorker");
                }
            }
            else
            {

            }

            return View();
        }

        public ActionResult DisplayAllJobs()
        {
            Person p = Session["Person"] as Person;

            if (p == null)
            {
                p = new Person();
                p.Id = 6;
            }

            var x = hrServices.GetAllJobs(p.Id);

            return PartialView("_EmploymentHistory",x);
        }

        public ActionResult DisplayListOfWorkers(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No, string OrderType)
        {
            ViewBag.OrderType = OrderType ?? "desc";
            ViewBag.CurrentSortOrder = Sorting_Order;
            Sorting_Order = Sorting_Order ?? "FirstName";

            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            var workers = hrServices.GetAllWorkers();

            if (!String.IsNullOrEmpty(Search_Data))
            {
                workers = workers.Where(stu => stu.FirstName.ToUpper().Contains(Search_Data.ToUpper()) || 
                                               stu.Surname.ToUpper().Contains(Search_Data.ToUpper())   ||
                                               stu.FirstName.ToUpper().Contains(Search_Data.ToUpper()));///reszta
            }
            switch (Sorting_Order)
            {
                case "FirstName":
                    if (ViewBag.OrderType == "desc")
                    {
                        workers = workers.OrderByDescending(stu => stu.FirstName);
                        ViewBag.OrderType = "asc";
                    }
                    else
                    {
                        workers = workers.OrderBy(stu => stu.FirstName);
                        ViewBag.OrderType = "desc";
                    }
                    break;
                case "Surname":
                    if (ViewBag.OrderType == "desc")
                    {
                        workers = workers.OrderByDescending(stu => stu.Surname);
                        ViewBag.OrderType = "asc";
                    }
                    else
                    {
                        workers = workers.OrderBy(stu => stu.Surname);
                        ViewBag.OrderType = "desc";
                    }
                    break;
                case "Date":
                    if (ViewBag.OrderType == "desc")
                    {
                        workers = workers.OrderByDescending(stu => stu.DateOfBirth);
                        ViewBag.OrderType = "asc";
                    }
                    else
                    {
                        workers = workers.OrderBy(stu => stu.DateOfBirth);
                        ViewBag.OrderType = "desc";
                    }
                    break;
                case "Employment":
                    if (ViewBag.OrderType == "desc")
                    {
                        workers = workers.OrderByDescending(stu => stu.Employment.EmploymentType);
                        ViewBag.OrderType = "asc";
                    }
                    else
                    {
                        workers = workers.OrderBy(stu => stu.Employment.EmploymentType);
                        ViewBag.OrderType = "desc";
                    }
                    break;
                case "Position":
                    if (ViewBag.OrderType == "desc")
                    {
                        workers = workers.OrderByDescending(stu => stu.Employment.PositionCode);
                        ViewBag.OrderType = "asc";
                    }
                    else
                    {
                        workers = workers.OrderBy(stu => stu.Employment.PositionCode);
                        ViewBag.OrderType = "desc";
                    }
                    break;
                    //cd
                default:
                    workers = workers.OrderBy(stu => stu.FirstName);
                    break;
            }

            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);

            WorkersListViewModel wlVM = new WorkersListViewModel();
            wlVM.Workers = workers.ToPagedList(No_Of_Page, Size_Of_Page);
            wlVM.PageCount = (int)Math.Ceiling((double)workers.Count() / Size_Of_Page);
            wlVM.PageNumber = Page_No ?? 1;

            return View(wlVM);
        }

        public ActionResult WorkerDetails(long Id)
        {
            //Pokazowy /HR/WorkerDetails/28
            PersonDisplayViewModel pdVM = hrServices.GetAllPersonData(Id);
            //np. logowac ze zmieniono statut z Kandydata na zatrudnionego

            if (pdVM != null)
                return View("DisplaySuccessOfAddWorker", pdVM);
            else
                return RedirectToAction("DisplayListOfWorkers");
        }

        public ActionResult DeleteWorker(long id)
        {

            return RedirectToAction("DisplayListOfWorkers");
        }
    }
}