using System;
using System.Collections.Generic;
using System.Data.Entity;
using HR.Core.Models;
using HR.DataAccess.EF.Mapping;
using HR.Core.Enums;

namespace HR.DataAccess.EF
{
    public class HR_DataContext : DbContext
    {
        public HR_DataContext(): base("HR_Database")
        {
            Database.SetInitializer<HR_DataContext>(new SchoolDBInitializer());
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountMapper());
            modelBuilder.Configurations.Add(new BankAccountMapper());
            modelBuilder.Configurations.Add(new BenefitsProfitMapper());
            modelBuilder.Configurations.Add(new CollageMapper());
            modelBuilder.Configurations.Add(new ContractMapper());
            modelBuilder.Configurations.Add(new CourseDocument_REPO_Mapper());
            modelBuilder.Configurations.Add(new CourseMaterialMapper());
            modelBuilder.Configurations.Add(new PersonMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
    public class SchoolDBInitializer : DropCreateDatabaseIfModelChanges<HR_DataContext>
    {
        protected override void Seed(HR_DataContext context)
        {
            List<Account> list = new List<Account>();
            list.Add(new Account() { AccountType= Core.Enums.AccountType.HR, UserName="Jacek", Photo = null, Password="sdadsa", Id=1, DataState=1});
            list.Add(new Account() { AccountType = Core.Enums.AccountType.Kierownik, UserName = "Jacek", Photo = null, Password = "sdadsa", Id = 2, DataState = 1 });
            list.Add(new Account() { AccountType = Core.Enums.AccountType.Pracownik, UserName = "Jacek", Photo = null, Password = "sdadsa", Id = 3, DataState = 1 });

            foreach (var item in list)
            {
                context.Account.Add(item);
            }

            List<Person> personsList = new List<Person>();
            personsList.Add(new Person() { ApartmentNumber=12, BuildingNumber=2, City="Częstochowa", DataState=1, DateOfBirth=new DateTime(1999,2,18),FirstName="Tomasz", Surname="Jasiński",Street="Kokosowa",Profession=ProfesionType.Programista_ASP_NET_MVC,PostalCode="204-12",NIP=1478523697 , IDCard="AED159753", PESEL="15875235874" });
            personsList.Add(new Person() { ApartmentNumber = 12, BuildingNumber = 2, City = "Częstochowa", DataState = 1, DateOfBirth = new DateTime(1999, 2, 18), FirstName = "Tomasz", Surname = "Jasiński", Street = "Kokosowa", Profession = ProfesionType.Human_Resource, PostalCode = "204-12", NIP = 1478523697, IDCard = "DEF153453", PESEL="35874528568" });
            personsList.Add(new Person() { ApartmentNumber = 12, BuildingNumber = 2, City = "Częstochowa", DataState = 1, DateOfBirth = new DateTime(1999, 2, 18), FirstName = "Tomasz", Surname = "Jasiński", Street = "Kokosowa", Profession = ProfesionType.CEO, PostalCode = "204-12", NIP = 1478523697, IDCard = "BVD158853" , PESEL="584586853589"});
            personsList.Add(new Person() { ApartmentNumber = 12, BuildingNumber = 2, City = "Częstochowa", DataState = 1, DateOfBirth = new DateTime(1999, 2, 18), FirstName = "Tomasz", Surname = "Jasiński", Street = "Kokosowa", Profession = ProfesionType.Programista_Cpp, PostalCode = "204-12", NIP = 1478523697, IDCard = "WDC157523", PESEL="58458483214" });

            foreach (var item in personsList)
            {
                context.Persons.Add(item);
            }

            base.Seed(context);
        }
    }
}
