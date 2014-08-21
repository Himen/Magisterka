using HR.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
namespace HR.DataAccess.EF.Mapping
{
    public class ContractMapper : EntityTypeConfiguration<Contract>
    {
        public ContractMapper()
        {
            this.ToTable("Contracts");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c => c.StartDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EndDate).HasColumnType("date").IsRequired();

            this.Property(c => c.ContractType).HasColumnType("int").IsRequired();

            this.Property(c => c.ContractDimension).HasColumnType("int").IsRequired();

            this.Property(c => c.BenefitPerHour).HasColumnType("float").IsOptional();

            this.Property(c => c.MonthBenefit).HasColumnType("float").IsOptional();

        }
    }
}
