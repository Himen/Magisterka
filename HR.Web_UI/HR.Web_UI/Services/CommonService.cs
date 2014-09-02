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

namespace HR.Web_UI.Services
{
    public class CommonService : ICommonService
    {
#if NH
        IEmploymentUnityOfWork<NH_R.Repository<OrganiziationalUnit, long>, NH_R.Repository<BankAccount, long>, 
            NH_R.Repository<Employment, long>, NH_R.Repository<Contract, long>, NH_R.Repository<ContactPerson, long>, 
            NH_R.Repository<Person, long>, NH_U.UnityOfWork> employmentUnityOfWork;

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

        public CommonService(IEmploymentUnityOfWork<EF_R.Repository<OrganiziationalUnit, long>, 
            EF_R.Repository<BankAccount, long>, EF_R.Repository<Employment, long>, EF_R.Repository<Contract, long>, 
            EF_R.Repository<ContactPerson, long>, EF_R.Repository<Person, long>, EF_U.UnityOfWork> _employmentUnityOfWork,
            IHRUnityOfWork<EF_R.Repository<Person, long>, EF_R.Repository<Account, long>, EF_R.Repository<AdditionalInformation, long>, 
            EF_R.Repository<College, long>, EF_R.Repository<Job, long>, EF_R.Repository<Training, long>,EF_R.Repository<PromotialMaterial, long>,
            EF_R.Repository<Document, long>,EF_U.UnityOfWork> _personUnityOfWork)
        {
            this.employmentUnityOfWork = _employmentUnityOfWork;
            this.personUnityOfWork = _personUnityOfWork;
        }
#else

#endif


        public IQueryable<PromotialMaterial> GetAllMaterials()
        {
            try
            {
                var x = personUnityOfWork.PromotialMaterialsRepo.GetAll();
                return x;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}