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

            this.Property(c => c.BenefitBrutto).HasColumnType("float").IsRequired();

            this.Property(c => c.BenefitNetto).HasColumnType("float").IsRequired(); ;

            this.Property(c => c.BenefitType).HasColumnType("int").IsRequired();

            this.Property(c => c.Retirement).HasColumnType("float").IsRequired(); ;

            this.Property(c => c.Disability).HasColumnType("float").IsRequired(); ;

            this.Property(c => c.Sikness).HasColumnType("float").IsRequired(); ;

            this.Property(c => c.Health).HasColumnType("float").IsRequired(); ;

            this.Property(c => c.Taxable).HasColumnType("float").IsRequired(); ;

            this.Property(c => c.AdvanceAt_PIT).HasColumnType("float").IsRequired(); ;

            this.Property(c => c.PersonId).IsOptional();

            this.HasRequired(p => p.Person).WithMany(c => c.BenefitsProfits).HasForeignKey(c => c.PersonId).WillCascadeOnDelete(true);

        }
    }
}
