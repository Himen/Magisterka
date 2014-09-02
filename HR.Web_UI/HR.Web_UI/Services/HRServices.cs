#define EF

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
using HR.Web_UI.Models.ViewModels.HR;
using HR.Core.Enums;
using HR.Core.Models.RepoModels;
using HR.Web_UI.Models.ViewModels.Calendar;


namespace HR.Web_UI.Services
{
    public class HRServices :IHRServices
    {

#if NH
        IHRUnityOfWork<NH_R.Repository<Person, long>, NH_R.Repository<Account, long>, NH_R.Repository<AdditionalInformation, long>, 
            NH_R.Repository<College, long>, NH_R.Repository<Job, long>, NH_R.Repository<Training, long>, NH_U.UnityOfWork> personUnityOfWork;

        ILogUnityOfWork<NH_R.Repository<AccountLog, long>, NH_R.Repository<Account, long>, NH_U.UnityOfWork> logUnityOfWork;

        IDicUnityOfWork<NH_R.Repository<BankDictionary, long>, NH_R.Repository<CollegesDictionary, long>,
            NH_R.Repository<CompaniesDictionary, long>, NH_R.Repository<Position, long>, NH_U.UnityOfWork> dicUnityOfWork;

        IEmploymentUnityOfWork<NH_R.Repository<OrganiziationalUnit, long>, NH_R.Repository<BankAccount, long>, 
            NH_R.Repository<Employment, long>, NH_R.Repository<Contract, long>, NH_R.Repository<ContactPerson, long>,
            NH_R.Repository<Person, long>, NH_U.UnityOfWork> employmentUnityOfWork;

        IWorkRegistryUnityOfWork<NH_R.Repository<Person, long>, NH_R.Repository<BenefitsProfit, long>, NH_R.Repository<WorkRegistry, long>,
            NH_R.Repository<Vacation, long>, NH_R.Repository<Delegation, long>, NH_R.Repository<VacationDocument, Guid>,
            NH_U.UnityOfWork> workRegistryUnityOfWork;

        public HRServices(IHRUnityOfWork<NH_R.Repository<Person, long>, NH_R.Repository<Account, long>, NH_R.Repository<AdditionalInformation, long>, NH_R.Repository<College, long>, NH_R.Repository<Job, long>, NH_R.Repository<Training, long>, NH_U.UnityOfWork> _personUnityOfWork,
                          ILogUnityOfWork<NH_R.Repository<AccountLog, long>, NH_R.Repository<Account, long>, NH_U.UnityOfWork> _logUnityOfWork,
                          IDicUnityOfWork<NH_R.Repository<BankDictionary, long>, NH_R.Repository<CollegesDictionary, long>,
                          NH_R.Repository<CompaniesDictionary, long>, NH_R.Repository<Position, long>, NH_U.UnityOfWork> _dicUnityOfWork,
                          IEmploymentUnityOfWork<NH_R.Repository<OrganiziationalUnit, long>, NH_R.Repository<BankAccount, long>,
                          NH_R.Repository<Employment, long>, NH_R.Repository<Contract, long>, NH_R.Repository<ContactPerson, long>, NH_R.Repository<Person, long>, NH_U.UnityOfWork> _employmentUnityOfWork,
                          IWorkRegistryUnityOfWork<NH_R.Repository<Person, long>, NH_R.Repository<BenefitsProfit, long>, NH_R.Repository<WorkRegistry, long>,
                          NH_R.Repository<Vacation, long>, NH_R.Repository<Delegation, long>, NH_R.Repository<VacationDocument, Guid>,
                          NH_U.UnityOfWork> _workRegistryUnityOfWork)
        {
            this.personUnityOfWork = _personUnityOfWork;
            this.logUnityOfWork = _logUnityOfWork;
            this.dicUnityOfWork = _dicUnityOfWork;
            this.employmentUnityOfWork = _employmentUnityOfWork;
            this.workRegistryUnityOfWork = _workRegistryUnityOfWork;
        }

#elif EF
        IHRUnityOfWork<EF_R.Repository<Person, long>, EF_R.Repository<Account, long>, EF_R.Repository<AdditionalInformation, long>, 
            EF_R.Repository<College, long>, EF_R.Repository<Job, long>, EF_R.Repository<Training, long>,EF_R.Repository<PromotialMaterial, long>,
            EF_R.Repository<Document, long>,EF_U.UnityOfWork> personUnityOfWork;

