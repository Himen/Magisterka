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
        public readonly ISession session;
        private static ITransaction transaction;

        public UnityOfWork()
        {
            session = NHContext.OpenSession();
            transaction = session.BeginTransaction();
        }

        public UnityOfWork(ISession _session )
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
