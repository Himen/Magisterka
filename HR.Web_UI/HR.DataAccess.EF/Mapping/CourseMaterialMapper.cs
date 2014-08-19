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
            this.Property(c => c.Id).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c=>c.Name);

            this.Property(c => c.CourseType);

            this.Property(c => c.Document);

            this.Property(c => c.DocumentName);

            this.Property(c => c.Description);

            //poczytac o mapowaniu bo kurde nadmiarowe to jest
            //this.HasRequired(c=>c.Person).WithRequiredDependent(c=>c.Id,)
	    }
    }
}
