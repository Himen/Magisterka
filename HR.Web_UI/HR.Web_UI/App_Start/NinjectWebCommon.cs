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
                     kernel.Bind<IRepository<Account, long>>()
                      .To<HR.DataAccess.EF.Repositories.Repository<Account, long>>()
                      .WithConstructorArgument("dbContext", new HR_DataContext());

                    //jeszcze przemyslec takie rozwiazanie, jak sie nie bedzie dalo to robic tak jak wyzej 
                     kernel.Bind<IGlobalUnityOfWork<HR_DataContext, HR_DataContext, HR_DataContext, HR.DataAccess.EF.Repositories.Repository<Account, long>>>().
                         To<HR.DataAccess.EF.UnityOfWorks.UnityOfWork>();

                    break;
                case "NH":

                    break;

                case "DAPPER":

                    break;
                default: // ADO
                    break;
            }
        }        
    }
}
