using HR.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class BankAccountMapper: EntityTypeConfiguration<BankAccount>
    {
        public BankAccountMapper()
        {
            this.ToTable("BankAccounts");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c => c.BankName).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            this.Property(c => c.BankAddress).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            this.Property(c => c.AccountNumber).HasColumnType("varchar").HasMaxLength(24).IsRequired();
        }
    }
}
