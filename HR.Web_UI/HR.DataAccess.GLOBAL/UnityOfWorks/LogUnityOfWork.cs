using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.GLOBAL.UnityOfWorks
{
    public class LogUnityOfWork<TRepo, TUnityOfWork> : ILogUnityOfWork<TRepo, TUnityOfWork>
    {
        public TUnityOfWork UnityOfWork { get; set; }
        public TRepo AccountLogRepo { get; set; }

        public LogUnityOfWork()
        {
            UnityOfWork = (TUnityOfWork)Activator.CreateInstance(typeof(TUnityOfWork));
            if (UnityOfWork is EF.UnityOfWorks.UnityOfWork)
            {
                var x = UnityOfWork as EF.UnityOfWorks.UnityOfWork;
                AccountLogRepo = (TRepo)Activator.CreateInstance(typeof(TRepo), x.context);
            }
            else
            {
                var x = UnityOfWork as NH.UnityOfWorks.UnityOfWork;
                AccountLogRepo = (TRepo)Activator.CreateInstance(typeof(TRepo), x.session);
            }
        }
    }
}