        ILogUnityOfWork<EF_R.Repository<AccountLog, long>, EF_R.Repository<Account, long>, EF_U.UnityOfWork> logUnityOfWork;

        IDicUnityOfWork<EF_R.Repository<BankDictionary, long>, EF_R.Repository<CollegesDictionary, long>,
            EF_R.Repository<CompaniesDictionary, long>, EF_R.Repository<Position, long>, EF_U.UnityOfWork> dicUnityOfWork;

        IEmploymentUnityOfWork<EF_R.Repository<OrganiziationalUnit, long>, EF_R.Repository<BankAccount, long>, 
            EF_R.Repository<Employment, long>, EF_R.Repository<Contract, long>, EF_R.Repository<ContactPerson, long>,
            EF_R.Repository<Person, long>, EF_U.UnityOfWork> employmentUnityOfWork;

        IWorkRegistryUnityOfWork<EF_R.Repository<Person, long>, EF_R.Repository<BenefitsProfit, long>, EF_R.Repository<WorkRegistry, long>,
            EF_R.Repository<Vacation, long>, EF_R.Repository<Delegation, long>, EF_R.Repository<VacationDocument, Guid>,
            EF_U.UnityOfWork> workRegistryUnityOfWork;

        public HRServices(IHRUnityOfWork<EF_R.Repository<Person, long>, EF_R.Repository<Account, long>, EF_R.Repository<AdditionalInformation, long>,
                          EF_R.Repository<College, long>, EF_R.Repository<Job, long>, EF_R.Repository<Training, long>, EF_R.Repository<PromotialMaterial, long>,
                          EF_R.Repository<Document, long>, EF_U.UnityOfWork> _personUnityOfWork,
                          ILogUnityOfWork<EF_R.Repository<AccountLog, long>, EF_R.Repository<Account, long>, EF_U.UnityOfWork> _logUnityOfWork,
                          IDicUnityOfWork<EF_R.Repository<BankDictionary, long>, EF_R.Repository<CollegesDictionary, long>,
                          EF_R.Repository<CompaniesDictionary, long>, EF_R.Repository<Position, long>, EF_U.UnityOfWork> _dicUnityOfWork,
                          IEmploymentUnityOfWork<EF_R.Repository<OrganiziationalUnit, long>, EF_R.Repository<BankAccount, long>,
                          EF_R.Repository<Employment, long>, EF_R.Repository<Contract, long>, EF_R.Repository<ContactPerson, long>, EF_R.Repository<Person, long>, EF_U.UnityOfWork> _employmentUnityOfWork,
                          IWorkRegistryUnityOfWork<EF_R.Repository<Person, long>, EF_R.Repository<BenefitsProfit, long>, EF_R.Repository<WorkRegistry, long>,
                          EF_R.Repository<Vacation, long>, EF_R.Repository<Delegation, long>, EF_R.Repository<VacationDocument, Guid>,
                          EF_U.UnityOfWork> _workRegistryUnityOfWork)
        {
            this.personUnityOfWork = _personUnityOfWork;
            this.logUnityOfWork = _logUnityOfWork;
            this.dicUnityOfWork = _dicUnityOfWork;
            this.employmentUnityOfWork = _employmentUnityOfWork;
            this.workRegistryUnityOfWork = _workRegistryUnityOfWork;
        }
#else

#endif

