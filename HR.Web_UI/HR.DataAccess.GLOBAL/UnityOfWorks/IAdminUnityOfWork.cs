using System;
namespace HR.DataAccess.GLOBAL.UnityOfWorks
{

    public interface IAdminUnityOfWork<TRepo, TUnityOfWork>
    {
        TUnityOfWork UnityOfWork { get; set; }
        TRepo AccountRepo { get; set; }
    }
}
