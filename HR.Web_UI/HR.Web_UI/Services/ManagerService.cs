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

namespace HR.Web_UI.Services
{
    public class ManagerService : IManagerService
    {
        IEmploymentUnityOfWork<EF_R.Repository<OrganiziationalUnit, long>, EF_R.Repository<BankAccount, long>, EF_R.Repository<Employment, long>, EF_R.Repository<Contract, long>, EF_R.Repository<ContactPerson, long>, EF_R.Repository<Person, long>, EF_U.UnityOfWork> employmentUnityOfWork;

        public ManagerService(IEmploymentUnityOfWork<EF_R.Repository<OrganiziationalUnit, long>, EF_R.Repository<BankAccount, long>, EF_R.Repository<Employment, long>, EF_R.Repository<Contract, long>, EF_R.Repository<ContactPerson, long>, EF_R.Repository<Person, long>, EF_U.UnityOfWork> _employmentUnityOfWork)
        {
            this.employmentUnityOfWork = _employmentUnityOfWork;
        }

        public IEnumerable<Person> GetAllWorkersFromTeam(long managerId)
        {
            try
            {
                var x = employmentUnityOfWork.PersonRepo.GetAll().Where(p => p.Manager.Id == managerId).ToList();
                return x;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                employmentUnityOfWork.UnityOfWork.Dispose();
            }
        }
    }
}