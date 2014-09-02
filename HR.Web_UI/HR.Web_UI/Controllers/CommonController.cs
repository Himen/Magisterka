using HR.DataAccess.GLOBAL.UnityOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_R = HR.DataAccess.EF.Repositories;
using NH_R = HR.DataAccess.NH.Repositories;
using EF_U = HR.DataAccess.EF.UnityOfWorks;
using NH_U = HR.DataAccess.NH.UnityOfWorks;
using HR.Core.Models.RepoModels;
using HR.Web_UI.Services.ServicesInferface;
using HR.Web_UI.Models.ViewModels.HR;
using PagedList;

namespace HR.Web_UI.Controllers
{
    /// <summary>
    /// Tutaj zawarte sa akcje dostepne dla nie zalogowanego uzytkownika tj. strona startowa, informacje o firmie, materialy promocyjne
    /// </summary>
    public class CommonController : BaseController
    {
        ICommonService commonService;

        public CommonController(ICommonService _commonService)
        {
            this.commonService = _commonService;
        }

        // GET: Common
        /// <summary>
        /// Strona startowa z newsami
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //dodac prosty view model i obrobic widok
            return View();
        }

        public ActionResult InformacjeOFirmie()
        {
            return View();
        }

        public ActionResult DisplayPromotialMaterials(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No, string OrderType)
        {
            var materials = commonService.GetAllMaterials();

            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);

            PromotialMaterialViewModel pVM = new PromotialMaterialViewModel();
            pVM.Materials = materials.OrderByDescending(p => p.Id).ToPagedList(No_Of_Page, Size_Of_Page);
            pVM.PageCount = (int)Math.Ceiling((double)materials.Count() / Size_Of_Page);
            pVM.PageNumber = Page_No ?? 1;

            return View(pVM);
        }

        public ActionResult AboutAuthor()
        {
            return View();
        }


    }
}