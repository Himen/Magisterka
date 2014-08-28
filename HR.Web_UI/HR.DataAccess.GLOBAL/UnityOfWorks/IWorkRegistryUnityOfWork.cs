using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.GLOBAL.UnityOfWorks
{
    public interface IWorkRegistryUnityOfWork<TRepo,TRepo2, TRepo3, TRepo4, TRepo5, TRepo6, TUnityOfWork>
    {
        TUnityOfWork UnityOfWork { get; set; }
        TRepo PersonRepo { get; set; }
        TRepo2 BenefitProfitsRepo { get; set; }
        TRepo3 WorkRegistryRepo { get; set; }
        TRepo4 VacationRepo { get; set; }
        TRepo5 DelegationRepo { get; set; }
        TRepo6 VacationDocumentRepo { get; set; }
    }
}
