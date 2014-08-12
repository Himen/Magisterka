using HR.Core.Models;
using HR.DataAccess.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Core.BasicContract;

namespace HR.DataAccess.EF.UnityOfWorks
{
    /// <summary>
    /// W razie problemow:
    /// http://www.c-sharpcorner.com/UploadFile/b19d5a/basic-generic-repository-pattern-and-unity-of-work-framework/
    /// 
    /// mozna jeszcze rozszezyc od rzeczy bedace tam;
    /// http://www.asp.net/mvc/tutorials/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    /// </summary>
    public class UnityOfWork : IUnityOfWork
    {
        private Repository<Account,long> accountRepository;
        HR_DataContext context = new HR_DataContext();

        #region Repository Classes
        public Repository<Account, long> AccountRepository 
        {
            get 
            {
                if (this.accountRepository == null)
                    this.accountRepository = new Repository<Account, long>(context);
                return accountRepository;
            }
        }

        //other classes

        #endregion

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
