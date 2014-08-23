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
        IHRUnityOfWork<EF_R.Repository<Person, long>, EF_R.Repository<Account, long>, EF_R.Repository<AdditionalInformation, long>, EF_R.Repository<College, long>, EF_R.Repository<Job, long>, EF_U.UnityOfWork> personUnityOfWork;
        ILogUnityOfWork<EF_R.Repository<AccountLog, long>, EF_U.UnityOfWork> logUnityOfWork;
        IDicUnityOfWork<EF_R.Repository<BankDictionary, long>, EF_R.Repository<CollegesDictionary, long>,
            EF_R.Repository<CompaniesDictionary, long>, EF_R.Repository<Position, long>, EF_U.UnityOfWork> dicUnityOfWork;
        IEmploymentUnityOfWork<EF_R.Repository<OrganiziationalUnit, long>, EF_R.Repository<BankAccount, long>, EF_R.Repository<Employment, long>, EF_R.Repository<Contract, long>, EF_R.Repository<ContactPerson, long>, EF_R.Repository<Person, long>, EF_U.UnityOfWork> employmentUnityOfWork;

        public HRServices(IHRUnityOfWork<EF_R.Repository<Person, long>, EF_R.Repository<Account, long>, EF_R.Repository<AdditionalInformation, long>, EF_R.Repository<College, long>, EF_R.Repository<Job, long>, EF_U.UnityOfWork> _personUnityOfWork,
                          ILogUnityOfWork<EF_R.Repository<AccountLog, long>, EF_U.UnityOfWork> _logUnityOfWork,
                          IDicUnityOfWork<EF_R.Repository<BankDictionary, long>, EF_R.Repository<CollegesDictionary, long>,
                          EF_R.Repository<CompaniesDictionary, long>, EF_R.Repository<Position, long>, EF_U.UnityOfWork> _dicUnityOfWork,
                          IEmploymentUnityOfWork<EF_R.Repository<OrganiziationalUnit, long>, EF_R.Repository<BankAccount, long>,
                          EF_R.Repository<Employment, long>, EF_R.Repository<Contract, long>, EF_R.Repository<ContactPerson, long>, EF_R.Repository<Person, long>, EF_U.UnityOfWork> _employmentUnityOfWork)
        {
            this.personUnityOfWork = _personUnityOfWork;
            this.logUnityOfWork = _logUnityOfWork;
            this.dicUnityOfWork = _dicUnityOfWork;
            this.employmentUnityOfWork = _employmentUnityOfWork;
        }

        public Person CreateWorker(PersonViewModel pVM)
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
#warning Ale potem ManagerId trzeba zmienic jak zostanie dodane do konkretnego dzialu

                Account a = new Account
                {
                    AccountType = pVM.AccountType,
                    CreateDate = DateTime.Now,
                    DataState = 1,
                    EditDate = null,
                    Password = "zaq",//narazie,
                    Person = p,
                    Photo = FileToByte.ConvertFileToByte(pVM.Photo),
                    UserName = pVM.FirstName + "_" + pVM.Surname
                };

                AccountLog al = new AccountLog
                {
#warning Trzeba dodac konto osoby ktore dodalo tego uzytkownika
                    Account =a,
                    Action = "Dodano uzytkownika " + a.UserName,
                    ActionDescription = "Dodanie uzytkownika do bazy danych",
                    ActionType = Core.Enums.ActionType.StworzenieKonta,
                    EndDate = DateTime.Now,
                    StartDate = DateTime.Now
                };

                personUnityOfWork.PersonRepo.Add(p);
                personUnityOfWork.AccountRepo.Add(a);
                logUnityOfWork.AccountLogRepo.Add(al);

                logUnityOfWork.UnityOfWork.SaveChanges();
                logUnityOfWork.UnityOfWork.Dispose();

                return p;
            }
            catch (Exception)
            {

                throw;
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
                    list.Add(new SelectListItem { Text = item.Name, Value = item.Id });
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
                    list.Add(new SelectListItem { Text = item.Name, Value = item.Id });
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public AdditionalInformation CreateAdditionalInfo(AdditionalInformationViewModel aiVM,Person p)
        {
            try
            {
                personUnityOfWork.PersonRepo.Attach(ref p);

                AdditionalInformation ai = new AdditionalInformation
                {
                    Person = p,
                    FacebookAccount = aiVM.Facebook,
                    GoogleAccount = aiVM.Google,
                    TwitterAccount = aiVM.Twitter,
                    GoldenLineAccount = aiVM.GoldenLine,
                    LinkInAccount = aiVM.LinkIn
                };
                p.AdditionalInformation = ai;

                personUnityOfWork.AdditionalInfoRepo.Add(ai);

                personUnityOfWork.PersonRepo.Update(p);

                personUnityOfWork.UnityOfWork.SaveChanges();

                return ai;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                personUnityOfWork.UnityOfWork.Dispose();
            }
        }

        public Employment CreateEmployment(EmploymentViewModel eVM, Person p)
        {
            try
            {
                employmentUnityOfWork.PersonRepo.Attach(ref p);

                BankAccount ba = new BankAccount
                {
                    AccountNumber = eVM.AccountNumber,
                    BankAddress = eVM.BankAddress,
                    BankName = eVM.BankName
                };

                Contract c = new Contract
                {
                    BenefitPerHour = eVM.BenefitPerHour,
                    ContractDimension = eVM.ContractDimension,
                    ContractType = eVM.ContractType,
                    EndDate = eVM.EndDate,
                    MonthBenefit = eVM.MonthBenefit,
                    StartDate = eVM.StartDate,
                };

                Employment e = new Employment
                {
                    BankAccount = ba,
                    Contract = c,
                    PositionCode = eVM.Position,
                    StartDate = eVM.StartDate,
                    EndDate = eVM.EndDate,
                    EmploymentType = eVM.EmploymentType,
                    OrganiziationalUnitCode = eVM.Organization,
                    Person = p,

                };
                p.Employment = e;

                employmentUnityOfWork.BankAccountRepo.Add(ba);
                employmentUnityOfWork.ContractRepo.Add(c);
                employmentUnityOfWork.EmploymentRepo.Add(e);

                personUnityOfWork.PersonRepo.Update(p);

                employmentUnityOfWork.UnityOfWork.SaveChanges();

                return e;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                personUnityOfWork.UnityOfWork.Dispose();
            }
        }


        public ContactPerson CreateContactPerson(ContactPersonViewModel cpVM, Person p)
        {
            try
            {
                employmentUnityOfWork.PersonRepo.Attach(ref p);

                ContactPerson c = new ContactPerson
                {
                    ApartmentNumber = cpVM.ApartmentNumber,
                    BuildingNumber = cpVM.BuildingNumber,
                    City = cpVM.City,
                    Email = cpVM.Email,
                    FirstName = cpVM.FirstName,
                    Phone = cpVM.Phone,
                    PostalCode = cpVM.PostalCode,
                    Street = cpVM.Street,
                    Surname = cpVM.Surname,
                    Person = p
                };

                employmentUnityOfWork.ContactPersonRepo.Add(c);
                employmentUnityOfWork.PersonRepo.Update(p);
                employmentUnityOfWork.UnityOfWork.SaveChanges();


                return c;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                personUnityOfWork.UnityOfWork.Dispose();
            }
        }


        public PersonDisplayViewModel GetAllPersonData(long id)
        {
            try
            {
                Person  p = personUnityOfWork.PersonRepo.GetById(id);

#warning Tutaj moga nulle wystepowac do zabezpieczenia pozniejszego
                PersonDisplayViewModel pdVm = new PersonDisplayViewModel
                {
                    AccountNumber = p.Employment.BankAccount.ToString(),
                    ApartmentNumber = p.ApartmentNumber,
                    accountType = p.Account.AccountType,
                    BankAddress = p.Employment.BankAccount.BankAddress,
                    BankName = p.Employment.BankAccount.BankName,
                    BenefitPerHour = p.Employment.Contract.BenefitPerHour,
                    BuildingNumber = p.BuildingNumber,
                    City = p.City,
                    ContactPersonApartmentNumber = p.ContactPerson.ApartmentNumber,
                    ContactPersonBuildingNumber = p.ContactPerson.BuildingNumber,
                    ContactPersonCity = p.ContactPerson.City,
                    ContactPersonEmail = p.ContactPerson.Email,
                    ContactPersonFirstName = p.ContactPerson.FirstName,
                    ContactPersonPhone = p.ContactPerson.Phone,
                    ContactPersonPostalCode = p.ContactPerson.PostalCode,
                    ContactPersonStreet = p.ContactPerson.Street,
                    ContactPersonSurname = p.ContactPerson.Surname,
                    ContractDimension = p.Employment.Contract.ContractDimension,
                    ContractType = p.Employment.Contract.ContractType,
                    DateOfBirth = p.DateOfBirth,
                    Email = p.Email,
                    EmploymentType = p.Employment.EmploymentType,
                    EndDate = p.Employment.EndDate,
                    Facebook = p.AdditionalInformation.FacebookAccount,
                    FirstName = p.FirstName,
                    GoldenLine = p.AdditionalInformation.GoldenLineAccount,
                    Google = p.AdditionalInformation.GoogleAccount,
                    IDCard = p.IDCard,
                    LinkIn = p.AdditionalInformation.LinkInAccount,
                    MonthBenefit = p.Employment.Contract.MonthBenefit,
                    NIP = p.NIP,
                    Organization = p.Employment.OrganiziationalUnitCode,
                    PESEL = p.PESEL,
                    Phone = p.Phone,
                    Photo = p.Account.Photo,
                    Position = p.Employment.PositionCode,
                    PostalCode = p.PostalCode,
                    StartDate = p.Employment.StartDate,
                    Street = p.Street,
                    Surname = p.Street,
                    Twitter = p.AdditionalInformation.TwitterAccount
                };
                return pdVm;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                personUnityOfWork.UnityOfWork.Dispose();
            }
        }


        public bool AddNewPersonCollage(CollegesViewModel cVm,Person p)
        {
            try
            {
                College c = new College
                {
                    AcademicTitle = cVm.AcademicTitle,
                    EndDate = cVm.EndDate,
                    FieldOfStudy = cVm.FieldOfStudy,
                    Name = cVm.Name,
                    Person = p,
                    Progres = cVm.Progres,
                    Specialization = cVm.Specialization,
                    StartDate = cVm.StartDate,
                    TitleOfResearch = cVm.TitleOfResearch
                };

                personUnityOfWork.CollageRepo.Add(c);
                personUnityOfWork.UnityOfWork.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                personUnityOfWork.UnityOfWork.Dispose();
            }
        }

        public bool AddNewPersonJob(EmploymentsViewModel eVM, Person p)
        {
            try
            {
                Job j = new Job 
                {
                    CompanyName = eVM.CompanyName,
                    Description= eVM.Description,
                    EndDate= eVM.EndDate,
                    Person=p,
                    Position= eVM.Position,
                    StartDate=eVM.StartDate
                };

                personUnityOfWork.JobRepo.Add(j);
                personUnityOfWork.UnityOfWork.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                personUnityOfWork.UnityOfWork.Dispose();
            }
        }

        public IEnumerable<CollegesViewModel> GetAllColleges(long id)
        {
            try
            {
                var x = (from p in personUnityOfWork.CollageRepo.GetAll()
                        where p.Person.Id == id
                        select new CollegesViewModel
                        {
                            AcademicTitle = p.AcademicTitle,
                            EndDate = p.EndDate,
                            FieldOfStudy = p.FieldOfStudy,
                            Id = p.Id,
                            Name= p.Name,
                            Progres= p.Progres,
                            Specialization=p.Specialization,
                            StartDate= p.StartDate,
                            TitleOfResearch= p.TitleOfResearch
                        }).ToList();

                return x;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                personUnityOfWork.UnityOfWork.Dispose();
            }
        }

        public IEnumerable<EmploymentsViewModel> GetAllJobs(long id)
        {
            try
            {
                var x = (from e in personUnityOfWork.JobRepo.GetAll()
                        where e.Person.Id == id
                        select new EmploymentsViewModel 
                        {
                            CompanyName = e.CompanyName,
                            Description= e.Description,
                            EndDate= e.EndDate,
                            Id=e.Id,
                            Position=e.Position,
                            StartDate=e.StartDate
                        }).ToList();

                return x;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                personUnityOfWork.UnityOfWork.Dispose();
            }
        }
    }
}