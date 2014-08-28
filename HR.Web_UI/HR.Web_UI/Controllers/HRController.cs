using HR.Core.Models;
using HR.Web_UI.Models.ViewModels.HR;
using HR.Web_UI.Services.ServicesInferface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using HR.Core.Enums;
using DotNet.Highcharts.Options;
using DotNet.Highcharts;
using DotNet.Highcharts.Helpers;

namespace HR.Web_UI.Controllers
{
    //[Authorize(Roles="HR")]
    public class HRController : BaseController
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

                if (hrServices.CheckEmailExist(vm))
                {
                    ModelState.AddModelError("Email", "Podany email istnieje juz w bazie.");
                    return View(vm);
                }

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

        public ActionResult AddCollage(CollegesViewModel cVM, long Id)
        {
            if (ModelState.IsValid)
            {
                //Person p = Session["Person"] as Person;

                if(hrServices.AddNewPersonCollage(cVM,Id))
                {
                    ViewBag.Message = "Pomyślnie dodano miejsce edukacji";
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

        public ActionResult DisplayAllCollages(long Id)
        {
            //Person p = Session["Person"] as Person;

#warning Uwaga trzba inna akcje dac zeby wyswietlac szczególy pracownika

            var x = hrServices.GetAllColleges(Id);

            return PartialView("_LearnHistory",x);
        }

        public ActionResult AddJob(EmploymentsViewModel cVM)
        {

            if (ModelState.IsValid)
            {
                //Person p = Session["Person"] as Person;
                
                if (hrServices.AddNewPersonJob(cVM, cVM.Id))
                {
                    ViewBag.Message = "Pomyślnie dodano miejsce zatrudnienia";
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

        public ActionResult DisplayAllJobs(long Id)
        {
#warning Uwaga trzba inna akcje dac zeby wyswietlac szczególy pracownika
            //Person p = Session["Person"] as Person;

            var x = hrServices.GetAllJobs(Id);

            return PartialView("_EmploymentHistory",x);
        }

        public ActionResult DisplayAllTranings(long Id)
        {
            var x = hrServices.GetAllTrainings(Id);

            return PartialView("_TraningsHistory",x);
        }

        public ActionResult AddTraning(TraningsViewModel tVM, long Id)
        {
            if (ModelState.IsValid)
            {

                if (hrServices.AddNewPersonTrainings(tVM, Id))
                {
                    ViewBag.Message = "Pomyślnie dodano szkolenie/certyfkiacje";
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
            if (hrServices.DeleteWorker(id))
            {
                return RedirectToAction("DisplayListOfWorkers");
            }
            return View();
        }



        public ActionResult CandidatList(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No, string OrderType)
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

            var workers = hrServices.GetAllCandidats();

            if (!String.IsNullOrEmpty(Search_Data))
            {
                workers = workers.Where(stu => stu.FirstName.ToUpper().Contains(Search_Data.ToUpper()) ||
                                               stu.Surname.ToUpper().Contains(Search_Data.ToUpper()) ||
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

        public ActionResult EmployWorker(long id)
        {
            hrServices.EmployCandidate(id,EmploymentType.Zatrudniony);
            return RedirectToAction("DisplayListOfWorkers");
        }

        public ActionResult DumpEmployee(long id)
        {
            hrServices.EmployCandidate(id, EmploymentType.Zwolniony);
            return RedirectToAction("DisplayListOfWorkers");
        }

        public ActionResult DisplayBenefitsOfWorker(long id, string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No, string OrderType)
        {
            /*ViewBag.OrderType = OrderType ?? "desc";
            ViewBag.CurrentSortOrder = Sorting_Order;
            Sorting_Order = Sorting_Order ?? "FirstName";*/

            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            var benefitsList = hrServices.GetAllWorkerBenefits(id);

            /*if (!String.IsNullOrEmpty(Search_Data))
            {
                benefitsList = benefitsList.Where(stu => stu.FirstName.ToUpper().Contains(Search_Data.ToUpper()) ||
                                               stu.Surname.ToUpper().Contains(Search_Data.ToUpper()) ||
                                               stu.FirstName.ToUpper().Contains(Search_Data.ToUpper()));///reszta
            }*/
            /*switch (Sorting_Order)
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
            }*/

            int Size_Of_Page = 12;
            int No_Of_Page = (Page_No ?? 1);
            
            BenefitsViewModel bVM = new BenefitsViewModel();
            bVM.Benefits = benefitsList.OrderByDescending(p => p.StartDate).ThenByDescending(n => n.StartDate.Month).ToPagedList(No_Of_Page, Size_Of_Page);
            bVM.PageCount = (int)Math.Ceiling((double)benefitsList.Count() / Size_Of_Page);
            bVM.PageNumber = Page_No ?? 1;

            var x = hrServices.GetWorker(id);

            bVM.PersonId = id;
            bVM.FirstName = x.FirstName;
            bVM.Surname = x.Surname;
            bVM.Position = hrServices.GetPositionName(x.Employment.PositionCode);
            bVM.Organization =hrServices.GetOrganizationName(x.Employment.OrganiziationalUnitCode);
            ViewBag.PersonId = id;

            return View(bVM);
        }


        public ActionResult ChartTest()
        {
            Highcharts chart = new Highcharts("chart")
                .SetXAxis(new XAxis
                {
                    Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
                })
                .SetSeries(new Series
                {
                    Data = new Data(new object[] { 29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4 })
                }).SetLegend(new Legend());

            return View(chart);
        }


    }
}