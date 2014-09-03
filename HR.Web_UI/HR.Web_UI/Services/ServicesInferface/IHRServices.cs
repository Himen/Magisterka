using HR.Core.Enums;
using HR.Core.Models;
using HR.Core.Models.RepoModels;
using HR.Web_UI.Models.ViewModels.Calendar;
using HR.Web_UI.Models.ViewModels.HR;
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
        bool CheckEmailExist(PersonViewModel pVM);
        Person CreateWorker(PersonViewModel pVM);
        bool DeleteWorker(long id);
        Person GetWorker(long id);

        List<SelectListItem> BanksSelectListItem();
        List<SelectListItem> CollegesSelectListItem();
        List<SelectListItem> CompaniesSelectListItem();
        List<SelectListItem> PositionsSelectListItem();

        List<SelectListItem> OrganizationalUnitSelectListItem();

        AdditionalInformation CreateAdditionalInfo(AdditionalInformationViewModel aiVM, Person p);
        Employment CreateEmployment(EmploymentViewModel eVM,Person p);
        ContactPerson CreateContactPerson(ContactPersonViewModel cpVM, Person p);

        PersonDisplayViewModel GetAllPersonData(long id);

        bool AddNewPersonCollage(CollegesViewModel cVm, long Id);

        bool AddNewPersonJob(EmploymentsViewModel eVM, long Id);

        bool AddNewPersonTrainings(TraningsViewModel tVM, long Id);

        IEnumerable<CollegesViewModel> GetAllColleges(long id);

        IEnumerable<EmploymentsViewModel> GetAllJobs(long id);

        IEnumerable<Person> GetAllWorkers();

        IEnumerable<Person> GetAllCandidats();

        IEnumerable<TraningsViewModel> GetAllTrainings(long id);

        List<SelectListItem> GetAllManagersSelectList();

        bool EmployCandidate(long id, EmploymentType emp);

        IEnumerable<BenefitsProfit> GetAllWorkerBenefits(long Id);

        string GetPositionName(string key);
        string GetOrganizationName(string key);

        IQueryable<PromotialMaterial> GetAllMaterials();
        bool AddPromotialMaterial(PromotialMaterial prom);

        List<Document> GetWorkerDocuments(long id);
        bool SaveDocument(Document doc);

        List<CalendarEvent> GetWorkerEvents(long id);

        bool InsertPersons(List<Person> persons);

        bool InsertEmployees(List<Employment> employees);

    }
}
