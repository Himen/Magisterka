using HR.DataAccess.GLOBAL.UnityOfWorks;
using HR.Web_UI.Services.ServicesInferface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF_R = HR.DataAccess.EF.Repositories;
using NH_R = HR.DataAccess.NH.Repositories;
using EF_U = HR.DataAccess.EF.UnityOfWorks;
using NH_U = HR.DataAccess.NH.UnityOfWorks;
using HR.Core.Models;

namespace HR.Web_UI.Services
{
    public class HRServices :IHRServices
    {
        IHRUnityOfWork<EF_R.Repository<Person, long>, EF_R.Repository<Account, long>, EF_U.UnityOfWork> personUnityOfWork;

        public HRServices(IHRUnityOfWork<EF_R.Repository<Person, long>, EF_R.Repository<Account, long>, EF_U.UnityOfWork> _personUnityOfWork)
        {
            this.personUnityOfWork = _personUnityOfWork;
        }

        public bool CreateWorker(Models.ViewModels.PersonViewModel pVM)
        {
            Person p = new Person
            {
                ApartmentNumber = pVM.ApartmentNumber,
                BuildingNumber = pVM.BuildingNumber,
                City = pVM.City,
                ContactPerson = null,
                CreateDate = DateTime.Now,
                DataState=1,
                DateOfBirth = pVM.DateOfBirth,
                Email = pVM.Email,
                FirstName = pVM.FirstName,
                IDCard= pVM.IDCard,
                NIP = pVM.NIP,
                PESEL= pVM.PESEL,
                Phone = pVM.Phone,
                PostalCode = pVM.PostalCode,
                Street= pVM.Street,
                Surname= pVM.Surname
            };

            personUnityOfWork.PersonRepo.Add(p);

            Account a = new Account 
            {
                AccountType = pVM.AccountType,
                CreateDate = DateTime.Now,
                DataState = 1,
                EditDate = null,
                Password = "zaq",//narazie,
                Person=p,
                PersonId = p.Id,
                Photo = FileToByte.ConvertFileToByte(pVM.Photo),
                UserName= pVM.FirstName + "_" + pVM.Surname
            };

            AccountLog al = new AccountLog 
            { 
                AccountId = a.Id,
                Action= "Dodano uzytkownika "+ a.UserName,
                ActionDescription ="Dodanie uzytkownika do bazy danych",
                ActionType = Core.Enums.ActionType.StworzenieKonta,
                EndDate= DateTime.Now,
                StartDate = DateTime.Now
            };

            personUnityOfWork.AccountRepo.Add(a);

            personUnityOfWork.UnityOfWork.SaveChanges();

            return true;
        }
    }
}