        public bool CheckEmailExist(PersonViewModel pVM)
        {
            try
            { 
                if (personUnityOfWork.PersonRepo.Find(p => p.Email.ToLower().Equals(pVM.Email)).FirstOrDefault() == null)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
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
                    UserName = pVM.Email
                };

                AccountLog al = new AccountLog
                {
#warning Trzeba dodac konto osoby ktore dodalo tego uzytkownika
                    Account = a,
                    Action = "Dodano uzytkownika " + a.UserName,
                    ActionDescription = "Dodanie uzytkownika do bazy danych",
                    ActionType = Core.Enums.ActionType.StworzenieKonta,
                    EndDate = DateTime.Now,
                    StartDate = DateTime.Now
                };

                personUnityOfWork.PersonRepo.Add(p);
                personUnityOfWork.AccountRepo.Add(a);
                logUnityOfWork.AccountLogRepo.Add(al);

                personUnityOfWork.UnityOfWork.SaveChanges();

                return p;
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

        public bool DeleteWorker(long id)
        {
            try
            {
                personUnityOfWork.PersonRepo.RemoveById(id);
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

                long managerId = long.Parse(eVM.Manager);
                Person manager = employmentUnityOfWork.PersonRepo.GetById(managerId);
                employmentUnityOfWork.PersonRepo.Attach(ref manager);
                p.ManagerId = managerId;
                p.Manager = manager;

                employmentUnityOfWork.PersonRepo.Update(p);
                employmentUnityOfWork.PersonRepo.Update(manager);
                employmentUnityOfWork.UnityOfWork.SaveChanges();

                return e;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                employmentUnityOfWork.UnityOfWork.Dispose();
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

                p.ContactPerson = c;
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
                employmentUnityOfWork.UnityOfWork.Dispose();
            }
        }


        public PersonDisplayViewModel GetAllPersonData(long id)
        {
            try
            {
                Person p = personUnityOfWork.PersonRepo.Find(d=>d.Id == id && d.DataState == 1).FirstOrDefault();

#warning Tutaj moga nulle wystepowac do zabezpieczenia pozniejszego
                PersonDisplayViewModel pdVm = new PersonDisplayViewModel
                {
                    Id=p.Id,
                    AccountNumber = p.Employment.BankAccount.AccountNumber,
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
                    Manager = p.Manager.FirstName + " "+p.Manager.Surname,
                    MonthBenefit = p.Employment.Contract.MonthBenefit,
                    NIP = p.NIP,
                    Organization = GetOrganizationName(p.Employment.OrganiziationalUnitCode),
                    PESEL = p.PESEL,
                    Phone = p.Phone,
                    Photo = p.Account.Photo,
                    Position = GetPositionName( p.Employment.PositionCode), 
                    PostalCode = p.PostalCode,
                    StartDate = p.Employment.StartDate,
                    Street = p.Street,
                    Surname = p.Surname,
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
                //personUnityOfWork.UnityOfWork.Dispose();
            }
        }

        public string GetPositionName(string key)
        {
            try
            {
                return dicUnityOfWork.PositionsRepo.Find(d => d.Id == key).FirstOrDefault().Name;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public string GetOrganizationName(string key)
        {
            try
            {
                return employmentUnityOfWork.OrganizationalUnitRepo.Find(d => d.Id == key).FirstOrDefault().Name;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool AddNewPersonCollage(CollegesViewModel cVm, long Id)
        {
            try
            {
                Person p = personUnityOfWork.PersonRepo.GetById(Id);
                personUnityOfWork.PersonRepo.Attach(ref p);

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

                p.Colleges =p.Colleges ?? new List<College>();
                p.Colleges.Add(c);
                personUnityOfWork.CollageRepo.Add(c);
                personUnityOfWork.PersonRepo.Update(p);
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

        public bool AddNewPersonJob(EmploymentsViewModel eVM, long Id)
        {
            try
            {
                Person p = personUnityOfWork.PersonRepo.GetById(Id);
                personUnityOfWork.PersonRepo.Attach(ref p);

                Job j = new Job 
                {
                    CompanyName = eVM.CompanyName,
                    Description= eVM.Description,
                    EndDate= eVM.EndDate,
                    Person=p,
                    Position= eVM.Position,
                    StartDate=eVM.StartDate
                };

                p.Jobs = p.Jobs ?? new List<Job>();
                p.Jobs.Add(j);

                personUnityOfWork.JobRepo.Add(j);
                personUnityOfWork.PersonRepo.Update(p);
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

        public bool AddNewPersonTrainings(TraningsViewModel tVM, long Id)
        {
            try
            {
                Person p = personUnityOfWork.PersonRepo.GetById(Id);
                personUnityOfWork.PersonRepo.Attach(ref p);

                Training t = new Training
                {
                    DateOfPass = tVM.DateOfPass,
                    Description = tVM.Description,
                    Name = tVM.Name,
                    Person = p,
                    Type = tVM.Type
                };

                p.Trainings = p.Trainings ?? new List<Training>();
                p.Trainings.Add(t);
                personUnityOfWork.TraningRepo.Add(t);
                personUnityOfWork.PersonRepo.Update(p);
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
                //personUnityOfWork.UnityOfWork.Dispose();
            }
        }

        public IEnumerable<TraningsViewModel> GetAllTrainings(long id)
        {
            try
            {
                var x = (from p in personUnityOfWork.TraningRepo.GetAll()
                        where p.PersonId == id
                        select new TraningsViewModel 
                        {
                            Id=p.Id,
                            DateOfPass = p.DateOfPass,
                            Description = p.Description,
                            Name = p.Name,
                            Type = p.Type

                        }).ToList();

                return x;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

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
                //personUnityOfWork.UnityOfWork.Dispose();
            }
        }


        public IEnumerable<Person> GetAllWorkers()
        {
            try
            {
                var x = personUnityOfWork.PersonRepo.GetAll().Where(c=>c.Employment.EmploymentType!= EmploymentType.Kandydat 
                                                                    && c.Employment.EmploymentType!=EmploymentType.DoZatwierdzenia
                                                                    && c.Employment.EmploymentType != EmploymentType.PracowalUnas
                                                                    && c.Employment.EmploymentType != EmploymentType.Zwolniony);


                return x;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //personUnityOfWork.UnityOfWork.Dispose();
            }
        }

        public IEnumerable<BenefitsProfit> GetAllWorkerBenefits(long Id)
        {
            try
            {
                var x = workRegistryUnityOfWork.BenefitProfitsRepo.GetAll().Where(p => p.PersonId == Id);

                return x;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
 
            }
        }

        public Person GetWorker(long id)
        {
            try
            {
                return personUnityOfWork.PersonRepo.GetById(id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public List<SelectListItem> GetAllManagersSelectList()
        {
            try
            {
                var x = personUnityOfWork.PersonRepo.GetAll().Where(p=>p.Account.AccountType == Core.Enums.AccountType.Kierownik);
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (var item in x)
                {
                    list.Add(new SelectListItem { Text = item.FirstName + " " + item.Surname , Value = item.Id.ToString() });
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //personUnityOfWork.UnityOfWork.Dispose();
            }
        }
        public IEnumerable<Person> GetAllCandidats()
        {
            try
            {
                var x = personUnityOfWork.PersonRepo.GetAll().Where(c=>c.Employment.EmploymentType == Core.Enums.EmploymentType.Kandydat);

                foreach (var item in x)
                {
                    item.Employment.OrganiziationalUnitCode = GetOrganizationName(item.Employment.OrganiziationalUnitCode);
                    item.Employment.OrganiziationalUnitCode = GetPositionName(item.Employment.PositionCode);
                }

                return x;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //personUnityOfWork.UnityOfWork.Dispose();
            }
        }
        public bool EmployCandidate(long id,EmploymentType emp)
        {
            try
            {
                var x = personUnityOfWork.PersonRepo.GetById(id);
                personUnityOfWork.PersonRepo.Attach(ref x);
                x.Employment.EmploymentType = emp;

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

        public IQueryable<PromotialMaterial> GetAllMaterials()
        {
            try
            {
                var x = personUnityOfWork.PromotialMaterialsRepo.GetAll();
                return x;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public bool AddPromotialMaterial(PromotialMaterial prom)
        {
            try
            {
                personUnityOfWork.PromotialMaterialsRepo.Add(prom);
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
        public List<Document> GetWorkerDocuments(long id)
        {
            try
            {
                var x = personUnityOfWork.DocumentsRepo.GetAll().Where(c=>c.Person.Id == id);
                return x.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public bool SaveDocument(Document doc)
        {
            try
            {
                personUnityOfWork.DocumentsRepo.Add(doc);
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

        public List<CalendarEvent> GetWorkerEvents(long id)
        {
            try
            {

                var x = (from z in workRegistryUnityOfWork.WorkRegistryRepo.GetAll().Where(p => p.Person.Id == id)
                         select new CalendarEvent
                         {
                             end_date = z.Date.Add(z.DateIn.Value),
                             start_date = z.Date.Add(z.DateOut.Value),
                             text = "Standardowe przyjscie do pracy",
                             id = (int)z.Id
                         }).ToList();



                return x;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}