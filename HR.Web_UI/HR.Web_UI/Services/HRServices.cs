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
using HR.Core.Models.DictionaryModels;
using System.Web.Mvc;
using HR.Web_UI.Models.ViewModels;

namespace HR.Web_UI.Services
{
    public class HRServices :IHRServices
    {
        IHRUnityOfWork<EF_R.Repository<Person, long>, EF_R.Repository<Account, long>, EF_U.UnityOfWork> personUnityOfWork;
        ILogUnityOfWork<EF_R.Repository<AccountLog, long>, EF_U.UnityOfWork> logUnityOfWork;
        IDicUnityOfWork<EF_R.Repository<BankDictionary, long>, EF_R.Repository<CollegesDictionary, long>,
            EF_R.Repository<CompaniesDictionary, long>, EF_R.Repository<Position, long>, EF_U.UnityOfWork> dicUnityOfWork;
        IEmploymentUnityOfWork<EF_R.Repository<OrganiziationalUnit, long>, EF_R.Repository<BankAccount, long>, EF_R.Repository<Employment, long>, EF_R.Repository<Contract, long>, EF_R.Repository<ContactPerson, long>, EF_U.UnityOfWork> employmentUnityOfWork;

        public HRServices(IHRUnityOfWork<EF_R.Repository<Person, long>, EF_R.Repository<Account, long>, EF_U.UnityOfWork> _personUnityOfWork,
                          ILogUnityOfWork<EF_R.Repository<AccountLog, long>, EF_U.UnityOfWork> _logUnityOfWork,
                          IDicUnityOfWork<EF_R.Repository<BankDictionary, long>, EF_R.Repository<CollegesDictionary, long>,
                          EF_R.Repository<CompaniesDictionary, long>, EF_R.Repository<Position, long>, EF_U.UnityOfWork> _dicUnityOfWork,
                          IEmploymentUnityOfWork<EF_R.Repository<OrganiziationalUnit, long>, EF_R.Repository<BankAccount, long>,
                          EF_R.Repository<Employment, long>, EF_R.Repository<Contract, long>, EF_R.Repository<ContactPerson, long>, EF_U.UnityOfWork> _employmentUnityOfWork)
        {
            this.personUnityOfWork = _personUnityOfWork;
            this.logUnityOfWork = _logUnityOfWork;
            this.dicUnityOfWork = _dicUnityOfWork;
            this.employmentUnityOfWork = _employmentUnityOfWork;
        }

        public bool CreateWorker(PersonViewModel pVM)
        {
            try
            {
                Person p = new Person
                {
                    ApartmentNumber = pVM.ApartmentNumber,
                    BuildingNumber = pVM.BuildingNumber,
                    City = pVM.City,
                    ContactPerson = null,
                    CreateDate = DateTime.Now,
                    DataState = 1,
                    DateOfBirth = pVM.DateOfBirth,
                    Email = pVM.Email,
                    FirstName = pVM.FirstName,
                    IDCard = pVM.IDCard,
                    NIP = pVM.NIP,
                    PESEL = pVM.PESEL,
                    Phone = pVM.Phone,
                    PostalCode = pVM.PostalCode,
                    Street = pVM.Street,
                    Surname = pVM.Surname
                };

                personUnityOfWork.PersonRepo.Add(p);

                Account a = new Account
                {
                    AccountType = pVM.AccountType,
                    CreateDate = DateTime.Now,
                    DataState = 1,
                    EditDate = null,
                    Password = "zaq",//narazie,
                    Person = p,
                    PersonId = p.Id,
                    Photo = FileToByte.ConvertFileToByte(pVM.Photo),
                    UserName = pVM.FirstName + "_" + pVM.Surname
                };

                personUnityOfWork.AccountRepo.Add(a);

                personUnityOfWork.UnityOfWork.SaveChanges();

                AccountLog al = new AccountLog
                {
                    AccountId = a.Id,
                    Action = "Dodano uzytkownika " + a.UserName,
                    ActionDescription = "Dodanie uzytkownika do bazy danych",
                    ActionType = Core.Enums.ActionType.StworzenieKonta,
                    EndDate = DateTime.Now,
                    StartDate = DateTime.Now
                };

                logUnityOfWork.AccountLogRepo.Add(al);
                logUnityOfWork.UnityOfWork.SaveChanges();

                return true;
            }
            catch
            {
                //tutaj dac logowanie do log4net
                return false;
            }
            finally
            {
                personUnityOfWork.UnityOfWork.Dispose();
                logUnityOfWork.UnityOfWork.Dispose();
            }
           
        }

