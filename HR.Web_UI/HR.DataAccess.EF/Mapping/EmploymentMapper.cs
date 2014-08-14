using HR.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class EmploymentMapper : EntityTypeConfiguration<Employment>
    {
        public EmploymentMapper()
        {
            this.ToTable("Employments");

            this.HasKey(c=>c.Id);
            this.Property(c => c.Id).IsRequired();
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.DataState).HasColumnType("tinyint");

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date");

            this.Property(c=>c.IdPerson);

            this.Property(c => c.OrganiziationalUnitCode);

            this.Property(c => c.PositionCode);

            this.Property(c => c.StartDate);

            this.Property(c => c.EndDate);

            this.Property(c => c.EmploymentType);

            this.Property(c => c.ContractDimmension);

            this.HasRequired(c => c.Contract).WithRequiredDependent(c=>c.Employment);

            this.HasRequired(c => c.BenefitsProfit).WithRequiredDependent(c => c.Employment);
        }
    }
}
