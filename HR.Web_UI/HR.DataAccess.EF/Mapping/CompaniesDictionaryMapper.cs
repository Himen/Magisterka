﻿using HR.Core.Models.DictionaryModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class CompaniesDictionaryMapper:EntityTypeConfiguration<CompaniesDictionary>
    {
        public CompaniesDictionaryMapper()
        {
            this.ToTable("Companies", schemaName: "DIC");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c => c.Name).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            this.Property(c => c.Country).HasColumnType("varchar").HasMaxLength(50).IsRequired();

            this.Property(c => c.Address).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            this.Property(c => c.About).HasColumnType("varchar").HasMaxLength(300).IsRequired(); ;
        }
    }
}
