using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.GLOBAL.UnityOfWorks
{
    public class EmploymentUnityOfWork<TRepo, TRepo1, TRepo2, TRepo3, TRepo4, TUnityOfWork> : IEmploymentUnityOfWork<TRepo, TRepo1, TRepo2, TRepo3, TRepo4, TUnityOfWork>
    {
        public TUnityOfWork UnityOfWork { get; set; }
        public TRepo OrganizationalUnitRepo { get; set; }
        public TRepo1 BankAccountRepo { get; set; }
        public TRepo2 EmploymentRepo { get; set; }
        public TRepo3 ContractRepo { get; set; }
        public TRepo4 ContactPersonRepo { get; set; }

        public EmploymentUnityOfWork()
        {
            UnityOfWork = (TUnityOfWork)Activator.CreateInstance(typeof(TUnityOfWork));
            if (UnityOfWork is EF.UnityOfWorks.UnityOfWork)
            {
                var x = UnityOfWork as EF.UnityOfWorks.UnityOfWork;
                OrganizationalUnitRepo = (TRepo)Activator.CreateInstance(typeof(TRepo), x.context);
                BankAccountRepo = (TRepo1)Activator.CreateInstance(typeof(TRepo1), x.context);
                EmploymentRepo = (TRepo2)Activator.CreateInstance(typeof(TRepo2), x.context);
                ContractRepo = (TRepo3)Activator.CreateInstance(typeof(TRepo3), x.context);
                ContactPersonRepo = (TRepo4)Activator.CreateInstance(typeof(TRepo4), x.context);
            }
            else
            {
                var x = UnityOfWork as NH.UnityOfWorks.UnityOfWork;
                OrganizationalUnitRepo = (TRepo)Activator.CreateInstance(typeof(TRepo), x.session);
                BankAccountRepo = (TRepo1)Activator.CreateInstance(typeof(TRepo1), x.session);
                EmploymentRepo = (TRepo2)Activator.CreateInstance(typeof(TRepo2), x.session);
                ContractRepo = (TRepo3)Activator.CreateInstance(typeof(TRepo3), x.session);
                ContactPersonRepo = (TRepo4)Activator.CreateInstance(typeof(TRepo4), x.session);
            }
        }

    }
}
