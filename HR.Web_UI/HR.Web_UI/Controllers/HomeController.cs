using HR.Core.BasicContract;
using HR.DataAccess.EF;
using HR.DataAccess.EF.UnityOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Web_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //private readonly IRepository<HR.Core.Models.Account, long> unityOfWork;
        private IGlobalUnityOfWork<HR_DataContext, HR_DataContext, HR_DataContext, HR.DataAccess.EF.Repositories.Repository<HR.Core.Models.Account, long>> unityOfWork;

        public HomeController(IGlobalUnityOfWork<HR_DataContext, HR_DataContext, HR_DataContext, HR.DataAccess.EF.Repositories.Repository<HR.Core.Models.Account, long>> _unityOfWork)
        {
            this.unityOfWork = _unityOfWork;
        }

        public ActionResult Index()
        {
            var account = unityOfWork.AccountRepository.GetAll().ToList();

            using (var db = new HR_DataContext())
            {
                var x = db.Account.ToList();
                var z = x.Count;
            }

            return View();
        }

        public ActionResult UserView()
        {
            return View();
        }

        public ActionResult ManagerView()
        {

            using (var db = new HR_DataContext())
            {
                var x = db.Persons.ToList();
                var z = x.Count;
            }
            return View();
        }
    }
}