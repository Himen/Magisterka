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

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c => c.PositionCode).HasColumnType("varchar").HasMaxLength(10).IsRequired();

            this.Property(c => c.OrganiziationalUnitCode).HasColumnType("varchar").HasMaxLength(10).IsRequired();

            this.Property(c => c.StartDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EndDate).HasColumnType("date").IsOptional();

            this.Property(c => c.PersonId).HasColumnType("bigint");


            this.Property(c => c.ContractId).HasColumnType("bigint");


            this.Property(c => c.BankAccountId).HasColumnType("bigint");

#warning All

        }
    }
}
