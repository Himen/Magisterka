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

            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c=>c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c => c.UserName).HasColumnType("varchar").HasMaxLength(40).IsRequired();

            this.Property(c => c.Password).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            
            this.Property(c => c.AccountType).IsRequired();

            this.Property(c=>c.Photo).HasColumnType("image").IsOptional();

            this.Property(c => c.PersonId).HasColumnType("bigint");

            //this.HasRequired(c => c.Person).WithRequiredDependent(c=>c.Account);

            //this.HasRequired(c => c.Person).WithMany().HasForeignKey(c=>c.PersonId).WillCascadeOnDelete();
            
        }
    }
}
