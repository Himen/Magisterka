using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.GLOBAL.UnityOfWorks
{
    public class DicUnityOfWork<TRepo, TRepo1, TRepo2, TRepo3, TUnityOfWork> : IDicUnityOfWork<TRepo, TRepo1, TRepo2, TRepo3, TUnityOfWork>
    {
        public TUnityOfWork UnityOfWork { get; set; }

        public TRepo BankRepo { get; set; }

        public TRepo1 CollegesRepo { get; set; }

        public TRepo2 CompaniesRepo { get; set; }

        public TRepo3 PositionsRepo { get; set; }

        //doimplementowac
        public DicUnityOfWork()
        {
            UnityOfWork = (TUnityOfWork)Activator.CreateInstance(typeof(TUnityOfWork));
            if (UnityOfWork is EF.UnityOfWorks.UnityOfWork)
            {
                var x = UnityOfWork as EF.UnityOfWorks.UnityOfWork;
                BankRepo = (TRepo)Activator.CreateInstance(typeof(TRepo), x.context);
                CollegesRepo = (TRepo1)Activator.CreateInstance(typeof(TRepo1), x.context);
                CompaniesRepo = (TRepo2)Activator.CreateInstance(typeof(TRepo2), x.context);
                PositionsRepo = (TRepo3)Activator.CreateInstance(typeof(TRepo3), x.context);
            }
            else
            {
                var x = UnityOfWork as NH.UnityOfWorks.UnityOfWork;
                BankRepo = (TRepo)Activator.CreateInstance(typeof(TRepo), x.session);
                CollegesRepo = (TRepo1)Activator.CreateInstance(typeof(TRepo1), x.session);
                CompaniesRepo = (TRepo2)Activator.CreateInstance(typeof(TRepo2), x.session);
                PositionsRepo = (TRepo3)Activator.CreateInstance(typeof(TRepo3), x.session);
            }
        }
    }
}
