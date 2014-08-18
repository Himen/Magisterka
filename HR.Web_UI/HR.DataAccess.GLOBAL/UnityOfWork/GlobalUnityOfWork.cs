using HR.Core.BasicContract;
using HR.Core.Models;
using HR.DataAccess.EF;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.GLOBAL.UnityOfWork
{
    /// <summary>
    /// to powinna byc warstwa dostepowa jednego z konkretnych repozytoriow tj. NH i EF, itd.
    /// I po tym powinny dziedziczyc konkretne rozwiazania UnityOfWork. Np. AdminUnityOfWork - odpowiedzialne za zarzadzanie kontem
    /// </summary>
    public class GlobalUnityOfWork: GlobalUnityOfWorkBase<ISession, ITransaction, HR_DataContext>
    {
    }
}
