﻿using HR.Core.Models.RepoModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class CourseMaterialMapper: EntityTypeConfiguration<CourseMaterial>
    {
        public CourseMaterialMapper ()
	    {
            this.ToTable("CourseMaterials",schemaName:"REPO");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("uniqueidentifier").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c=>c.Name).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            this.Property(c => c.CourseType).HasColumnType("int").IsRequired();

            this.Property(c => c.Document).HasColumnType("image").IsRequired();

            this.Property(c => c.DocumentName).HasColumnType("varchar").HasMaxLength(200).IsRequired();

            this.Property(c => c.Description).HasColumnType("varchar").HasMaxLength(2000).IsOptional();

            this.Property(c => c.PersonId).HasColumnType("bigint").IsOptional();

            this.HasOptional(c => c.Person).WithMany(c => c.CourseMaterials).HasForeignKey(c => c.PersonId).WillCascadeOnDelete(true);
	    }
    }
}
