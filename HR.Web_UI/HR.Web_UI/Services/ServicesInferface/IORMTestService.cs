using HR.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Web_UI.Services.ServicesInferface
{
    public interface IORMTestService
    {
        bool InsertPersonsEF(List<Person> persons);
        bool InsertEmployeesEF(List<Employment> employees);
        IEnumerable<Person> GetAllWorkersEF();
        bool DeletePersonsEF(List<Employment> employees);
        bool UpdatePersonsEF(List<Person> persons);

        bool InsertPersonsNH(List<Person> persons);
        bool InsertEmployeesNH(List<Employment> employees);
        IEnumerable<Person> GetAllWorkersNH();

        bool InsertPersonsDAP(List<Person> persons);
        bool InsertEmployeesDAP(List<Employment> employees);
        IEnumerable<Person> GetAllWorkersDAP();

    }
}
