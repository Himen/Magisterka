using HR.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class AccountLogMapper: EntityTypeConfiguration<AccountLog>
    {
        public AccountLogMapper()
        {
            this.ToTable("AccountLogs",schemaName:"LOG");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c => c.Action).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            this.Property(c => c.ActionType).HasColumnType("int").IsRequired();

            this.Property(c => c.ActionDescription).HasColumnType("varchar").HasMaxLength(100).IsOptional();

            this.Property(c => c.StartDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EndDate).HasColumnType("date").IsRequired();

            this.Property(c => c.AccountId).HasColumnType("bigint").IsRequired();

            this.HasRequired(c => c.Account).WithRequiredDependent();
#warning Account
        }
    }
}
