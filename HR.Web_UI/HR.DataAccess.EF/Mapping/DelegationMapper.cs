using HR.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class DelegationMapper: EntityTypeConfiguration<Delegation>
    {
        public DelegationMapper()
        {
            this.ToTable("Delegations");

            this.HasKey(c=>c.Id);
            this.Property(c => c.Id).IsRequired();
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.DataState).HasColumnType("tinyint");

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date");

            this.Property(c => c.Name);

            this.Property(c => c.DataState);

            this.Property(c=>c.StartDate);

            this.Property(c => c.EndDate);

            this.Property(c => c.Description);

            this.Property(c => c.IdPerson);

            this.HasRequired(c => c.Person).WithOptional(c => c.Delegation);
        }
    }
}
