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

        List<SelectListItem> BanksSelectListItem();
        List<SelectListItem> CollegesSelectListItem();
        List<SelectListItem> CompaniesSelectListItem();
        List<SelectListItem> PositionsSelectListItem();

        List<SelectListItem> OrganizationalUnitSelectListItem();

        AdditionalInformation CreateAdditionalInfo();
        Employment CreateEmployment(EmploymentViewModel eVM);
        ContactPerson CreateContactPerson(ContactPersonViewModel cpVM);

    }
}
