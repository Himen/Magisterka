﻿using HR.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class CourseMaterialMapper: EntityTypeConfiguration<CourseMaterial>
    {
        public CourseMaterialMapper ()
	    {
            this.ToTable("CourseMaterialMapping");

            this.HasKey(c=>c.Id);
            this.Property(c => c.Id).IsRequired();
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c=>c.Name);

            this.Property(c => c.TypeOfCourse);

            this.Property(c => c.Description);

            this.HasOptional(c => c.Document).WithRequired(c => c.CourseMaterial);//spr czy potrzebne
	    }
    }
}