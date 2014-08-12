using HR.Core.Models;
using HR.DataAccess.EF.Repositories;
using System;
namespace HR.DataAccess.EF.UnityOfWorks
{
    /// <summary>
    /// narazie nie uzywane ale poprawic to
    /// </summary>
    interface IUnityOfWork
    {
        Repository<Account> AccountRepository { get; }
        void Dispose();
        void Save();
    }
}
