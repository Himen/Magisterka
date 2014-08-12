using HR.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class CollageMapper : EntityTypeConfiguration<College>
    {
        /// <summary>
        /// zamienic na commuted i na sekwencje
        /// </summary>
        public CollageMapper()
        {
            this.ToTable("Collage");

            this.HasKey(c=>c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).IsRequired();

            this.Property(c=>c.IdPerson);

            this.Property(c=>c.Name);

            this.Property(c => c.Progres);

            this.Property(c => c.StartDate);

            this.Property(c => c.EndDate);

            this.Property(c => c.TitleOfResearch);

            this.Property(c => c.FieldOfStudy);

            this.Property(c => c.AcademicTitle);

            this.HasRequired<Person>(c => c.Person).WithMany(c => c.Colleges).HasForeignKey(c => c.IdPerson);
        }
    }
}
