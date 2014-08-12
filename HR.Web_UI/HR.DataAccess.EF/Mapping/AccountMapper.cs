using HR.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class AccountMapper : EntityTypeConfiguration<Account>
    {
        public AccountMapper()
        {
            this.ToTable("Accounts");

            this.HasKey(c=>c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).IsRequired();

            this.Property(c => c.UserName).IsRequired();
            this.Property(c => c.Password).IsRequired();
            this.Property(c=>c.DataState);
            this.Property(c => c.AccountType).IsRequired();
            this.Property(c=>c.Photo).HasColumnType("image");
            
        }
    }
}
