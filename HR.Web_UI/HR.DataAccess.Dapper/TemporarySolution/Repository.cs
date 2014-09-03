using HR.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;
using Dapper;

namespace HR.DataAccess.Dapper.TemporarySolution
{
    public class Repository : IRepository
    {
        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HR_Database"].ToString());
            }
        }

        //http://build-failed.blogspot.com/2012/10/going-micro-orm-way-with-dapper.html
        
        //operacje dapper
        //http://liangwu.wordpress.com/2012/08/16/dapper-net-samples/

        public Repository()
        {
            
        }

        public bool InsertPersons(List<Person> persons)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                int c = cn.Query<int>("select count (*) from Persons;").Single();

                //int countBeforeInsert = cn.Count<Person>(null);

                //Person pers = cn.Query<Person>("select * from Persons;").First();

                //Person pers = cn.QueryMultiple<Person>.Map

                var i = cn.Query(
                        @"
                            insert Suppliers(CompanyName, Address)
                            values (@CompanyName, @Address)
                            select cast(scope_identity() as int)
                        ", persons.FirstOrDefault()).First(); 

                var id = cn.Insert<Person>(persons.First());

                int countAfterInsert = cn.Count<Person>(null);

                //commit
            }

            return true;
        }

        public bool InsertEmployees(List<Core.Models.Employment> employees)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Models.Person> GetAllWorkers()
        {
            throw new NotImplementedException();
        }
    }
}
