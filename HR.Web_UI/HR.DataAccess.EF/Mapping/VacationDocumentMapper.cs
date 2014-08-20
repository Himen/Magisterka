using HR.Core.Models.RepoModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
namespace HR.DataAccess.EF.Mapping
{
    public class VacationDocumentMapper:EntityTypeConfiguration<VacationDocument>
    {
        public VacationDocumentMapper()
        {
            this.ToTable("VacationDocuments", schemaName: "REPO");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("uniqueidentifier").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c => c.Name).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            this.Property(c => c.Type).HasColumnType("varchar").HasMaxLength(30).IsRequired();

            this.Property(c => c.Content).HasColumnType("binary").IsRequired();

            this.Property(c => c.Description).HasColumnType("varchar").HasMaxLength(1000).IsOptional();

        }
    }
}
