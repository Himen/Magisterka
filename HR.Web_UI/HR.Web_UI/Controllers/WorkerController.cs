using HR.Web_UI.Services.ServicesInferface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR.Web_UI.Models.ViewModels.Account;
using HR.Core.Models;
using PagedList;
using HR.Web_UI.Models.ViewModels.HR;

namespace HR.Web_UI.Controllers
{
    //[Authorize(Roles = "Pracownik")]
    public class WorkerController : BaseController
    {
        IWorkerService workerService;
        IAccountService accountService;

        public WorkerController(IWorkerService _workerService, IAccountService _accountService)
        {
            this.workerService = _workerService;
            this.accountService = _accountService;

            //CurrentUser = CurrentUser ?? accountService.GetUserByName();
        }

        // GET: Worker
        public ActionResult Index()
        {
            var x = CurrentUser;
            return View();
        }

        public ActionResult DisplayTraningsMaterials()
        {
            //workerService.GetAllMaterials();

            return View();
        }

        public ActionResult DisplayWorkBoard()
        {
            //dzisiaj przyszedles do pracy o...
            return View();
        }

        public ActionResult DisplayDocuments()
        {
            return View();
        }

        public ActionResult DisplayCharts()
        {
            return View();
        }

        public ActionResult ManageAccount()
        {
            var x = workerService.GetAccount(CurrentUser.AccountId);
            if (Request.IsAjaxRequest())
            {
                return PartialView(x);
            }
            return View(x);
        }

        public ActionResult ChangePassword(long id)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel chpVM)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ManageAccount");
            }
            return View();
        }

        public ActionResult GetLogData(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No, string OrderType)
        {
            var logs = workerService.GetUserLogs(CurrentUser.AccountId);

            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);

            LogViewModel pVM = new LogViewModel();
            pVM.AccountLogs = logs.OrderByDescending(p => p.Id).ToPagedList(No_Of_Page, Size_Of_Page);
            pVM.PageCount = (int)Math.Ceiling((double)logs.Count() / Size_Of_Page);
            pVM.PageNumber = Page_No ?? 1;

            return PartialView(pVM);
        }

        public ActionResult DisplayBenefits(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No, string OrderType)
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

            var benefitsList = workerService.GetAllWorkerBenefits(CurrentUser.PersonId);

            int Size_Of_Page = 12;
            int No_Of_Page = (Page_No ?? 1);

            BenefitsViewModel bVM = new BenefitsViewModel();
            bVM.Benefits = benefitsList.OrderByDescending(p => p.StartDate).ThenByDescending(n => n.StartDate.Month).ToPagedList(No_Of_Page, Size_Of_Page);
            bVM.PageCount = (int)Math.Ceiling((double)benefitsList.Count() / Size_Of_Page);
            bVM.PageNumber = Page_No ?? 1;

            var x = workerService.GetAccount(CurrentUser.AccountId).Person;

            bVM.PersonId = x.Id;
            bVM.FirstName = x.FirstName;
            bVM.Surname = x.Surname;
            bVM.Position = workerService.GetPositionName(x.Employment.PositionCode);
            bVM.Organization = workerService.GetOrganizationName(x.Employment.OrganiziationalUnitCode);
            ViewBag.PersonId = x.Id;

            return View(bVM);
        }

        public ActionResult Calendar()
        {
            //dodac dane do ladowania czegos
            return View();
        }

        public ActionResult WorkPanel()
        {
            return View();
        }

    }
}