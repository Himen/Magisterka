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
                employmentUnityOfWorkNH.UnityOfWork.SaveChanges();
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
                    employmentUnityOfWorkNH.EmploymentRepo.Add(employees[i]);
                }
                employmentUnityOfWorkNH.UnityOfWork.SaveChanges();
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

        public bool InsertPersonsDAP(List<Person> persons)
        {
            throw new NotImplementedException();
        }

        public bool InsertEmployeesDAP(List<Employment> employees)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAllWorkersDAP()
        {
            throw new NotImplementedException();
        }


        public bool DeletePersonsEF(List<Employment> employees)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePersonsEF(List<Person> persons)
        {
            throw new NotImplementedException();
        }
    }
}