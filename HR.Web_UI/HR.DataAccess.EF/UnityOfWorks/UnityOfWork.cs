using HR.Core.Models;
using HR.DataAccess.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.EF.UnityOfWorks
{
    public class UnityOfWork : IDisposable, IUnityOfWork
    {
        private Repository<Account> accountRepository;
        HR_DataContext context = new HR_DataContext();

        #region Repository Classes
        public Repository<Account> AccountRepository 
        {
            get 
            {
                if (this.accountRepository == null)
                    this.accountRepository = new Repository<Account>(context);
                return accountRepository;
            }
        }

        //other classes

        #endregion

        public void Save()
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
