﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.GLOBAL.UnityOfWorks
{
    public interface ILogUnityOfWork<TRepo, TRepo1, TUnityOfWork>
    {
        TUnityOfWork UnityOfWork { get; set; }
        TRepo AccountLogRepo { get; set; }
        TRepo1 AccountRepo { get; set; }
    }
}
