using HR.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class AdditionalInformationMapper:EntityTypeConfiguration<AdditionalInformation>
    {
        public AdditionalInformationMapper()
        {
            this.ToTable("AdditionalInformations");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c => c.FacebookAccount).HasColumnType("varchar").HasMaxLength(100).IsOptional();

            this.Property(c => c.GoogleAccount).HasColumnType("varchar").HasMaxLength(100).IsOptional();

            this.Property(c => c.TwitterAccount).HasColumnType("varchar").HasMaxLength(100).IsOptional();

            this.Property(c => c.GoldenLineAccount).HasColumnType("varchar").HasMaxLength(100).IsOptional();

            this.Property(c => c.LinkInAccount).HasColumnType("varchar").HasMaxLength(100).IsOptional();

            this.Property(c => c.PersonId).HasColumnType("bigint");

#warning Person
        }
    }
}
