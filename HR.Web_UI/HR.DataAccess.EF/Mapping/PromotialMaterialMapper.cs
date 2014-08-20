using HR.Core.Models.RepoModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class PromotialMaterialMapper : EntityTypeConfiguration<PromotialMaterial>
    {
        public PromotialMaterialMapper()
        {
            this.ToTable("PromotialMaterials",schemaName: "REPO");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c => c.Title).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            this.Property(c => c.Content).HasColumnType("varchar").HasMaxLength(1000).IsRequired();

            this.Property(c => c.PersonId).HasColumnType("bigint").IsOptional();

        }
    }
}
