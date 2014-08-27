using System;
using System.Collections.Generic;
using System.Data.Entity;
using HR.Core.Models;
using HR.DataAccess.EF.Mapping;
using HR.Core.Enums;
using HR.Core.Models.RepoModels;
using HR.Core.Models.DictionaryModels;
using HR.Data.Generator;

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
    public class HRDBInitializer : DropCreateDatabaseAlways<HR_DataContext>
    {
        //olac to narazie
        protected override void Seed(HR_DataContext context)
        {
            base.Seed(context);
            Generator g = new Generator();

            #region Słowniki

            List<CompaniesDictionary> listOfDictionaries = g.Companies;
            foreach (var item in listOfDictionaries)
	        {
		        context.CompaniesDictionaries.Add(item);
	        }

            List<Position> listOfPositions = g.Positions;
            foreach (var item in listOfPositions)
	        {
		        context.Positions.Add(item);
	        }

            List<CollegesDictionary> listOfColleges = g.Colleges;
            foreach (var item in listOfColleges)
	        {
		        context.CollegesDictionaries.Add(item);
	        }

	        #endregion


            #region Dane_Kierownictwo

            List<Person> listaKierownicza = g.GeneratePersons(11);

            List<OrganiziationalUnit> listaDziałów = g.OrganizeOrganiziationalUnit(ref listaKierownicza);

            for (int i = 0; i < listaDziałów.Count; i++)
            {
                context.OrganiziationalUnits.Add(listaDziałów[i]);
            }

            List<Employment> employmentList = g.EmployManagers(ref listaKierownicza);
            
            for (int i = 0; i < employmentList.Count; i++)
            {
                context.Employments.Add(employmentList[i]);
            }
            context.SaveChanges();

            //dodanie kierowników
            foreach (var item in context.Persons)
	        {
                context.Persons.Attach(item);
                item.Manager = context.Persons.Local[1];
                context.Entry(item).State = EntityState.Modified;
	        }
            context.Persons.Local[1].Manager = context.Persons.Local[0];
            context.Persons.Local[0].Manager = context.Persons.Local[0];

            context.SaveChanges();
            

	        #endregion


            #region Pracownicy
            List<Person> pracownicy = g.GeneratePersons(150);

            List<Employment> listWorkersToEmploy = new List<Employment>();
            for (int i = 0; i < pracownicy.Count; i=i+15)
            {
                listWorkersToEmploy.Add(g.EmployWorker(pracownicy[i], "MPJ", "DPJ", context.Persons.Local[6]));
                listWorkersToEmploy.Add(g.EmployWorker(pracownicy[1+i], "PJ", "DPJ", context.Persons.Local[6]));
                listWorkersToEmploy.Add(g.EmployWorker(pracownicy[2+i], "SPJ", "DPJ", context.Persons.Local[6]));
                listWorkersToEmploy.Add(g.EmployWorker(pracownicy[3+i], "MPN", "DPN", context.Persons.Local[7]));
                listWorkersToEmploy.Add(g.EmployWorker(pracownicy[4+i], "PN", "DPN", context.Persons.Local[7]));
                listWorkersToEmploy.Add(g.EmployWorker(pracownicy[5+i], "SPN", "DPN", context.Persons.Local[7]));
                listWorkersToEmploy.Add(g.EmployWorker(pracownicy[6+i], "MPP", "DPP", context.Persons.Local[8]));
                listWorkersToEmploy.Add(g.EmployWorker(pracownicy[7+i], "PP", "DPP", context.Persons.Local[8]));
                listWorkersToEmploy.Add(g.EmployWorker(pracownicy[8+i], "SPP", "DPP", context.Persons.Local[8]));
                listWorkersToEmploy.Add(g.EmployWorker(pracownicy[9+i], "MPR", "DPR", context.Persons.Local[9]));
                listWorkersToEmploy.Add(g.EmployWorker(pracownicy[10+i], "PR", "DPR", context.Persons.Local[9]));
                listWorkersToEmploy.Add(g.EmployWorker(pracownicy[11+i], "SPR", "DPR", context.Persons.Local[9]));
                listWorkersToEmploy.Add(g.EmployWorker(pracownicy[12+i], "MPC", "DPC", context.Persons.Local[10]));
                listWorkersToEmploy.Add(g.EmployWorker(pracownicy[13+i], "PC", "DPC", context.Persons.Local[10]));
                listWorkersToEmploy.Add(g.EmployWorker(pracownicy[14+i], "SPC", "DPC", context.Persons.Local[10]));
            }

            foreach (var item in listWorkersToEmploy)
            {
                context.Employments.Add(item);
            }

            context.SaveChanges();

            #endregion


            #region Godziny pracy
            
            #endregion



        }
    }
}
