using System;
using System.Collections.Generic;
using System.Data.Entity;
using HR.Core.Models;
using HR.DataAccess.EF.Mapping;
using HR.Core.Enums;
using HR.Core.Models.RepoModels;
using HR.Core.Models.DictionaryModels;

namespace HR.DataAccess.EF
{
    public class HR_DataContext : DbContext
    {
        public HR_DataContext(): base("HR_Database")
        {
            //zeby nie tworzyc kontekstu
            Database.SetInitializer<HR_DataContext>(new HRDBInitializer());
            
        }
        #region Models

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountLog> AccountLogs { get; set; }
        public DbSet<AdditionalInformation> AdditionalInformations { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BenefitsProfit> BenefitsProfits { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Delegation> Delegations { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<OrganiziationalUnit> OrganiziationalUnits { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<WorkRegistry> WorkRegistrys { get; set; }

        #endregion

        #region Repos

        public DbSet<CourseMaterial> CourseMaterials { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<PromotialMaterial> PromotialMaterials { get; set; }
        public DbSet<VacationDocument> VacationDocuments { get; set; }

        #endregion

        #region Dictionaries

        public DbSet<BankDictionary> BankDictionaries { get; set; }
        public DbSet<CollegesDictionary> CollegesDictionaries { get; set; }
        public DbSet<CompaniesDictionary> CompaniesDictionaries { get; set; }
        public DbSet<Position> Positions { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountLogMapper());
            modelBuilder.Configurations.Add(new AccountMapper());
            modelBuilder.Configurations.Add(new AdditionalInformationMapper());
            modelBuilder.Configurations.Add(new BankAccountMapper());
            modelBuilder.Configurations.Add(new BankDictionaryMapper());
            modelBuilder.Configurations.Add(new BenefitsProfitMapper());
            modelBuilder.Configurations.Add(new CollageMapper());
            modelBuilder.Configurations.Add(new CollegesDictionaryMapper());
            modelBuilder.Configurations.Add(new ContactPersonMapper());
            modelBuilder.Configurations.Add(new ContractMapper());
            modelBuilder.Configurations.Add(new CourseMaterialMapper());
            modelBuilder.Configurations.Add(new DelegationMapper());
            modelBuilder.Configurations.Add(new DocumentMapper());
            modelBuilder.Configurations.Add(new EmploymentMapper());
            modelBuilder.Configurations.Add(new JobMapper());
            modelBuilder.Configurations.Add(new OrganiziationalUnitMapper());
            modelBuilder.Configurations.Add(new PersonMapper());
            modelBuilder.Configurations.Add(new PositionMapper());
            modelBuilder.Configurations.Add(new PromotialMaterialMapper());
            modelBuilder.Configurations.Add(new TraningMapper());
            modelBuilder.Configurations.Add(new VacationDocumentMapper());
            modelBuilder.Configurations.Add(new VacationMapper());
            modelBuilder.Configurations.Add(new WorkRegistryMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
    public class HRDBInitializer : CreateDatabaseIfNotExists<HR_DataContext>
    {
        //olac to narazie
        protected override void Seed(HR_DataContext context)
        {
            
            /*Person p = new Person { ApartmentNumber = 1, BuildingNumber = 12, City = "Krakow"
                ,ContactPerson = new ContactPerson{ ApartmentNumber = 1, BuildingNumber = 3, City = "Krakow", CreateDate = DateTime.Now, DataState =1, EditDate = null, Email = "sabina@wp.pl", FirstName ="Sabina", Surname="Jackiewicz", Id = 1, Phone = 159852357, PostalCode = "15-753", Street="Malinowa"}
                ,ContactPersonId = 0, CreateDate = DateTime.Now, DataState =1, DateOfBirth = new DateTime(1987,2,3), Documents= null, EditDate = null, Email ="jacekp@wp.pl" ,FirstName="Jacek", Surname = "Placek", Street="Brzydka", NIP=159951, Id = 1, IDCard="AW123432", PESEL= "15858586257", Manager = null, ManagerId = null, Phone=159852357, PostalCode="12-432" };
            
            List<Account> list = new List<Account>();
            list.Add(new Account() { CreateDate= DateTime.Now, EditDate= null, AccountType= Core.Enums.AccountType.Pracownik, UserName="Jacek_Placek", Photo = null, Password="zaq", Id=1, DataState=1, PersonId = 1, Person = p});/*
            list.Add(new Account() { CreateDate = DateTime.Now, EditDate = null, AccountType = Core.Enums.AccountType.Kierownik, UserName = "Tomek_Domek", Photo = null, Password = "zaq", Id = 2, DataState = 1,  });
            list.Add(new Account() { CreateDate = DateTime.Now, EditDate = null, AccountType = Core.Enums.AccountType.HR, UserName = "Halina_Malina", Photo = null, Password = "zaq", Id = 3, DataState = 1 });
            list.Add(new Account() { CreateDate = DateTime.Now, EditDate = null, AccountType = Core.Enums.AccountType.Pracownik, UserName = "Karolina_Nowak", Photo = null, Password = "zaq", Id = 4, DataState = 1 });
            list.Add(new Account() { CreateDate = DateTime.Now, EditDate = null, AccountType = Core.Enums.AccountType.Pracownik, UserName = "Grzesiek_Tomczyk", Photo = null, Password = "zaq", Id = 5, DataState = 1 });*/

           /* foreach (var item in list)
            {
                context.Accounts.Add(item);
            }
            context.SaveChanges();*/

            /*List<Person> personsList = new List<Person>();
            personsList.Add(new Person() { ApartmentNumber=12, BuildingNumber=2, City="Częstochowa", DataState=1, DateOfBirth=new DateTime(1999,2,18),FirstName="Tomasz", Surname="Jasiński",Street="Kokosowa",Profession=ProfesionType.Programista_ASP_NET_MVC,PostalCode="204-12",NIP=1478523697 , IDCard="AED159753", PESEL="15875235874" });
            personsList.Add(new Person() { ApartmentNumber = 12, BuildingNumber = 2, City = "Częstochowa", DataState = 1, DateOfBirth = new DateTime(1999, 2, 18), FirstName = "Tomasz", Surname = "Jasiński", Street = "Kokosowa", Profession = ProfesionType.Human_Resource, PostalCode = "204-12", NIP = 1478523697, IDCard = "DEF153453", PESEL="35874528568" });
            personsList.Add(new Person() { ApartmentNumber = 12, BuildingNumber = 2, City = "Częstochowa", DataState = 1, DateOfBirth = new DateTime(1999, 2, 18), FirstName = "Tomasz", Surname = "Jasiński", Street = "Kokosowa", Profession = ProfesionType.CEO, PostalCode = "204-12", NIP = 1478523697, IDCard = "BVD158853" , PESEL="584586853589"});
            personsList.Add(new Person() { ApartmentNumber = 12, BuildingNumber = 2, City = "Częstochowa", DataState = 1, DateOfBirth = new DateTime(1999, 2, 18), FirstName = "Tomasz", Surname = "Jasiński", Street = "Kokosowa", Profession = ProfesionType.Programista_Cpp, PostalCode = "204-12", NIP = 1478523697, IDCard = "WDC157523", PESEL="58458483214" });

            foreach (var item in personsList)
            {
                context.Persons.Add(item);
            }*/

            base.Seed(context);
        }
    }
}
