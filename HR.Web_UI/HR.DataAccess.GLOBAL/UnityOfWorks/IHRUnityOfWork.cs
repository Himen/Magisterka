using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.GLOBAL.UnityOfWorks
{
    public interface IHRUnityOfWork<TRepo, TRepo2, TRepo3, TRepo4, TRepo5, TRepo6, TRepo7, TRepo8, TUnityOfWork>
    {
        TUnityOfWork UnityOfWork { get; set; }
        TRepo PersonRepo { get; set; }
        TRepo2 AccountRepo { get; set; }
        TRepo3 AdditionalInfoRepo { get; set; }
        TRepo4 CollageRepo { get; set; }
        TRepo5 JobRepo { get; set; }
        TRepo6 TraningRepo { get; set; }
        TRepo7 PromotialMaterialsRepo { get; set; }
        TRepo8 DocumentsRepo { get; set; }
    }
}
