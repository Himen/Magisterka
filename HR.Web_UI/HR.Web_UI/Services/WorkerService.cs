#define EF

using HR.Web_UI.Services.ServicesInferface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF_R = HR.DataAccess.EF.Repositories;
using NH_R = HR.DataAccess.NH.Repositories;
using EF_U = HR.DataAccess.EF.UnityOfWorks;
using NH_U = HR.DataAccess.NH.UnityOfWorks;
using HR.DataAccess.GLOBAL.UnityOfWorks;
using HR.Core.Models;
using HR.Core.Models.RepoModels;
using HR.Web_UI.Models.ViewModels.Account;

namespace HR.Web_UI.Services
{
    public class WorkerService : IWorkerService
    {

#if NH
        IEmploymentUnityOfWork<NH_R.Repository<OrganiziationalUnit, long>, NH_R.Repository<BankAccount, long>, 
            NH_R.Repository<Employment, long>, NH_R.Repository<Contract, long>, NH_R.Repository<ContactPerson, long>, 
            NH_R.Repository<Person, long>, NH_U.UnityOfWork> employmentUnityOfWork;

        IWorkRegistryUnityOfWork<NH_R.Repository<Person, long>, NH_R.Repository<BenefitsProfit, long>, NH_R.Repository<WorkRegistry, long>,
            NH_R.Repository<Vacation, long>, NH_R.Repository<Delegation, long>, NH_R.Repository<VacationDocument, Guid>,
            NH_U.UnityOfWork> workRegistryUnityOfWork;

        public ManagerService(IEmploymentUnityOfWork<NH_R.Repository<OrganiziationalUnit, long>, 
            NH_R.Repository<BankAccount, long>, NH_R.Repository<Employment, long>, NH_R.Repository<Contract, long>, 
            NH_R.Repository<ContactPerson, long>, NH_R.Repository<Person, long>, NH_U.UnityOfWork> _employmentUnityOfWork)
        {
            this.employmentUnityOfWork = _employmentUnityOfWork;
        }

#elif EF
        IEmploymentUnityOfWork<EF_R.Repository<OrganiziationalUnit, long>, EF_R.Repository<BankAccount, long>, 
            EF_R.Repository<Employment, long>, EF_R.Repository<Contract, long>, EF_R.Repository<ContactPerson, long>, 
            EF_R.Repository<Person, long>, EF_U.UnityOfWork> employmentUnityOfWork;

        IHRUnityOfWork<EF_R.Repository<Person, long>, EF_R.Repository<Account, long>, EF_R.Repository<AdditionalInformation, long>,
            EF_R.Repository<College, long>, EF_R.Repository<Job, long>, EF_R.Repository<Training, long>, EF_R.Repository<PromotialMaterial, long>,
            EF_R.Repository<Document, long>, EF_U.UnityOfWork> personUnityOfWork;

        IWorkRegistryUnityOfWork<EF_R.Repository<Person, long>, EF_R.Repository<BenefitsProfit, long>, EF_R.Repository<WorkRegistry, long>,
            EF_R.Repository<Vacation, long>, EF_R.Repository<Delegation, long>, EF_R.Repository<VacationDocument, Guid>,
            EF_U.UnityOfWork> workRegistryUnityOfWork;

        public WorkerService(IEmploymentUnityOfWork<EF_R.Repository<OrganiziationalUnit, long>, 
            EF_R.Repository<BankAccount, long>, EF_R.Repository<Employment, long>, EF_R.Repository<Contract, long>, 
            EF_R.Repository<ContactPerson, long>, EF_R.Repository<Person, long>, EF_U.UnityOfWork> _employmentUnityOfWork,
            IHRUnityOfWork<EF_R.Repository<Person, long>, EF_R.Repository<Account, long>, EF_R.Repository<AdditionalInformation, long>, 
            EF_R.Repository<College, long>, EF_R.Repository<Job, long>, EF_R.Repository<Training, long>,EF_R.Repository<PromotialMaterial, long>,
            EF_R.Repository<Document, long>,EF_U.UnityOfWork> _personUnityOfWork, IWorkRegistryUnityOfWork<EF_R.Repository<Person, long>, EF_R.Repository<BenefitsProfit, long>, EF_R.Repository<WorkRegistry, long>,
            EF_R.Repository<Vacation, long>, EF_R.Repository<Delegation, long>, EF_R.Repository<VacationDocument, Guid>,
            EF_U.UnityOfWork> _workRegistryUnityOfWork)
        {
            this.employmentUnityOfWork = _employmentUnityOfWork;
            this.personUnityOfWork = _personUnityOfWork;
            this.workRegistryUnityOfWork = _workRegistryUnityOfWork;
        }
#else

#endif



        public AccountViewModel GetAccount(long id)
        {
            try
            {
                var x = personUnityOfWork.AccountRepo.GetById(id);

                AccountViewModel aVM = new AccountViewModel 
                {
                    Id = x.Id,
                    AccountLogs = x.AccountLogs,
                    AccountType = x.AccountType,
                    Password = x.Password,
                    Person = x.Person,
                    Photo = x.Photo,
                    UserName = x.UserName
                };

                return aVM;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public IQueryable<AccountLog> GetUserLogs(long id)
        {
            try
            {
                var x =personUnityOfWork.AccountRepo.GetById(id).AccountLogs.AsQueryable();

                return x;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IEnumerable<BenefitsProfit> GetAllWorkerBenefits(long Id)
        {
            try
            {
                var x = workRegistryUnityOfWork.BenefitProfitsRepo.GetAll().Where(p => p.PersonId == Id);

                return x;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }

        public string GetPositionName(string key)
        {
            try
            {
                return dicUnityOfWork.PositionsRepo.Find(d => d.Id == key).FirstOrDefault().Name;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetOrganizationName(string key)
        {
            try
            {
                return employmentUnityOfWork.OrganizationalUnitRepo.Find(d => d.Id == key).FirstOrDefault().Name;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}