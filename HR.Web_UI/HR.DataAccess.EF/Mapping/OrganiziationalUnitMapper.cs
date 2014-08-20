using HR.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class OrganiziationalUnitMapper : EntityTypeConfiguration<OrganiziationalUnit>
    {
        public OrganiziationalUnitMapper()
        {
            this.ToTable("OrganiziationalUnits");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("varchar").HasMaxLength(10).IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c => c.Name).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            this.Property(c => c.ManagerId).HasColumnType("bigint").IsOptional();

#warning do sprawdzenia
            //this.HasRequired(c => c.Manager).WithRequiredPrincipal(); //sprawdzic to czy to bedzie dobrze dzialac, ze nie wymaga klasy w person
        }
    }
}
