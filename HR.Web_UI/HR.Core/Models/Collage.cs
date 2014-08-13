using HR.Core.BasicContract;
using HR.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Core.Models
{
    public class College:BaseEntity<long>
    {
        public long IdPerson { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Specializacja
        /// </summary>
        public string FieldOfStudy { get; set; }
        public AcademicTitleType AcademicTitle { get; set; }

        /// <summary>
        /// Tytul pracy dyplomowej
        /// </summary>
        public string TitleOfResearch { get; set; }
        public string Progres { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual Person Person { get; set; }
    }
}
