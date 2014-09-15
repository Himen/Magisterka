using HR.Core.Models;
using HR.Web_UI.Services.ServicesInferface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF_R = HR.DataAccess.EF.Repositories;
using NH_R = HR.DataAccess.NH.Repositories;
using EF_U = HR.DataAccess.EF.UnityOfWorks;
using NH_U = HR.DataAccess.NH.UnityOfWorks;
using HR.DataAccess.GLOBAL.UnityOfWorks;
using HR.Core.Models.RepoModels;
using HR.Core.Enums;
using System.Data.SqlClient;
using Dapper;

namespace HR.Web_UI.Services
{
    public class ORMTestService : IORMTestService
    {
        IEmploymentUnityOfWork<NH_R.Repository<OrganiziationalUnit, long>, NH_R.Repository<BankAccount, long>,
            NH_R.Repository<Employment, long>, NH_R.Repository<Contract, long>, NH_R.Repository<ContactPerson, long>,
            NH_R.Repository<Person, long>, NH_U.UnityOfWork> employmentUnityOfWorkNH;

        IEmploymentUnityOfWork<EF_R.Repository<OrganiziationalUnit, long>, EF_R.Repository<BankAccount, long>,
            EF_R.Repository<Employment, long>, EF_R.Repository<Contract, long>, EF_R.Repository<ContactPerson, long>,
            EF_R.Repository<Person, long>, EF_U.UnityOfWork> employmentUnityOfWorkEF;

        //jeszcze dapper

        public ORMTestService(IEmploymentUnityOfWork<NH_R.Repository<OrganiziationalUnit, long>, NH_R.Repository<BankAccount, long>,
            NH_R.Repository<Employment, long>, NH_R.Repository<Contract, long>, NH_R.Repository<ContactPerson, long>,
            NH_R.Repository<Person, long>, NH_U.UnityOfWork> employmentUnityOfWorkNH,IEmploymentUnityOfWork<EF_R.Repository<OrganiziationalUnit, long>, EF_R.Repository<BankAccount, long>,
            EF_R.Repository<Employment, long>, EF_R.Repository<Contract, long>, EF_R.Repository<ContactPerson, long>,
            EF_R.Repository<Person, long>, EF_U.UnityOfWork> employmentUnityOfWorkEF)
        {
            this.employmentUnityOfWorkEF = employmentUnityOfWorkEF;
            this.employmentUnityOfWorkNH = employmentUnityOfWorkNH;
        }

        public bool InsertPersonsEF(List<Person> persons)
        {
            try
            {
                for (int i = 0; i < persons.Count; i++)
                {
                    employmentUnityOfWorkEF.PersonRepo.Add(persons[i]);
                }
                employmentUnityOfWorkEF.UnityOfWork.SaveChanges();
                return true;
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

        public bool InsertEmployeesEF(List<Employment> employees)
        {
            try
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    employmentUnityOfWorkEF.EmploymentRepo.Add(employees[i]);
                }
                employmentUnityOfWorkEF.UnityOfWork.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //employmentUnityOfWork.UnityOfWork.Dispose();
            }
        }

