using HR.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Core.BasicContract
{
    public abstract class IGlobalUnityOfWork<TSession,TTransaction,TContext,TRepository> 
    where TSession : class 
    where TTransaction : class
    where TContext : class
    {
        #region NHibernate attributes
            public readonly TSession session;
            public TTransaction transaction;
        #endregion

        #region Entity Framework atributes
            public TContext context;
        #endregion

            protected TRepository accountRepository;
            public abstract TRepository AccountRepository {get;}
    }
}
