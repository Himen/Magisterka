using HR.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        IEnumerable<Employment> GetAllEmployeesEF();
        bool DeleteEmploymentEF(List<Employment> employees);
        bool UpdateEmploymentEF(List<Employment> employees);

        bool InsertPersonsNH(List<Person> persons);
        bool InsertEmployeesNH(List<Employment> employees);
        IEnumerable<Person> GetAllWorkersNH();

        IEnumerable<Employment> GetAllEmployeesNH();

        bool DeleteEmploymentNH(List<Employment> employees);
        bool UpdateEmploymentNH(List<Employment> employees);

        bool InsertPersonsDAP(List<Person> persons, SqlConnection con);
        bool InsertEmployeesDAP(List<Employment> employees, SqlConnection con);
        IEnumerable<Person> GetAllWorkersDAP(SqlConnection con,int ile);

        IEnumerable<Employment> GetAllEmployeesDAP(SqlConnection con, int ile);

        IEnumerable<Person> GetAllWorkersDAPOrder(SqlConnection con, string order, long ile);

        IEnumerable<Person> GetAllWorkersDAPWhere(SqlConnection con, string order, long ile);

        bool DeleteEmploymentDAP(List<Employment> employees, SqlConnection con);
        bool UpdateEmploymentDAP(List<Employment> employees, SqlConnection con);

    }
}
