using System;
using System.ComponentModel.DataAnnotations;

namespace HR.Core.Enums
{
    public enum AcademicTitleType 
    {
        [Display(Name="Inżynier")]
        Inzynier = 1,

        [Display(Name = "Magister")]
        Magister = 2,

        [Display(Name = "Doktor")]
        Doktor = 4
    }
}
