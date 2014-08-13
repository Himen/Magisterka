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

            this.HasKey(c=>c.Id);
            this.Property(c => c.Id).IsRequired();
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.IdManager);

            this.Property(c => c.Name);

            this.HasRequired(c => c.Manager).WithRequiredPrincipal(); //sprawdzic to czy to bedzie dobrze dzialac, ze nie wymaga klasy w person
        }
    }
}
