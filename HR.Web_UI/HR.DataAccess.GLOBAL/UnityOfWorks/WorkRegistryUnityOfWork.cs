using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.GLOBAL.UnityOfWorks
{
    public class WorkRegistryUnityOfWork<TRepo, TRepo2, TRepo3, TRepo4, TRepo5, TRepo6, TUnityOfWork> : IWorkRegistryUnityOfWork<TRepo, TRepo2, TRepo3, TRepo4, TRepo5, TRepo6, TUnityOfWork>
    {
        public TUnityOfWork UnityOfWork { get; set; }
        public TRepo PersonRepo { get; set; }
        public TRepo2 BenefitProfitsRepo { get; set; }
        public TRepo3 WorkRegistryRepo { get; set; }
        public TRepo4 VacationRepo { get; set; }
        public TRepo5 DelegationRepo { get; set; }
        public TRepo6 VacationDocumentRepo { get; set; }

        public WorkRegistryUnityOfWork()
        {
            UnityOfWork = (TUnityOfWork)Activator.CreateInstance(typeof(TUnityOfWork));
            if (UnityOfWork is EF.UnityOfWorks.UnityOfWork)
            {
                var x = UnityOfWork as EF.UnityOfWorks.UnityOfWork;
                PersonRepo = (TRepo)Activator.CreateInstance(typeof(TRepo), x.context);
                BenefitProfitsRepo = (TRepo2)Activator.CreateInstance(typeof(TRepo2), x.context);
                WorkRegistryRepo = (TRepo3)Activator.CreateInstance(typeof(TRepo3), x.context);
                VacationRepo = (TRepo4)Activator.CreateInstance(typeof(TRepo4), x.context);
                DelegationRepo = (TRepo5)Activator.CreateInstance(typeof(TRepo5), x.context);
                VacationDocumentRepo = (TRepo6)Activator.CreateInstance(typeof(TRepo6), x.context);
            }
            else
            {
                var x = UnityOfWork as NH.UnityOfWorks.UnityOfWork;
                PersonRepo = (TRepo)Activator.CreateInstance(typeof(TRepo), x.session);
                BenefitProfitsRepo = (TRepo2)Activator.CreateInstance(typeof(TRepo2), x.session);
                WorkRegistryRepo = (TRepo3)Activator.CreateInstance(typeof(TRepo3), x.session);
                VacationRepo = (TRepo4)Activator.CreateInstance(typeof(TRepo4), x.session);
                DelegationRepo = (TRepo5)Activator.CreateInstance(typeof(TRepo5), x.session);
                VacationDocumentRepo = (TRepo6)Activator.CreateInstance(typeof(TRepo6), x.session);
            }
        }
    }
}
