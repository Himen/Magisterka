using HR.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Core.BasicContract
{
    public abstract class GlobalUnityOfWorkBase<TSession, TTransaction, TContext> 
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

    }
}
