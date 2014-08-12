using HR.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
namespace HR.DataAccess.EF.Mapping
{
    public class ContractMapper : EntityTypeConfiguration<Contract>
    {
        public ContractMapper()
        {
            this.ToTable("Contract");

            this.HasKey(c=>c.Id);
            this.Property(c => c.Id).IsRequired();
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c=>c.IdEmployment);

            this.Property(c => c.DataState);

            this.Property(c => c.BenefitPerHour);

            this.Property(c => c.MonthBenefit);

            this.HasRequired<Employment>(c => c.Employment).WithRequiredDependent(c=>c.Contract);
        }
    }
}