        public List<SelectListItem> BanksSelectListItem()
        {
            try
            {
                var x = dicUnityOfWork.BankRepo.GetAll();
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (var item in x)
                {
                    list.Add(new SelectListItem { Text = item.Name, Value=item.Id.ToString()});
                }
                return list;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<SelectListItem> CollegesSelectListItem()
        {
            try
            {
                var x = dicUnityOfWork.CollegesRepo.GetAll();
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (var item in x)
                {
                    list.Add(new SelectListItem { Text = item.Name, Value=item.Id.ToString()});
                }
                return list;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SelectListItem> CompaniesSelectListItem()
        {
            try
            {
                var x = dicUnityOfWork.CompaniesRepo.GetAll();
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (var item in x)
                {
                    list.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SelectListItem> PositionsSelectListItem()
        {
            try
            {
                var x = dicUnityOfWork.PositionsRepo.GetAll();
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (var item in x)
                {
                    list.Add(new SelectListItem { Text = item.Name, Value = item.Name });
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<SelectListItem> OrganizationalUnitSelectListItem()
        {
            try
            {
                var x = employmentUnityOfWork.OrganizationalUnitRepo.GetAll();
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (var item in x)
                {
                    list.Add(new SelectListItem { Text = item.Name, Value = item.Name });
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool CreateAdditionalInfo()
        {
            throw new NotImplementedException();
        }

        public bool CreateEmployment(EmploymentViewModel eVM)
        {
            try
            {
                BankAccount ba = new BankAccount
                {
                    AccountNumber = eVM.AccountNumber,
                    BankAddress = eVM.BankAddress,
                    BankName = eVM.BankName
                };

                employmentUnityOfWork.BankAccountRepo.Add(ba);

                Contract c = new Contract
                {
                    BenefitPerHour = eVM.BenefitPerHour,
                    ContractDimension = eVM.ContractDimension,
                    ContractType = eVM.ContractType,
                    EndDate = eVM.EndDate,
                    MonthBenefit = eVM.MonthBenefit,
                    StartDate = eVM.StartDate
                };

                employmentUnityOfWork.ContractRepo.Add(c);

                Employment e = new Employment
                {
                    BankAccount = ba,
                    Contract = c,
                    PositionCode = eVM.Position,
                    StartDate = eVM.StartDate,
                    EndDate = eVM.EndDate,
                    EmploymentType = eVM.EmploymentType,
                    OrganiziationalUnitCode = eVM.Organization,
                    Person = personUnityOfWork.PersonRepo.GetAll().Last(),// nie powinno tak byc!!!! trzeba to zmienic
                    PersonId = personUnityOfWork.PersonRepo.GetAll().Last().Id,

                };
                employmentUnityOfWork.EmploymentRepo.Add(e);
                employmentUnityOfWork.UnityOfWork.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                employmentUnityOfWork.UnityOfWork.Dispose();
            }
        }


        public bool CreateContactPerson(ContactPersonViewModel cpVM)
        {
            try
            {
                ContactPerson c = new ContactPerson
                {
                    ApartmentNumber =cpVM.ApartmentNumber,
                    BuildingNumber = cpVM.BuildingNumber,
                    City = cpVM.City,
                    Email = cpVM.Email,
                    FirstName = cpVM.FirstName,
                    Phone = cpVM.Phone,
                    PostalCode = cpVM.PostalCode,
                    Street = cpVM.Street,
                    Surname = cpVM.Surname
                };

                employmentUnityOfWork.ContactPersonRepo.Add(c);
#warning do sprawdzenia jak sie to ma z encjami itd

                Person p = personUnityOfWork.PersonRepo.GetAll().Last();
                p.ContactPerson = c;
                personUnityOfWork.PersonRepo.Update(p);

                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}