using HR.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class WorkRegistryMapper: EntityTypeConfiguration<WorkRegistry>
    {
        public WorkRegistryMapper()
        {
            this.ToTable("WorkRegistrys");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c => c.Date).HasColumnType("date").IsRequired();

            this.Property(c => c.DateIn).HasColumnType("time").IsOptional();

            this.Property(c => c.DateOut).HasColumnType("time").IsOptional();

            this.Property(c => c.PersonId).HasColumnType("bigint").IsOptional();

            this.HasRequired(c => c.Person).WithMany(c => c.WorkRegistrys).HasForeignKey(c => c.PersonId).WillCascadeOnDelete(true);
        }
    }
}
