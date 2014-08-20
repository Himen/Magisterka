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

namespace HR.Web_UI.Controllers
{
    /// <summary>
    /// Tutaj zawarte sa akcje dostepne dla nie zalogowanego uzytkownika tj. strona startowa, informacje o firmie, materialy promocyjne
    /// </summary>
    public class CommonController : Controller
    {
        IAdminUnityOfWork<EF_R.Repository<PromotialMaterial, long>, EF_U.UnityOfWork> promotialMaterialUnityOfWork;

        public CommonController(IAdminUnityOfWork<EF_R.Repository<PromotialMaterial, long>, EF_U.UnityOfWork> _promotialMaterialUnityOfWork)
        {
            promotialMaterialUnityOfWork = _promotialMaterialUnityOfWork;
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
            //dodac prosty view model i obrobic widok
            return View();
        }


    }
}