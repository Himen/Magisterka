using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Core.BasicContract;
using NHibernate;
using HR.DataAccess.NH.Repositories;
using HR.Core.Models;

namespace HR.DataAccess.NH.UnityOfWorks
{
    public class UnityOfWork :  IUnityOfWork
    {
        private readonly ISession session;
        private ITransaction transaction;

        private Repository<Account, long> accountRepository;

        public UnityOfWork(ISession _session)
        {
            session = _session;
            transaction = _session.BeginTransaction();
        }

        public void SaveChanges()
        {
            if (transaction == null)
                throw new InvalidOperationException("UnityOfWork have already beem saved");

            transaction.Commit();
            transaction = null;
        }

        public void Dispose()
        {
            if (transaction != null)
                transaction.Rollback();

            GC.SuppressFinalize(this);
        }
    }
}
