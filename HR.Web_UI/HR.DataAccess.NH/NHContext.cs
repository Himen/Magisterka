using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HR.Core.Models;
using HR.DataAccess.NH.Mappings;
using NHibernate;
using NHibernate.Cache;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.NH
{
    public class NHContext
    {
        //powinien byc const ale nie dzialalo, spr potem
        //private static string CONNECTION_STRING = System.Configuration.ConfigurationManager.ConnectionStrings["HR_Database"].ToString();

        private static ISessionFactory sessionFactory;

        private static ISessionFactory SessionFactory 
        {
            get
            {
                if (sessionFactory == null)
                    InitializeSessionFactory();

                return sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            sessionFactory = Fluently.Configure()
                            .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c =>
                                c.FromConnectionStringWithKey("HR_Database1")))
                            .Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>())

                            .Mappings(m => m.FluentMappings.Add<AccountMapper>())
                            .Mappings(m => m.FluentMappings.Add<AccountLogMapper>())
                            .Mappings(m => m.FluentMappings.Add<AdditionalInformationMapper>())
                            .Mappings(m => m.FluentMappings.Add<BankAccountMapper>())
                            .Mappings(m => m.FluentMappings.Add<BankDictionaryMapper>())
                            .Mappings(m => m.FluentMappings.Add<BenefitsProfitMapper>())
                            .Mappings(m => m.FluentMappings.Add<CollageMapper>())
                            .Mappings(m => m.FluentMappings.Add<CollegesDictionaryMapper>())
                            .Mappings(m => m.FluentMappings.Add<CompaniesDictionaryMapper>())
                            .Mappings(m => m.FluentMappings.Add<ContactPersonMapper>())
                            .Mappings(m => m.FluentMappings.Add<ContractMapper>())
                            .Mappings(m => m.FluentMappings.Add<CourseMaterialMapper>())
                            .Mappings(m => m.FluentMappings.Add<DelegationMapper>())
                            .Mappings(m => m.FluentMappings.Add<DocumentMapper>())
                            .Mappings(m => m.FluentMappings.Add<EmploymentMapper>())
                            .Mappings(m => m.FluentMappings.Add<JobMapper>())
                            .Mappings(m => m.FluentMappings.Add<OrganiziationalUnitMapper>())
                            .Mappings(m => m.FluentMappings.Add<PersonMapper>())
                            .Mappings(m => m.FluentMappings.Add<PromotialMaterialMapper>())
                            .Mappings(m => m.FluentMappings.Add<TraningMapper>())
                            .Mappings(m => m.FluentMappings.Add<VacationDocumentMapper>())
                            .Mappings(m => m.FluentMappings.Add<VacationMapper>())
                            .Mappings(m => m.FluentMappings.Add<WorkRegistryMapper>())

                            .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                            .BuildConfiguration()
                            .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }



        



        /*private static Configuration GetConfiguration()
        {
            var cfg = new Configuration();
            cfg.SessionFactory()
            .Proxy
            .Through<ProxyFactoryFactory>()
            .Mapping
            .UsingDefaultCatalog("sampleCatalog")
            .UsingDefaultSchema("dbo")
            .Integrate
            .LogSqlInConsole()
            .Using<MsSql2012Dialect>()
            .Connected
            .Through<DriverConnectionProvider>()
            .By<MsSql2012Dialect>()
            .ByAppConfing("Sample");
            cfg.AddAssembly(typeof(Person).Assembly);
            return cfg;
        }
        /*public NHContext()
        {
            Fluently.Configure()
                        .Database(MsSqlConfiguration
                        .MsSql2012
                        .ConnectionString(CONNECTION_STRING))
                        .Mappings(m => m.FluentMappings
                        .AddFromAssemblyOf<AccountMapper>())
                        .ExposeConfiguration(CreateSchema)
                        .BuildConfiguration();
        }

        private static void CreateSchema(Configuration cfg)
        {
            var schemaExport = new SchemaExport(cfg);
            schemaExport.Drop(false, true);
            schemaExport.Create(false, true);
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
            .Database(MsSqlConfiguration
            .MsSql2012
            .ConnectionString(CONNECTION_STRING))
            .Mappings(m => m.FluentMappings
            .AddFromAssemblyOf<AccountMapper>())
            .BuildSessionFactory();
        }*/
    }
}
