using HR.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class JobMapper:EntityTypeConfiguration<Job>
    {
        public JobMapper()
        {
            this.ToTable("Jobs");

            this.HasKey(c=>c.Id);
            this.Property(c => c.Id).IsRequired();
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c=>c.CompanyName);

            this.Property(c=>c.DataState);

            this.Property(c => c.Description);

            this.Property(c => c.EndDate);

            this.Property(c => c.Position);

            this.Property(c => c.StartDate);

        }
    }
}
