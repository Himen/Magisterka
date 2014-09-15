using HR.Web_UI.Models.ViewModels.HR;
using HR.Web_UI.Services.ServicesInferface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace HR.Web_UI.Controllers
{
    //[Authorize(Roles="Kierownik")]
    public class ManagerController : BaseController
    {

        IManagerService managerServices;
        IHRServices ser;

        public ManagerController(IManagerService _managerServices, IHRServices ser)
        {
            this.managerServices = _managerServices;
            this.ser = ser;
        }

        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StartView()
        {
            return View();
        }


        public ActionResult DisplayWorkers(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No, string OrderType)
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

            var workers = ser.GetAllWorkers();

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

            foreach (var item in wlVM.Workers)
            {
                item.Employment.OrganiziationalUnitCode = ser.GetOrganizationName(item.Employment.OrganiziationalUnitCode);
                item.Employment.PositionCode = ser.GetPositionName(item.Employment.PositionCode);
            }

            return View(wlVM);
        }

        public ActionResult DisplayPromotialMaterials()
        {
            return View();
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

            var benefitsList = ser.GetAllWorkerBenefits(26);

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

            var x = ser.GetWorker(26);

            bVM.PersonId = id;
            bVM.FirstName = x.FirstName;
            bVM.Surname = x.Surname;
            bVM.Position = ser.GetPositionName(x.Employment.PositionCode);
            bVM.Organization = ser.GetOrganizationName(x.Employment.OrganiziationalUnitCode);
            ViewBag.PersonId = id;

            return View(bVM);
        }

        public ActionResult WorkerDetails(long Id)
        {
            //Pokazowy /HR/WorkerDetails/28
            PersonDisplayViewModel pdVM = ser.GetAllPersonData(Id);
            //np. logowac ze zmieniono statut z Kandydata na zatrudnionego

            return View(pdVM);
        }

        public ActionResult TraningsMaterials()
        {
            return View();
        }

        public ActionResult AddTraning()
        {
            return View();
        }

        public ActionResult WorkerHours()
        {
            return View();
        }

        public ActionResult HourDisplay()
        {
            return View();
        }

    }
}