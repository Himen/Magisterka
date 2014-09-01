using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.GLOBAL.UnityOfWorks
{
    public class HRUnityOfWork<TRepo, TRepo2, TRepo3, TRepo4, TRepo5,TRepo6,TRepo7,TRepo8, TUnityOfWork> : IHRUnityOfWork<TRepo, TRepo2, TRepo3, TRepo4, TRepo5,TRepo6,TRepo7,TRepo8, TUnityOfWork>
    {
        //powinno byc tak ze przekazywany jest tu repo EF lun NH i tutaj zutowaner na konkretna klase ale narazie sie nie da
        //public TRepo<object,int> MyProperty { get; set; }
        public TUnityOfWork UnityOfWork { get; set; }
        public TRepo PersonRepo { get; set; }
        public TRepo2 AccountRepo { get; set; }
        public TRepo3 AdditionalInfoRepo { get; set; }
        public TRepo4 CollageRepo { get; set; }
        public TRepo5 JobRepo { get; set; }
        public TRepo6 TraningRepo { get; set; }
        public TRepo7 PromotialMaterialsRepo { get; set; }
        public TRepo8 DocumentsRepo { get; set; }


        public HRUnityOfWork()
        {
            UnityOfWork = (TUnityOfWork)Activator.CreateInstance(typeof(TUnityOfWork));
            if (UnityOfWork is EF.UnityOfWorks.UnityOfWork)
            {
                var x = UnityOfWork as EF.UnityOfWorks.UnityOfWork;
                PersonRepo = (TRepo)Activator.CreateInstance(typeof(TRepo), x.context);
                AccountRepo = (TRepo2)Activator.CreateInstance(typeof(TRepo2), x.context);
                AdditionalInfoRepo = (TRepo3)Activator.CreateInstance(typeof(TRepo3), x.context);
                CollageRepo = (TRepo4)Activator.CreateInstance(typeof(TRepo4), x.context);
                JobRepo = (TRepo5)Activator.CreateInstance(typeof(TRepo5), x.context);
                TraningRepo = (TRepo6)Activator.CreateInstance(typeof(TRepo6), x.context);
                PromotialMaterialsRepo = (TRepo7)Activator.CreateInstance(typeof(TRepo7), x.context);
                DocumentsRepo = (TRepo8)Activator.CreateInstance(typeof(TRepo8), x.context);
            }
            else
            {
                var x = UnityOfWork as NH.UnityOfWorks.UnityOfWork;
                PersonRepo = (TRepo)Activator.CreateInstance(typeof(TRepo), x.session);
                AccountRepo = (TRepo2)Activator.CreateInstance(typeof(TRepo2), x.session);
                AdditionalInfoRepo = (TRepo3)Activator.CreateInstance(typeof(TRepo3), x.session);
                CollageRepo = (TRepo4)Activator.CreateInstance(typeof(TRepo4), x.session);
                JobRepo = (TRepo5)Activator.CreateInstance(typeof(TRepo5), x.session);
                TraningRepo = (TRepo6)Activator.CreateInstance(typeof(TRepo6), x.session);
                PromotialMaterialsRepo = (TRepo7)Activator.CreateInstance(typeof(TRepo7), x.session);
                DocumentsRepo = (TRepo8)Activator.CreateInstance(typeof(TRepo8), x.session);
            }
        }
    }
}
