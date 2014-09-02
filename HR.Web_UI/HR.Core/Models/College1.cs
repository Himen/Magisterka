using HR.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Core.Models
{
    /// <summary>
    /// Przykad na mapowanie za pomocą atrybutów
    /// </summary>
    [Table("Collages",Schema="DIC")]
    public class College1
    {
        [Key]
        public long Id { get; set; }

        //public long IdPerson { get; set; }

        
        [MaxLength(30)]
        [Column("Name", TypeName = "NVARCHAR")]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("FieldOfStudy", TypeName = "NVARCHAR")]
        public string FieldOfStudy { get; set; }

        [Required]
        [Column("AcademicTitle", TypeName = "byte")]
        public AcademicTitleType AcademicTitle { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("TitleResearchSearch", TypeName = "NVARCHAR")]
        public string TitleResearchSearch { get; set; }

        [Required]
        [MaxLength(40)]
        [Column("Progres", TypeName = "NVARCHAR")]
        public string Progres { get; set; }

        [Required]
        [Column("StartDate", TypeName = "Date")]
        public DateTime StartDate { get; set; }

        [Column("EndDate", TypeName = "Date")]
        public DateTime? EndDate { get; set; }

        /*[ForeignKey("IdPerson")]
        public virtual Person Person { get; set; }*/

        [NotMapped]
        public int NotMapeddValueForTests { get; set; }
    }
}
