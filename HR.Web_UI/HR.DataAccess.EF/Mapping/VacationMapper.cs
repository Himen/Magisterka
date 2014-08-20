using HR.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class VacationMapper : EntityTypeConfiguration<Vacation>
    {
        public VacationMapper()
        {
            this.ToTable("Vacations");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c => c.StartDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EndDate).HasColumnType("date").IsRequired();

            this.Property(c => c.VacationType).HasColumnType("int").IsRequired();

            this.Property(c => c.VacationAcceptation).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.Description).HasColumnType("varchar").HasMaxLength(300).IsOptional();

            this.Property(c => c.PersonId).HasColumnType("bigint").IsOptional();

#warning sprawdzic czy uniqueidentifier jest poprawny
            this.Property(c => c.VacationDocumentId).HasColumnType("uniqueidentifier").IsOptional();
#warning mapowanie do person i VacationDocument dodac
        }
    }
}
