using HR.Core.Enums;
using HR.Core.Models;
using HR.Web_UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HR.Web_UI.Services.ServicesInferface
{
    public interface IHRServices
    {
        Person CreateWorker(PersonViewModel pVM);
        bool DeleteWorker(long id);

        List<SelectListItem> BanksSelectListItem();
        List<SelectListItem> CollegesSelectListItem();
        List<SelectListItem> CompaniesSelectListItem();
        List<SelectListItem> PositionsSelectListItem();

        List<SelectListItem> OrganizationalUnitSelectListItem();

        AdditionalInformation CreateAdditionalInfo(AdditionalInformationViewModel aiVM, Person p);
        Employment CreateEmployment(EmploymentViewModel eVM,Person p);
        ContactPerson CreateContactPerson(ContactPersonViewModel cpVM, Person p);

        PersonDisplayViewModel GetAllPersonData(long id);

        bool AddNewPersonCollage(CollegesViewModel cVm, Person p);

        bool AddNewPersonJob(EmploymentsViewModel eVM, Person p);

        IEnumerable<CollegesViewModel> GetAllColleges(long id);

        IEnumerable<EmploymentsViewModel> GetAllJobs(long id);

        IEnumerable<Person> GetAllWorkers();

        IEnumerable<Person> GetAllCandidats();

        List<SelectListItem> GetAllManagersSelectList();

        bool EmployCandidate(long id, EmploymentType emp);

    }
}
