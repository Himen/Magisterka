﻿using HR.Core.Models.RepoModels;
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

            this.Property(c => c.Title).HasColumnType("varchar").HasMaxLength(500).IsRequired();

            this.Property(c => c.Content).HasColumnType("varchar").HasMaxLength(2000).IsRequired();

            this.Property(c => c.Photo).HasColumnType("image").IsOptional();

            this.Property(c => c.PhotoTitle).HasColumnType("varchar").HasMaxLength(500).IsRequired();

            this.Property(c => c.PersonId).HasColumnType("bigint").IsOptional();

            this.HasRequired(c => c.Person).WithMany(c => c.PromotialMaterials).HasForeignKey(c => c.PersonId).WillCascadeOnDelete(true);

        }
    }
}
