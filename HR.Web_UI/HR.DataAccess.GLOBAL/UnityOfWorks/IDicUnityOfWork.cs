using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.GLOBAL.UnityOfWorks
{
    /// <summary>
    /// Unity of work zawierajace odwolanie do wszystkich slownikow
    /// </summary>
    public interface IDicUnityOfWork<TRepo,TRepo1,TRepo2,TRepo3, TUnityOfWork>
    {
        TUnityOfWork UnityOfWork { get; set; }
        TRepo BankRepo { get; set; }
        TRepo1 CollegesRepo { get; set; }
        TRepo2 CompaniesRepo { get; set; }
        TRepo3 PositionsRepo { get; set; }
    }
}
