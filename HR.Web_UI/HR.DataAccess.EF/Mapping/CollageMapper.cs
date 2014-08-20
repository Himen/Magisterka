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
            this.ToTable("Collages");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c=>c.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();

            this.Property(c => c.FieldOfStudy).HasColumnType("varchar").HasMaxLength(30).IsRequired(); 

            this.Property(c => c.Specialization).HasColumnType("varchar").HasMaxLength(40).IsRequired(); 

            this.Property(c => c.AcademicTitle).HasColumnType("int").IsRequired();

            this.Property(c => c.TitleOfResearch).HasColumnType("varchar").HasMaxLength(60).IsRequired();

            this.Property(c => c.Progres).HasColumnType("int").IsRequired(); 

            this.Property(c => c.StartDate).HasColumnType("date").IsRequired(); 

            this.Property(c => c.EndDate).HasColumnType("date").IsOptional();

            this.Property(c => c.PersonId).HasColumnType("bigint").IsOptional();

#warning //this.HasRequired<Person>(c => c.Person).WithMany(c => c.Colleges).HasForeignKey(c => c.IdPerson);
        }
    }
}
