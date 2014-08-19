using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Web_UI.Controllers
{
    /// <summary>
    /// Tutaj zawarte sa akcje dostepne dla nie zalogowanego uzytkownika tj. strona startowa, informacje o firmie, materialy promocyjne
    /// </summary>
    public class CommonController : Controller
    {
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