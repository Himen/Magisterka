using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.GLOBAL.UnityOfWorks
{
    public class LogUnityOfWork<TRepo, TRepo1, TUnityOfWork> : ILogUnityOfWork<TRepo, TRepo1, TUnityOfWork>
    {
        public TUnityOfWork UnityOfWork { get; set; }
        public TRepo AccountLogRepo { get; set; }
        public TRepo1 AccountRepo { get; set; }

        public LogUnityOfWork()
        {
            UnityOfWork = (TUnityOfWork)Activator.CreateInstance(typeof(TUnityOfWork));
            if (UnityOfWork is EF.UnityOfWorks.UnityOfWork)
            {
                var x = UnityOfWork as EF.UnityOfWorks.UnityOfWork;
                AccountLogRepo = (TRepo)Activator.CreateInstance(typeof(TRepo), x.context);
                AccountRepo = (TRepo1)Activator.CreateInstance(typeof(TRepo1), x.context);
            }
            else
            {
                var x = UnityOfWork as NH.UnityOfWorks.UnityOfWork;
                AccountLogRepo = (TRepo)Activator.CreateInstance(typeof(TRepo), x.session);
                AccountRepo = (TRepo1)Activator.CreateInstance(typeof(TRepo1), x.session);
            }
        }
    }
}
