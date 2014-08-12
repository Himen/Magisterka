using System;
using System.ComponentModel.DataAnnotations;

namespace HR.Core.Enums
{
    [Flags]
    public enum AcademicTitleType : byte
    {
        [Display(Name="Inżynier")]
        Inzynier = 1,

        [Display(Name = "Magister")]
        Magister = 2,

        [Display(Name = "Doktor")]
        Doktor = 4
    }
}
