﻿using HR.Core.Models;
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

        AdditionalInformation CreateAdditionalInfo(AdditionalInformationViewModel aiVM, Person p);
        Employment CreateEmployment(EmploymentViewModel eVM,Person p);
        ContactPerson CreateContactPerson(ContactPersonViewModel cpVM, Person p);

        PersonDisplayViewModel GetAllPersonData(long id);

    }
}
