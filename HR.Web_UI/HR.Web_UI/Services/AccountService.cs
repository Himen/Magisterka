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

namespace HR.Web_UI.Services
{
    public class AccountService : IAccountService
    {
        IAdminUnityOfWork<EF_R.Repository<Account, long>, EF_R.Repository<Person, long>, EF_U.UnityOfWork> admUnityOfWork;

        public AccountService(IAdminUnityOfWork<EF_R.Repository<Account, long>, EF_R.Repository<Person, long>, EF_U.UnityOfWork> _admUnityOfWork)
        {
            this.admUnityOfWork = _admUnityOfWork;
        }

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
    }
}