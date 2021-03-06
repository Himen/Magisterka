﻿using HR.Core.Models;
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

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c=>c.CompanyName).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            this.Property(c => c.Position).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            this.Property(c => c.StartDate).HasColumnType("date").IsRequired(); ;

            this.Property(c => c.EndDate).HasColumnType("date").IsOptional(); ;

            this.Property(c => c.Description).HasColumnType("varchar").HasMaxLength(300).IsOptional();

            this.Property(c => c.PersonId).HasColumnType("bigint").IsOptional();

            this.HasRequired(c => c.Person).WithMany(c => c.Jobs).HasForeignKey(c => c.PersonId).WillCascadeOnDelete(true);
        }
    }
}
