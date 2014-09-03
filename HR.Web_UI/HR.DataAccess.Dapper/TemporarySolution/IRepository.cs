using HR.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.Dapper.TemporarySolution
{
    public interface IRepository
    {
        bool InsertPersons(List<Person> persons);
        bool InsertEmployees(List<Employment> employees);
        IEnumerable<Person> GetAllWorkers();
    }
}
