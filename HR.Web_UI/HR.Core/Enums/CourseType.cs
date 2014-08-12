using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Core.Enums
{
    [Flags]
    public enum CourseType:byte
    {
        UmiejetnosciMiekie=1,
        BezpieczenstwoWAplikacjachWebowych=2,
        Administracja=4
    }
}
