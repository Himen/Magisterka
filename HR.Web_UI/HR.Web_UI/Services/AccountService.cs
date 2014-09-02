#define EF

using HR.Core.Models;
using HR.DataAccess.GLOBAL.UnityOfWorks;
using HR.Web_UI.Services.ServicesInferface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF_R = HR.DataAccess.EF.Repositories;
using NH_R = HR.DataAccess.NH.Repositories;
using EF_U = HR.DataAccess.EF.UnityOfWorks;
using NH_U = HR.DataAccess.NH.UnityOfWorks;
using HR.Web_UI.Models.ViewModels.Account;
using HR.Core.Enums;

namespace HR.Web_UI.Services
{
    public class AccountService : IAccountService
    {
#if NH
        IAdminUnityOfWork<NH_R.Repository<Account, long>, NH_R.Repository<Person, long>, NH_U.UnityOfWork> admUnityOfWork;
        ILogUnityOfWork<NH_R.Repository<AccountLog, long>, NH_R.Repository<Account, long>, NH_U.UnityOfWork> logUnityOfWork;

        public AccountService(IAdminUnityOfWork<NH_R.Repository<Account, long>, NH_R.Repository<Person, long>, NH_U.UnityOfWork> _admUnityOfWork,
                              ILogUnityOfWork<NH_R.Repository<AccountLog, long>, NH_R.Repository<Account, long>, NH_U.UnityOfWork> _logUnityOfWork)
        {
            this.admUnityOfWork = _admUnityOfWork;
            this.logUnityOfWork = _logUnityOfWork;
        }
#elif EF
        IAdminUnityOfWork<EF_R.Repository<Account, long>, EF_R.Repository<Person, long>, EF_U.UnityOfWork> admUnityOfWork;
        ILogUnityOfWork<EF_R.Repository<AccountLog, long>, EF_R.Repository<Account, long>, EF_U.UnityOfWork> logUnityOfWork;

        public AccountService(IAdminUnityOfWork<EF_R.Repository<Account, long>, EF_R.Repository<Person, long>, EF_U.UnityOfWork> _admUnityOfWork,
                              ILogUnityOfWork<EF_R.Repository<AccountLog, long>, EF_R.Repository<Account, long>, EF_U.UnityOfWork> _logUnityOfWork)
        {
            this.admUnityOfWork = _admUnityOfWork;
            this.logUnityOfWork = _logUnityOfWork;
        }
#else

#endif


        public Account GetUserByName(string name)
        {
            try
            {
                
                var x = admUnityOfWork.PersonRepo.GetAll().Where(c => c.Account.UserName == name).FirstOrDefault();
                return x.Account;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                admUnityOfWork.UnityOfWork.Dispose();
            }
        }
        public CurrentUserModel MapAccount(Account ac)
        {
            try
            {
                CurrentUserModel cr = new CurrentUserModel 
                {
                    AccountType = ac.AccountType,
                    Password = ac.Password,
                    UserName = ac.UserName,
                    AccountId = ac.Id,
                    PersonId = ac.Person.Id
                };
                return cr;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public bool LogAction_LOGIN(Account ac,string clientIP)
        {
            try
            {
                logUnityOfWork.AccountRepo.Attach(ref ac);

                AccountLog al = new AccountLog
                {
                    Account = ac,
                    Action = "Uzytkownik "+ ac.UserName + " logował się do konta z adresu "  + clientIP,
                    ActionDescription = "Użytkownik zalogowal się pomyślnie o "+ DateTime.Now,
                    ActionType = ActionType.Login,
                    EndDate = DateTime.Now,
                    StartDate = DateTime.Now
                };

                
                logUnityOfWork.AccountLogRepo.Add(al);
                logUnityOfWork.UnityOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool LogAction_LOGOUT(CurrentUserModel cuM, string clientIP)
        {
            try
            {
#warning do poprawy
                Account ac = logUnityOfWork.AccountRepo.GetById(cuM.AccountId);
                logUnityOfWork.AccountRepo.Attach(ref ac);
                AccountLog al = new AccountLog
                {

                    Account = ac,
                    Action = "Uzytkownik " + cuM.UserName + " wylogował się do konta z adresu " + clientIP,
                    ActionDescription = "Użytkownik wylogowal się pomyślnie o " + DateTime.Now,
                    ActionType = ActionType.LogOut,
                    EndDate = DateTime.Now,
                    StartDate = DateTime.Now
                };

                logUnityOfWork.AccountLogRepo.Add(al);
                logUnityOfWork.UnityOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                logUnityOfWork.UnityOfWork.Dispose();
            }
        }
    }
}