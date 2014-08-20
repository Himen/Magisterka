#define EF 

using HR.Core.BasicContract;
using HR.Core.Models;

using HR.DataAccess.EF;
using HR.DataAccess.EF.Repositories;
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



namespace HR.Web_UI.Controllers
{
    /// <summary>
    /// Test Controller 
    /// </summary>
    public class HomeController : Controller
    {
        #region Controler Construktors
        
        

#if NH
        IAdminUnityOfWork<NH_R.Repository<Account, long>, NH_U.UnityOfWork> admUnityOfWork;

        // GET: Home
        public HomeController(IAdminUnityOfWork<NH_R.Repository<Account, long>, NH_U.UnityOfWork> _admUnityOfWork)
        {
            admUnityOfWork = _admUnityOfWork;
        }
#elif EF
        IAdminUnityOfWork<EF_R.Repository<Account, long>, EF_U.UnityOfWork> admUnityOfWork;

        // GET: Home
        public HomeController(IAdminUnityOfWork<EF_R.Repository<Account, long>, EF_U.UnityOfWork> _admUnityOfWork)
        {
            admUnityOfWork = _admUnityOfWork;
        }
#else

#endif
        #endregion

        public ActionResult Index()
        {
            using (var db = new HR_DataContext())
            {
                var x = db.Accounts.Count();
            }
           /* List<Account> list = new List<Account>();
            list.Add(new Account() { AccountType = Core.Enums.AccountType.HR, UserName = "Jacek", Photo = null, Password = "sdadsa", DataState = 1 });
            list.Add(new Account() { AccountType = Core.Enums.AccountType.Kierownik, UserName = "Jacek", Photo = null, Password = "sdadsa",  DataState = 1 });
            list.Add(new Account() { AccountType = Core.Enums.AccountType.Pracownik, UserName = "Jacek", Photo = null, Password = "sdadsa",  DataState = 1 });

            foreach (var item in list)
            {
                admUnityOfWork.AccountRepo.Add(item);
                admUnityOfWork.UnityOfWork.SaveChanges();
                admUnityOfWork.AccountRepo.Remove(item);
            }
            */

            return View();
        }

        public ActionResult UserView()
        {
            return View();
        }

        public ActionResult ManagerView()
        {

            /*using (var db = new HR_DataContext())
            {
                var x = db.Persons.ToList();
                var z = x.Count;
            }*/
            return View();
        }
    }
}