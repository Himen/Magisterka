using HR.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;

namespace HR.DataAccess.Dapper
{
    public class Class1
    {
        public Class1()
        {
            /*using (SqlConnection conn = new SqlConnection("<conn string>"))
            {
                conn.Open();

                int countBeforeInsert = conn.Count<Person>(null);

                conn.Insert<Person>(new Person { Age = 33, Name = "John Smith" });
                conn.Insert<Person>(new Person { Age = 64, Name = "Mary Kole" });

                int countAfterInsert = conn.Count<Person>(null);

                

                IList<Person> persons = conn.GetList<Person>(
                    Predicates.Field<Person>(f => f.Age, Operator.Gt, 35))
                    .ToList();
            }*/
        }
        //http://www.contentedcoder.com/2012/12/creating-data-repository-using-dapper.html
        //pomyslec nad fluent dapper
        //http://henkmollema.github.io/Dapper-FluentMap/
    }
}
