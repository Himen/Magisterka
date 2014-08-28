using HR.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class TraningMapper:EntityTypeConfiguration<Training>
    {
        public TraningMapper()
        {
            this.ToTable("Tranings");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c => c.Name).HasColumnType("varchar").HasMaxLength(90).IsRequired();

            this.Property(c => c.Type).HasColumnType("int").IsRequired();

            this.Property(c => c.DateOfPass).HasColumnType("date").IsRequired();

            this.Property(c => c.Description).HasColumnType("varchar").HasMaxLength(600).IsRequired();

            this.Property(c => c.PersonId).HasColumnType("bigint").IsOptional();

            this.HasRequired(c => c.Person).WithMany(c => c.Trainings).HasForeignKey(c => c.PersonId).WillCascadeOnDelete(true);

        }
    }
}
