using HR.Core.BasicContract;
using HR.Core.Models;
using HR.DataAccess.EF.Repositories;
using HR.DataAccess.NH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF = HR.DataAccess.EF.UnityOfWorks;
using NH = HR.DataAccess.NH.UnityOfWorks;

namespace HR.DataAccess.GLOBAL.UnityOfWorks
{
    /// <summary>
    /// Kroki 
    ///  1   Dla EF zrobic  ok
    ///  2   Potem generyczne repozytorium ok
    ///  3   generyczne unity of work ok
    ///  3   potem dla NH ok 
    ///  4   potem dla wszystkich
    /// </summary>
    
    //1
    /*public class AdminUnityOfWork : HR.DataAccess.EF.UnityOfWorks.UnityOfWork
    {
        public Repository<Account, long> AccountRepo;

        public AdminUnityOfWork()
        {
            AccountRepo = new Repository<Account, long>(context);
        }
    }*/

    //2
    /*public class AdminUnityOfWork<TRepo> : HR.DataAccess.EF.UnityOfWorks.UnityOfWork
    {
        public TRepo AccountRepo;

        public AdminUnityOfWork()
        {
            AccountRepo = (TRepo)Activator.CreateInstance(typeof(TRepo));
        }
    }*/


    public class AdminUnityOfWork<TRepo, TUnityOfWork> : IAdminUnityOfWork<TRepo, TUnityOfWork>
    {
        public TUnityOfWork UnityOfWork { get; set; }
        public TRepo AccountRepo { get; set; }

        public AdminUnityOfWork()
        {
            UnityOfWork = (TUnityOfWork)Activator.CreateInstance(typeof(TUnityOfWork));
            if (UnityOfWork is EF.UnityOfWorks.UnityOfWork)
            {
                var x = UnityOfWork as EF.UnityOfWorks.UnityOfWork;
                AccountRepo = (TRepo)Activator.CreateInstance(typeof(TRepo), x.context);
            }
            else
            {
                var x = UnityOfWork as NH.UnityOfWorks.UnityOfWork;
                AccountRepo = (TRepo)Activator.CreateInstance(typeof(TRepo), x.session);
            }
        }

    }

}
