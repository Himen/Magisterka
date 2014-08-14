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

            this.HasKey(c=>c.Id);
            this.Property(c => c.Id).IsRequired();
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.DataState).HasColumnType("tinyint");

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date");

            this.Property(c => c.Benefit);

            this.Property(c => c.BenefitType);

            this.Property(c => c.StartDate);

            this.Property(c => c.EndDate);

            this.Property(c => c.IdEmployment);

            //tu nie ma mapowania na employment bo jest nie potrzebne
        }
    }
}
