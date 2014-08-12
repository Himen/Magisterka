using System;

namespace HR.Core.BasicContract
{
    /// <summary>
    /// Dodac tu cos jeszcze
    /// </summary>
    public interface IUnityOfWork : IDisposable
    {
        void SaveChanges();
    }
}
