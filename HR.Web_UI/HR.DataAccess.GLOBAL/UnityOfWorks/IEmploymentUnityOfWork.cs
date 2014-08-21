using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.GLOBAL.UnityOfWorks
{
    public interface IEmploymentUnityOfWork<TRepo, TRepo1, TRepo2, TRepo3, TRepo4, TUnityOfWork>
    {
        TUnityOfWork UnityOfWork { get; set; }
        TRepo OrganizationalUnitRepo { get; set; }
        TRepo1 BankAccountRepo { get; set; }
        TRepo2 EmploymentRepo { get; set; }
        TRepo3 ContractRepo { get; set; }
        TRepo4 ContactPersonRepo { get; set; }
    }
}
