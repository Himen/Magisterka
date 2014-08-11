using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Core.Enums
{
    [Flags]
    public enum ProfesionType: byte
    {
        Programista_ASP_NET_MVC=1,
        CEO= 2,
        Human_Resource,
        Programista_Java,
        Programista_Cpp
    }
}
