[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(HR.Web_UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(HR.Web_UI.App_Start.NinjectWebCommon), "Stop")]

namespace HR.Web_UI.App_Start
{

using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using System.Web.Configuration;
using HR.Core.BasicContract;
    using HR.DataAccess.EF;
    using HR.Core.Models;
    using HR.DataAccess.GLOBAL.UnityOfWork;
    using NHibernate;
    using HR.DataAccess.EF.Repositories;
    using HR.DataAccess.GLOBAL.UnityOfWorks;
    using HR.Web_UI.Services.ServicesInferface;
    using HR.Web_UI.Services;
    using HR.Core.Models.DictionaryModels;
    using HR.Core.Models.RepoModels;

    public static class NinjectWebCommon 
    {
        private static readonly string ormType = WebConfigurationManager.AppSettings["ORM"];
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {             
            switch (ormType)
            {
                case "EF":

                    kernel.Bind<IAdminUnityOfWork<HR.DataAccess.EF.Repositories.Repository<Account, long>, HR.DataAccess.EF.Repositories.Repository<Person, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>()
                        .To<AdminUnityOfWork<HR.DataAccess.EF.Repositories.Repository<Account, long>, HR.DataAccess.EF.Repositories.Repository<Person, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<IHRUnityOfWork<HR.DataAccess.EF.Repositories.Repository<Person, long>, HR.DataAccess.EF.Repositories.Repository<Account, long>, HR.DataAccess.EF.Repositories.Repository<AdditionalInformation, long>, HR.DataAccess.EF.Repositories.Repository<College, long>, HR.DataAccess.EF.Repositories.Repository<Job, long>, HR.DataAccess.EF.Repositories.Repository<Training, long>, HR.DataAccess.EF.Repositories.Repository<PromotialMaterial, long>, HR.DataAccess.EF.Repositories.Repository<Document, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>()
                        .To<HRUnityOfWork<HR.DataAccess.EF.Repositories.Repository<Person, long>, HR.DataAccess.EF.Repositories.Repository<Account, long>, HR.DataAccess.EF.Repositories.Repository<AdditionalInformation, long>, HR.DataAccess.EF.Repositories.Repository<College, long>, HR.DataAccess.EF.Repositories.Repository<Job, long>, HR.DataAccess.EF.Repositories.Repository<Training, long>, HR.DataAccess.EF.Repositories.Repository<PromotialMaterial, long>, HR.DataAccess.EF.Repositories.Repository<Document, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<ILogUnityOfWork<HR.DataAccess.EF.Repositories.Repository<AccountLog, long>, HR.DataAccess.EF.Repositories.Repository<Account, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>()
                        .To<LogUnityOfWork<HR.DataAccess.EF.Repositories.Repository<AccountLog, long>, HR.DataAccess.EF.Repositories.Repository<Account, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<IDicUnityOfWork<HR.DataAccess.EF.Repositories.Repository<BankDictionary, long>, HR.DataAccess.EF.Repositories.Repository<CollegesDictionary, long>, HR.DataAccess.EF.Repositories.Repository<CompaniesDictionary, long>, HR.DataAccess.EF.Repositories.Repository<Position, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>()
                        .To<DicUnityOfWork<HR.DataAccess.EF.Repositories.Repository<BankDictionary, long>, HR.DataAccess.EF.Repositories.Repository<CollegesDictionary, long>, HR.DataAccess.EF.Repositories.Repository<CompaniesDictionary, long>, HR.DataAccess.EF.Repositories.Repository<Position, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<IEmploymentUnityOfWork<HR.DataAccess.EF.Repositories.Repository<OrganiziationalUnit, long>, HR.DataAccess.EF.Repositories.Repository<BankAccount, long>, HR.DataAccess.EF.Repositories.Repository<Employment, long>, HR.DataAccess.EF.Repositories.Repository<Contract, long>, HR.DataAccess.EF.Repositories.Repository<ContactPerson, long>, HR.DataAccess.EF.Repositories.Repository<Person, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>()
                        .To<EmploymentUnityOfWork<HR.DataAccess.EF.Repositories.Repository<OrganiziationalUnit, long>, HR.DataAccess.EF.Repositories.Repository<BankAccount, long>, HR.DataAccess.EF.Repositories.Repository<Employment, long>, HR.DataAccess.EF.Repositories.Repository<Contract, long>, HR.DataAccess.EF.Repositories.Repository<ContactPerson, long>, HR.DataAccess.EF.Repositories.Repository<Person, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<IWorkRegistryUnityOfWork<HR.DataAccess.EF.Repositories.Repository<Person, long>, HR.DataAccess.EF.Repositories.Repository<BenefitsProfit, long>, HR.DataAccess.EF.Repositories.Repository<WorkRegistry, long>, HR.DataAccess.EF.Repositories.Repository<Vacation, long>, HR.DataAccess.EF.Repositories.Repository<Delegation, long>, HR.DataAccess.EF.Repositories.Repository<VacationDocument, Guid>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>()
                        .To<WorkRegistryUnityOfWork<HR.DataAccess.EF.Repositories.Repository<Person, long>, HR.DataAccess.EF.Repositories.Repository<BenefitsProfit, long>, HR.DataAccess.EF.Repositories.Repository<WorkRegistry, long>, HR.DataAccess.EF.Repositories.Repository<Vacation, long>, HR.DataAccess.EF.Repositories.Repository<Delegation, long>, HR.DataAccess.EF.Repositories.Repository<VacationDocument, Guid>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>();

                    break;
                case "NH":
                    kernel.Bind<IAdminUnityOfWork<HR.DataAccess.NH.Repositories.Repository<Account, long>, HR.DataAccess.NH.Repositories.Repository<Person, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>()
                        .To<AdminUnityOfWork<HR.DataAccess.NH.Repositories.Repository<Account, long>, HR.DataAccess.NH.Repositories.Repository<Person, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<IHRUnityOfWork<HR.DataAccess.NH.Repositories.Repository<Person, long>, HR.DataAccess.NH.Repositories.Repository<Account, long>, HR.DataAccess.NH.Repositories.Repository<AdditionalInformation, long>, HR.DataAccess.NH.Repositories.Repository<College, long>, HR.DataAccess.NH.Repositories.Repository<Job, long>, HR.DataAccess.NH.Repositories.Repository<Training, long>, HR.DataAccess.NH.Repositories.Repository<PromotialMaterial, long>, HR.DataAccess.NH.Repositories.Repository<Document, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>()
                        .To<HRUnityOfWork<HR.DataAccess.NH.Repositories.Repository<Person, long>, HR.DataAccess.NH.Repositories.Repository<Account, long>, HR.DataAccess.NH.Repositories.Repository<AdditionalInformation, long>, HR.DataAccess.NH.Repositories.Repository<College, long>, HR.DataAccess.NH.Repositories.Repository<Job, long>, HR.DataAccess.NH.Repositories.Repository<Training, long>, HR.DataAccess.NH.Repositories.Repository<PromotialMaterial, long>, HR.DataAccess.NH.Repositories.Repository<Document, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<ILogUnityOfWork<HR.DataAccess.NH.Repositories.Repository<AccountLog, long>, HR.DataAccess.NH.Repositories.Repository<Account, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>()
                        .To<LogUnityOfWork<HR.DataAccess.NH.Repositories.Repository<AccountLog, long>, HR.DataAccess.NH.Repositories.Repository<Account, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<IDicUnityOfWork<HR.DataAccess.NH.Repositories.Repository<BankDictionary, long>, HR.DataAccess.NH.Repositories.Repository<CollegesDictionary, long>, HR.DataAccess.NH.Repositories.Repository<CompaniesDictionary, long>, HR.DataAccess.NH.Repositories.Repository<Position, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>()
                        .To<DicUnityOfWork<HR.DataAccess.NH.Repositories.Repository<BankDictionary, long>, HR.DataAccess.NH.Repositories.Repository<CollegesDictionary, long>, HR.DataAccess.NH.Repositories.Repository<CompaniesDictionary, long>, HR.DataAccess.NH.Repositories.Repository<Position, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<IEmploymentUnityOfWork<HR.DataAccess.NH.Repositories.Repository<OrganiziationalUnit, long>, HR.DataAccess.NH.Repositories.Repository<BankAccount, long>, HR.DataAccess.NH.Repositories.Repository<Employment, long>, HR.DataAccess.NH.Repositories.Repository<Contract, long>, HR.DataAccess.NH.Repositories.Repository<ContactPerson, long>, HR.DataAccess.NH.Repositories.Repository<Person, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>()
                        .To<EmploymentUnityOfWork<HR.DataAccess.NH.Repositories.Repository<OrganiziationalUnit, long>, HR.DataAccess.NH.Repositories.Repository<BankAccount, long>, HR.DataAccess.NH.Repositories.Repository<Employment, long>, HR.DataAccess.NH.Repositories.Repository<Contract, long>, HR.DataAccess.NH.Repositories.Repository<ContactPerson, long>, HR.DataAccess.NH.Repositories.Repository<Person, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<IWorkRegistryUnityOfWork<HR.DataAccess.NH.Repositories.Repository<Person, long>, HR.DataAccess.NH.Repositories.Repository<BenefitsProfit, long>, HR.DataAccess.NH.Repositories.Repository<WorkRegistry, long>, HR.DataAccess.NH.Repositories.Repository<Vacation, long>, HR.DataAccess.NH.Repositories.Repository<Delegation, long>, HR.DataAccess.NH.Repositories.Repository<VacationDocument, Guid>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>()
                        .To<WorkRegistryUnityOfWork<HR.DataAccess.NH.Repositories.Repository<Person, long>, HR.DataAccess.NH.Repositories.Repository<BenefitsProfit, long>, HR.DataAccess.NH.Repositories.Repository<WorkRegistry, long>, HR.DataAccess.NH.Repositories.Repository<Vacation, long>, HR.DataAccess.NH.Repositories.Repository<Delegation, long>, HR.DataAccess.NH.Repositories.Repository<VacationDocument, Guid>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>();

                    break;

                case "DAPPER":

                    break;
                case "ALL":

                    kernel.Bind<IAdminUnityOfWork<HR.DataAccess.EF.Repositories.Repository<Account, long>, HR.DataAccess.EF.Repositories.Repository<Person, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>()
                        .To<AdminUnityOfWork<HR.DataAccess.EF.Repositories.Repository<Account, long>, HR.DataAccess.EF.Repositories.Repository<Person, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<IHRUnityOfWork<HR.DataAccess.EF.Repositories.Repository<Person, long>, HR.DataAccess.EF.Repositories.Repository<Account, long>, HR.DataAccess.EF.Repositories.Repository<AdditionalInformation, long>, HR.DataAccess.EF.Repositories.Repository<College, long>, HR.DataAccess.EF.Repositories.Repository<Job, long>, HR.DataAccess.EF.Repositories.Repository<Training, long>, HR.DataAccess.EF.Repositories.Repository<PromotialMaterial, long>, HR.DataAccess.EF.Repositories.Repository<Document, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>()
                        .To<HRUnityOfWork<HR.DataAccess.EF.Repositories.Repository<Person, long>, HR.DataAccess.EF.Repositories.Repository<Account, long>, HR.DataAccess.EF.Repositories.Repository<AdditionalInformation, long>, HR.DataAccess.EF.Repositories.Repository<College, long>, HR.DataAccess.EF.Repositories.Repository<Job, long>, HR.DataAccess.EF.Repositories.Repository<Training, long>, HR.DataAccess.EF.Repositories.Repository<PromotialMaterial, long>, HR.DataAccess.EF.Repositories.Repository<Document, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<ILogUnityOfWork<HR.DataAccess.EF.Repositories.Repository<AccountLog, long>, HR.DataAccess.EF.Repositories.Repository<Account, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>()
                        .To<LogUnityOfWork<HR.DataAccess.EF.Repositories.Repository<AccountLog, long>, HR.DataAccess.EF.Repositories.Repository<Account, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<IDicUnityOfWork<HR.DataAccess.EF.Repositories.Repository<BankDictionary, long>, HR.DataAccess.EF.Repositories.Repository<CollegesDictionary, long>, HR.DataAccess.EF.Repositories.Repository<CompaniesDictionary, long>, HR.DataAccess.EF.Repositories.Repository<Position, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>()
                        .To<DicUnityOfWork<HR.DataAccess.EF.Repositories.Repository<BankDictionary, long>, HR.DataAccess.EF.Repositories.Repository<CollegesDictionary, long>, HR.DataAccess.EF.Repositories.Repository<CompaniesDictionary, long>, HR.DataAccess.EF.Repositories.Repository<Position, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<IEmploymentUnityOfWork<HR.DataAccess.EF.Repositories.Repository<OrganiziationalUnit, long>, HR.DataAccess.EF.Repositories.Repository<BankAccount, long>, HR.DataAccess.EF.Repositories.Repository<Employment, long>, HR.DataAccess.EF.Repositories.Repository<Contract, long>, HR.DataAccess.EF.Repositories.Repository<ContactPerson, long>, HR.DataAccess.EF.Repositories.Repository<Person, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>()
                        .To<EmploymentUnityOfWork<HR.DataAccess.EF.Repositories.Repository<OrganiziationalUnit, long>, HR.DataAccess.EF.Repositories.Repository<BankAccount, long>, HR.DataAccess.EF.Repositories.Repository<Employment, long>, HR.DataAccess.EF.Repositories.Repository<Contract, long>, HR.DataAccess.EF.Repositories.Repository<ContactPerson, long>, HR.DataAccess.EF.Repositories.Repository<Person, long>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<IWorkRegistryUnityOfWork<HR.DataAccess.EF.Repositories.Repository<Person, long>, HR.DataAccess.EF.Repositories.Repository<BenefitsProfit, long>, HR.DataAccess.EF.Repositories.Repository<WorkRegistry, long>, HR.DataAccess.EF.Repositories.Repository<Vacation, long>, HR.DataAccess.EF.Repositories.Repository<Delegation, long>, HR.DataAccess.EF.Repositories.Repository<VacationDocument, Guid>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>()
                        .To<WorkRegistryUnityOfWork<HR.DataAccess.EF.Repositories.Repository<Person, long>, HR.DataAccess.EF.Repositories.Repository<BenefitsProfit, long>, HR.DataAccess.EF.Repositories.Repository<WorkRegistry, long>, HR.DataAccess.EF.Repositories.Repository<Vacation, long>, HR.DataAccess.EF.Repositories.Repository<Delegation, long>, HR.DataAccess.EF.Repositories.Repository<VacationDocument, Guid>, HR.DataAccess.EF.UnityOfWorks.UnityOfWork>>();

                    kernel.Bind<IAdminUnityOfWork<HR.DataAccess.NH.Repositories.Repository<Account, long>, HR.DataAccess.NH.Repositories.Repository<Person, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>()
                        .To<AdminUnityOfWork<HR.DataAccess.NH.Repositories.Repository<Account, long>, HR.DataAccess.NH.Repositories.Repository<Person, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<IHRUnityOfWork<HR.DataAccess.NH.Repositories.Repository<Person, long>, HR.DataAccess.NH.Repositories.Repository<Account, long>, HR.DataAccess.NH.Repositories.Repository<AdditionalInformation, long>, HR.DataAccess.NH.Repositories.Repository<College, long>, HR.DataAccess.NH.Repositories.Repository<Job, long>, HR.DataAccess.NH.Repositories.Repository<Training, long>, HR.DataAccess.NH.Repositories.Repository<PromotialMaterial, long>, HR.DataAccess.NH.Repositories.Repository<Document, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>()
                        .To<HRUnityOfWork<HR.DataAccess.NH.Repositories.Repository<Person, long>, HR.DataAccess.NH.Repositories.Repository<Account, long>, HR.DataAccess.NH.Repositories.Repository<AdditionalInformation, long>, HR.DataAccess.NH.Repositories.Repository<College, long>, HR.DataAccess.NH.Repositories.Repository<Job, long>, HR.DataAccess.NH.Repositories.Repository<Training, long>, HR.DataAccess.NH.Repositories.Repository<PromotialMaterial, long>, HR.DataAccess.NH.Repositories.Repository<Document, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<ILogUnityOfWork<HR.DataAccess.NH.Repositories.Repository<AccountLog, long>, HR.DataAccess.NH.Repositories.Repository<Account, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>()
                        .To<LogUnityOfWork<HR.DataAccess.NH.Repositories.Repository<AccountLog, long>, HR.DataAccess.NH.Repositories.Repository<Account, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<IDicUnityOfWork<HR.DataAccess.NH.Repositories.Repository<BankDictionary, long>, HR.DataAccess.NH.Repositories.Repository<CollegesDictionary, long>, HR.DataAccess.NH.Repositories.Repository<CompaniesDictionary, long>, HR.DataAccess.NH.Repositories.Repository<Position, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>()
                        .To<DicUnityOfWork<HR.DataAccess.NH.Repositories.Repository<BankDictionary, long>, HR.DataAccess.NH.Repositories.Repository<CollegesDictionary, long>, HR.DataAccess.NH.Repositories.Repository<CompaniesDictionary, long>, HR.DataAccess.NH.Repositories.Repository<Position, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<IEmploymentUnityOfWork<HR.DataAccess.NH.Repositories.Repository<OrganiziationalUnit, long>, HR.DataAccess.NH.Repositories.Repository<BankAccount, long>, HR.DataAccess.NH.Repositories.Repository<Employment, long>, HR.DataAccess.NH.Repositories.Repository<Contract, long>, HR.DataAccess.NH.Repositories.Repository<ContactPerson, long>, HR.DataAccess.NH.Repositories.Repository<Person, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>()
                        .To<EmploymentUnityOfWork<HR.DataAccess.NH.Repositories.Repository<OrganiziationalUnit, long>, HR.DataAccess.NH.Repositories.Repository<BankAccount, long>, HR.DataAccess.NH.Repositories.Repository<Employment, long>, HR.DataAccess.NH.Repositories.Repository<Contract, long>, HR.DataAccess.NH.Repositories.Repository<ContactPerson, long>, HR.DataAccess.NH.Repositories.Repository<Person, long>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>();
                    kernel.Bind<IWorkRegistryUnityOfWork<HR.DataAccess.NH.Repositories.Repository<Person, long>, HR.DataAccess.NH.Repositories.Repository<BenefitsProfit, long>, HR.DataAccess.NH.Repositories.Repository<WorkRegistry, long>, HR.DataAccess.NH.Repositories.Repository<Vacation, long>, HR.DataAccess.NH.Repositories.Repository<Delegation, long>, HR.DataAccess.NH.Repositories.Repository<VacationDocument, Guid>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>()
                        .To<WorkRegistryUnityOfWork<HR.DataAccess.NH.Repositories.Repository<Person, long>, HR.DataAccess.NH.Repositories.Repository<BenefitsProfit, long>, HR.DataAccess.NH.Repositories.Repository<WorkRegistry, long>, HR.DataAccess.NH.Repositories.Repository<Vacation, long>, HR.DataAccess.NH.Repositories.Repository<Delegation, long>, HR.DataAccess.NH.Repositories.Repository<VacationDocument, Guid>, HR.DataAccess.NH.UnityOfWorks.UnityOfWork>>();


                    break;

                default: // ADO
                    break;
            }

            kernel.Bind<IHRServices>().To<HRServices>();
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IManagerService>().To<ManagerService>();
            kernel.Bind<IWorkerService>().To<WorkerService>();
            kernel.Bind<ICommonService>().To<CommonService>();
            kernel.Bind<IORMTestService>().To<ORMTestService>();

        }        
    }
}
