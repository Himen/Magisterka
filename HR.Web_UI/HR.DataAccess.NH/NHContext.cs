using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HR.Core.Models;
using HR.DataAccess.NH.Mappings;
using NHibernate;
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
        private static string CONNECTION_STRING = System.Configuration.ConfigurationManager.ConnectionStrings["HR_Database"].ToString();

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
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(CONNECTION_STRING).ShowSql())
                .Mappings(m => m.FluentMappings
                            .AddFromAssemblyOf<Account>()
                         )
                .ExposeConfiguration(c => new SchemaExport(c).Create(true, true))
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
