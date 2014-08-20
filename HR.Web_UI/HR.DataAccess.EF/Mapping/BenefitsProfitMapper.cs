using HR.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class BenefitsProfitMapper : EntityTypeConfiguration<BenefitsProfit>
    {
        public BenefitsProfitMapper()
        {
            this.ToTable("BenefitsProfits");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c => c.StartDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EndDate).HasColumnType("date").IsRequired();

            this.Property(c => c.BenefitBrutto).HasColumnType("decimal").HasPrecision(10,2).IsRequired();

            this.Property(c => c.BenefitNetto).HasColumnType("decimal").HasPrecision(10, 2).IsRequired(); ;

            this.Property(c => c.BenefitType).HasColumnType("int").IsRequired();

            this.Property(c => c.Retirement).HasColumnType("decimal").HasPrecision(10, 2).IsRequired(); ;

            this.Property(c => c.Disability).HasColumnType("decimal").HasPrecision(10, 2).IsRequired(); ;

            this.Property(c => c.Sikness).HasColumnType("decimal").HasPrecision(10, 2).IsRequired(); ;

            this.Property(c => c.Health).HasColumnType("decimal").HasPrecision(10, 2).IsRequired(); ;

            this.Property(c => c.Taxable).HasColumnType("decimal").HasPrecision(10, 2).IsRequired(); ;

            this.Property(c => c.AdvanceAt_PIT).HasColumnType("decimal").HasPrecision(10, 2).IsRequired(); ;

            this.Property(c => c.PersonId).IsOptional();
#warning perosn
        }
    }
}
