using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.GLOBAL.UnityOfWorks
{
    public interface IHRUnityOfWork<TRepo, TRepo2, TUnityOfWork>
    {
        TUnityOfWork UnityOfWork { get; set; }
        TRepo PersonRepo { get; set; }
        TRepo2 AccountRepo { get; set; }
    }
}
