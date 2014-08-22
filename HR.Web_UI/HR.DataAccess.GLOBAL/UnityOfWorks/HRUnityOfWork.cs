using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.GLOBAL.UnityOfWorks
{
    public class HRUnityOfWork<TRepo, TRepo2, TRepo3, TUnityOfWork> : IHRUnityOfWork<TRepo, TRepo2, TRepo3, TUnityOfWork>
    {
        //powinno byc tak ze przekazywany jest tu repo EF lun NH i tutaj zutowaner na konkretna klase ale narazie sie nie da
        //public TRepo<object,int> MyProperty { get; set; }
        public TUnityOfWork UnityOfWork { get; set; }
        public TRepo PersonRepo { get; set; }
        public TRepo2 AccountRepo { get; set; }
        public TRepo3 AdditionalInfoRepo { get; set; }

        public HRUnityOfWork()
        {
            UnityOfWork = (TUnityOfWork)Activator.CreateInstance(typeof(TUnityOfWork));
            if (UnityOfWork is EF.UnityOfWorks.UnityOfWork)
            {
                var x = UnityOfWork as EF.UnityOfWorks.UnityOfWork;
                PersonRepo = (TRepo)Activator.CreateInstance(typeof(TRepo), x.context);
                AccountRepo = (TRepo2)Activator.CreateInstance(typeof(TRepo2), x.context);
                AdditionalInfoRepo = (TRepo3)Activator.CreateInstance(typeof(TRepo3), x.context);
            }
            else
            {
                var x = UnityOfWork as NH.UnityOfWorks.UnityOfWork;
                PersonRepo = (TRepo)Activator.CreateInstance(typeof(TRepo), x.session);
                AccountRepo = (TRepo2)Activator.CreateInstance(typeof(TRepo2), x.session);
                AdditionalInfoRepo = (TRepo3)Activator.CreateInstance(typeof(TRepo3), x.session);
            }
        }
    }
}