        public IEnumerable<Person> GetAllWorkersEF()
        {
            try
            {
                var x = employmentUnityOfWorkEF.PersonRepo.GetAll().Where(c => c.Employment.EmploymentType != EmploymentType.Kandydat
                                                                    && c.Employment.EmploymentType != EmploymentType.DoZatwierdzenia
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

        public bool InsertPersonsNH(List<Person> persons)
        {
            try
            {
                for (int i = 0; i < persons.Count; i++)
                {
                    employmentUnityOfWorkNH.PersonRepo.Add(persons[i]);
                }
                //employmentUnityOfWorkNH.UnityOfWork.SaveChanges();
                return true;
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

        public bool InsertEmployeesNH(List<Employment> employees)
        {
            try
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    /*employees[i].PersonId = 1;
                    employees[i].ContractId = 1;
                    employees[i].BankAccountId = 1;*/
                    employmentUnityOfWorkNH.EmploymentRepo.Add(employees[i]);
                }
                //employmentUnityOfWorkNH.UnityOfWork.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //employmentUnityOfWork.UnityOfWork.Dispose();
            }
        }

        public IEnumerable<Person> GetAllWorkersNH()
        {
            try
            {
                var x = employmentUnityOfWorkNH.PersonRepo.GetAll().Where(c => c.Employment.EmploymentType != EmploymentType.Kandydat
                                                                    && c.Employment.EmploymentType != EmploymentType.DoZatwierdzenia
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

        public bool InsertPersonsDAP(List<Person> persons , SqlConnection con)
        {
            try
            {
                foreach (var item in persons)
                {
                    AddPersonDapper(item, con);
                }
                
                return true;
            }   
            catch (Exception)
            {
                
                throw;
            }
        }

        private long SelectLastPersonNextID(SqlConnection con)
        {
            string query = "SELECT Id FROM persons WHERE Id = (SELECT MAX(Id) FROM persons)";
            long id = con.Query<long>(query).FirstOrDefault()+1;

            return id;
        }

        private long SelectLastAccountNextID(SqlConnection con)
        {
            string query = "SELECT Id FROM accounts WHERE Id = (SELECT MAX(Id) FROM Accounts)";
            long id = con.Query<long>(query).FirstOrDefault() + 1;

            return id;
        }

        private long SelectLastBankAccountNextID(SqlConnection con)
        {
            string query = "SELECT Id FROM bankaccounts WHERE Id = (SELECT MAX(Id) FROM bankaccounts)";
            long id = con.Query<long>(query).FirstOrDefault() + 1;

            return id;
        }

        private long SelectLastContractNextID(SqlConnection con)
        {
            string query = "SELECT Id FROM contracts WHERE Id = (SELECT MAX(Id) FROM contracts)";
            long id = con.Query<long>(query).FirstOrDefault() + 1;

            return id;
        }


        private bool AddPersonDapper(Person p, SqlConnection con)
        {

            p.Id = SelectLastPersonNextID(con);
            long AccountId = SelectLastAccountNextID(con);
            p.ManagerId = 1;

            string query = "INSERT INTO [dbo].[Persons] ( [FirstName], [Surname], [DateOfBirth], [City], [PostalCode], [Street], [BuildingNumber], [ApartmentNumber], [Phone], [Email], [NIP], [IDCard], [PESEL], [ManagerId], [DataState], [CreateDate], [EditDate])"+
                " VALUES ( @FirstName, @Surname, @DateOfBirth, @City, @PostalCode, @Street, @BuildingNumber, @ApartmentNumber, CAST(@Phone AS Decimal(18, 0)), @Email, CAST(@NIP AS Decimal(18, 0)), @IDCard, @PESEL, @ManagerId, @DataState, @CreateDate, @EditDate)";
            var su = con.Execute(query, new { p.Id, p.FirstName, p.Surname, p.DateOfBirth,p.City,p.PostalCode,p.Street,p.BuildingNumber,p.ApartmentNumber,p.Phone,p.Email,p.NIP,p.IDCard,p.PESEL,p.ManagerId,p.DataState,p.CreateDate,p.EditDate });

            string queryAccount = "INSERT INTO [dbo].[Accounts] ( [UserName], [Password], [AccountType], [DataState], [CreateDate], [EditDate], [PersonId])" +
                " VALUES ( @UserName, @Password, @AccountType, @DataState, @CreateDate, @EditDate, @PersonId)";
            long PersonId = p.Id;
            su = con.Execute(queryAccount, new { p.Account.UserName, p.Account.Password, p.Account.AccountType, p.Account.DataState, p.Account.CreateDate, p.Account.EditDate, PersonId });

            AccountLog acl = p.Account.AccountLogs.FirstOrDefault();

            string queryAccountLogs = "INSERT INTO [LOG].[AccountLogs] ( [Action], [ActionType], [ActionDescription], [StartDate], [EndDate], [AccountId], [DataState], [CreateDate], [EditDate])"+
                " VALUES ( @Action, @ActionType,@ActionDescription, @StartDate,@EndDate, @AccountId, @DataState, @CreateDate, @EditDate)";
            su = con.Execute(queryAccountLogs, new { acl.Action, acl.ActionType, acl.ActionDescription, acl.StartDate, acl.EndDate, AccountId, acl.DataState, acl.CreateDate, acl.EditDate });

            string queryAditional = "INSERT INTO [dbo].[AdditionalInformations] ( [FacebookAccount], [GoogleAccount], [TwitterAccount], [GoldenLineAccount], [LinkInAccount], [DataState], [CreateDate], [EditDate], [PersonId])"+
                " VALUES ( @FacebookAccount, @GoogleAccount, @TwitterAccount, @GoldenLineAccount, @LinkInAccount, @DataState, @CreateDate, @EditDate, @PersonId)";
            su = con.Execute(queryAditional, new { p.AdditionalInformation.FacebookAccount,p.AdditionalInformation.GoogleAccount,p.AdditionalInformation.TwitterAccount,p.AdditionalInformation.GoldenLineAccount,p.AdditionalInformation.LinkInAccount,p.AdditionalInformation.DataState,p.AdditionalInformation.CreateDate,p.AdditionalInformation.EditDate,PersonId });

            string queryContact = "INSERT INTO [dbo].[ContactPersons] ( [FirstName], [Surname], [City], [PostalCode], [Street], [BuildingNumber], [ApartmentNumber], [Phone], [Email], [DataState], [CreateDate], [EditDate], [PersonId])"+
            " VALUES (@FirstName, @Surname, @City, @PostalCode, @Street, @BuildingNumber, @ApartmentNumber, CAST(@Phone AS Decimal(18, 0)), @Email, @DataState, @CreateDate, @EditDate, @PersonId)";
            su = con.Execute(queryContact, new { p.ContactPerson.FirstName,p.ContactPerson.Surname,p.ContactPerson.City,p.ContactPerson.PostalCode,p.ContactPerson.Street,p.ContactPerson.BuildingNumber,p.ContactPerson.ApartmentNumber,p.ContactPerson.Phone,p.ContactPerson.Email,p.ContactPerson.DataState,p.ContactPerson.CreateDate,p.ContactPerson.EditDate,PersonId });

            string queryCollage = "INSERT INTO [dbo].[Collages] ( [Name], [FieldOfStudy], [Specialization], [AcademicTitle], [TitleOfResearch], [Progres], [StartDate], [EndDate], [PersonId], [DataState], [CreateDate], [EditDate])" +
                " VALUES ( @Name, @FieldOfStudy, @Specialization, @AcademicTitle, @TitleOfResearch, @Progres, @StartDate, @EndDate, @PersonId, @DataState, @CreateDate, @EditDate)";

            foreach (var i in p.Colleges)
            {
                su = con.Execute(queryCollage, new {i.Name,i.FieldOfStudy,i.Specialization,i.AcademicTitle,i.TitleOfResearch, i.Progres,i.StartDate,i.EndDate,PersonId,i.DataState,i.CreateDate,i.EditDate });
            }

            string queryJobs = "INSERT INTO [dbo].[Jobs] ( [CompanyName], [Position], [StartDate], [EndDate], [Description], [PersonId], [DataState], [CreateDate], [EditDate])"+
                " VALUES ( @CompanyName, @Position, @StartDate, @EndDate,@Description, @PersonId, @DataState, @CreateDate, @EditDate)";

            foreach (var i in p.Jobs)
            {
                su = con.Execute(queryJobs, new { i.CompanyName,i.Position,i.StartDate,i.EndDate,i.Description,PersonId,i.DataState,i.CreateDate,i.EditDate });
            }

            string queryTranings = "INSERT INTO [dbo].[Tranings] ( [Name], [Type], [DateOfPass], [Description], [PersonId], [DataState], [CreateDate], [EditDate])" +
                " VALUES ( @Name, @Type, @DateOfPass, @Description, @PersonId, @DataState, @CreateDate, @EditDate)";

            foreach (var i in p.Trainings)
            {
                su = con.Execute(queryTranings, new { i.Name,i.Type,i.DateOfPass,i.Description,PersonId,i.DataState,i.CreateDate,i.EditDate });
            }

            /*string querydoc = "INSERT INTO [REPO].[Documents] ( [Name], [Type], [Description], [PersonId], [DataState], [CreateDate], [EditDate])"+
                " SELECT 1, 'test', BulkColumn FROM Openrowset( Bulk 'C:\test.jpg', Single_Blob) as image";

            foreach (var i in p.Documents)
            {
                su = con.Execute(querydoc, new { i.Name, i.Type, i.DateOfPass, i.Description, PersonId, i.DataState, i.CreateDate, i.EditDate });
            }*/


            return true;
        }


        private bool AddEmployeeDapper(Employment e, SqlConnection con)
        {
            long BankAccountId = SelectLastBankAccountNextID(con);
            long ContractId = SelectLastContractNextID(con);
            long PersonId = SelectLastPersonNextID(con);

            string queryBankAccount = "INSERT INTO [dbo].[BankAccounts] ( [BankName], [BankAddress], [AccountNumber], [DataState], [CreateDate], [EditDate])" +
               " VALUES (@BankName, @BankAddress,@AccountNumber,@DataState,@CreateDate, @EditDate)";
            var su = con.Execute(queryBankAccount, new { e.BankAccount.BankName, e.BankAccount.BankAddress, e.BankAccount.AccountNumber, e.BankAccount.DataState, e.BankAccount.CreateDate, e.BankAccount.EditDate });

            string queryContract = "INSERT INTO [dbo].[Contracts] ( [StartDate], [EndDate], [ContractType], [ContractDimension], [MonthBenefit], [BenefitPerHour], [DataState], [CreateDate], [EditDate])" +
                " VALUES ( @StartDate, @EndDate, @ContractType, @ContractDimension, @MonthBenefit, @BenefitPerHour,@DataState, @CreateDate, @EditDate)";
            su = con.Execute(queryContract, new { e.Contract.StartDate, e.Contract.EndDate, e.Contract.ContractType, e.Contract.ContractDimension, e.Contract.MonthBenefit, e.Contract.BenefitPerHour, e.Contract.DataState, e.Contract.CreateDate, e.Contract.EditDate });

            AddPersonDapper(e.Person, con);

            string query = "INSERT INTO [dbo].[Employments] ( [PositionCode], [OrganiziationalUnitCode], [EmploymentType], [StartDate], [EndDate], [DataState], [CreateDate], [EditDate], [BankAccountId], [ContractId], [PersonId])"+
                " VALUES ( @PositionCode, @OrganiziationalUnitCode, @EmploymentType, @StartDate, @EndDate, @DataState, @CreateDate, @EditDate, @BankAccountId, @ContractId, @PersonId)";
            su = con.Execute(query, new { e.PositionCode,e.OrganiziationalUnitCode,e.EmploymentType,e.StartDate,e.EndDate,e.DataState,e.CreateDate,e.EditDate,BankAccountId,ContractId,PersonId });


            return true;
        }


        public bool InsertEmployeesDAP(List<Employment> employees,SqlConnection con)
        {
            try
            {
                foreach (var item in employees)
                {
                    AddEmployeeDapper(item, con);
                }

                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public IEnumerable<Person> GetAllWorkersDAP(SqlConnection con,int ile)
        {
            try
            {
                /*string query = "select e.*, p.*,ba.* from Employments e"+
                                "join Persons p on(e.PersonId=p.Id)"+
                                "join BankAccounts ba on(e.BankAccountId=e.BankAccountId)"+
                                "join Contracts con on(e.ContractId=con.Id)";*/
                string query = "select top " + ile + " p.*,a.*,al.*,ai.*,cp.*,col.*,j.*,t.* from Persons p " +
                                "join Accounts a on(a.PersonId=p.Id) "+
                                "join LOG.AccountLogs al on(a.Id=al.AccountId) "+
                                "join AdditionalInformations ai on(p.Id=ai.PersonId) "+
                                "join ContactPersons cp on(p.Id=cp.PersonId) "+
                                "join Collages col on(p.Id=col.PersonId) "+
                                "join Jobs j on(p.Id= j.PersonId) "+
                                "join Tranings t on(p.Id=t.PersonId) ";


                var x = con.Query(query).ToList();

                return null;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IEnumerable<Person> GetAllWorkersDAPOrder(SqlConnection con, string order, long ile)
        {
            string query = "select top " + ile + " p.*,a.*,al.*,ai.*,cp.*,col.*,j.*,t.* from Persons p " +
                                "join Accounts a on(a.PersonId=p.Id) " +
                                "join LOG.AccountLogs al on(a.Id=al.AccountId) " +
                                "join AdditionalInformations ai on(p.Id=ai.PersonId) " +
                                "join ContactPersons cp on(p.Id=cp.PersonId) " +
                                "join Collages col on(p.Id=col.PersonId) " +
                                "join Jobs j on(p.Id= j.PersonId) " +
                                "join Tranings t on(p.Id=t.PersonId) "+
                                "where p.Email like '%a%' ";


            var x = con.Query(query).ToList();

            return null;
        }

        public IEnumerable<Person> GetAllWorkersDAPWhere(SqlConnection con, string order,long ile)
        {
            string query = "select top " + ile + " p.*,a.*,al.*,ai.*,cp.*,col.*,j.*,t.* from Persons p " +
                                "join Accounts a on(a.PersonId=p.Id) " +
                                "join LOG.AccountLogs al on(a.Id=al.AccountId) " +
                                "join AdditionalInformations ai on(p.Id=ai.PersonId) " +
                                "join ContactPersons cp on(p.Id=cp.PersonId) " +
                                "join Collages col on(p.Id=col.PersonId) " +
                                "join Jobs j on(p.Id= j.PersonId) " +
                                "join Tranings t on(p.Id=t.PersonId) "+
                                "order by p.Email ";


            var x = con.Query(query).ToList();

            return null;
        }


        public bool DeleteEmploymentEF(List<Employment> employees)
        {
            try
            {
                foreach (var item in employees)
	            {
                    employmentUnityOfWorkEF.EmploymentRepo.RemoveFinaly(item);
	            }

                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool UpdateEmploymentEF(List<Employment> employees)
        {
            try
            {
                foreach (var item in employees)
                {
                    employmentUnityOfWorkEF.EmploymentRepo.Update(item);
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteEmploymentNH(List<Employment> employees)
        {
            try
            {
                foreach (var item in employees)
                {
                    employmentUnityOfWorkNH.EmploymentRepo.RemoveFinaly(item);
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateEmploymentNH(List<Employment> employees)
        {
            try
            {
                foreach (var item in employees)
                {
                    employmentUnityOfWorkNH.EmploymentRepo.Update(item);
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteEmploymentDAP(List<Employment> employees, SqlConnection con)
        {

            try
            {
                string query = "Delete from employments where employments.Id = @Id";
                string queryP = "Delete from Person where Person.Id = @Id";
                string queryBA = "Delete from Bankaccounts where Bankaccounts.Id = @Id";
                string queryC = "Delete from contracts where contracts.Id = @Id";

                foreach (var item in employees)
                {
                    /*con.Execute(queryC, new { item.Contract.Id });
                    con.Execute(queryBA, new { item.BankAccount.Id });
                    con.Execute(queryP, new { item.Person.Id });*/
                    con.Execute(query, new { item.Id });
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateEmploymentDAP(List<Employment> emp, SqlConnection con)
        {
            try
            {
                //[PositionCode], [OrganiziationalUnitCode], [EmploymentType], [StartDate], [EndDate], [DataState], [CreateDate], [EditDate], [BankAccountId], [ContractId], [PersonId]
                string query = "update Employments set "+
                                "PositionCode=@PositionCode,"+
                                "OrganiziationalUnitCode=@OrganiziationalUnitCode," +
                                "EmploymentType=@EmploymentType," +
                                "StartDate=@StartDate," +
                                "EndDate=@EndDate," +
                                "DataState=@DataState," +
                                "CreateDate=@CreateDate," +
                                "EditDate=@EditDate," +
                                "BankAccountId=@BankAccountId," +
                                "ContractId=@ContractId," +
                                "PersonId=@PersonId " +
                                "where Id =@Id";

                foreach (var item in emp)
                {
                    long BankAccountId = item.BankAccount.Id;
                    long ContractId = item.Contract.Id;
                    long PersonId = item.Person.Id;
                    con.Execute(query, new
                    {
                        item.Id,
                        item.PositionCode,
                        item.OrganiziationalUnitCode,
                        item.EmploymentType,
                        item.StartDate,
                        item.EndDate,
                        item.DataState,
                        item.CreateDate,
                        item.EditDate,
                        BankAccountId,
                        ContractId,
                        PersonId

                    });
                }
               
                string result = "updated";
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }





        public IEnumerable<Employment> GetAllEmployeesEF()
        {
            try
            {
                return employmentUnityOfWorkEF.EmploymentRepo.GetAll();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IEnumerable<Employment> GetAllEmployeesNH()
        {
            return employmentUnityOfWorkNH.EmploymentRepo.GetAll();
        }

        public IEnumerable<Employment> GetAllEmployeesDAP(SqlConnection con, int ile)
        {
            try
            {
                string query = "select top "+ile+" * from Employments";

                return con.Query<Employment>(query).ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}