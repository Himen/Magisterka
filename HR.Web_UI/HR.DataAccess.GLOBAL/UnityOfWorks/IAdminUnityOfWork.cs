using System;
namespace HR.DataAccess.GLOBAL.UnityOfWorks
{

    public interface IAdminUnityOfWork<TRepo, TRepo1, TUnityOfWork>
    {
        TUnityOfWork UnityOfWork { get; set; }
        TRepo AccountRepo { get; set; }
        TRepo1 PersonRepo { get; set; }
    }
}
