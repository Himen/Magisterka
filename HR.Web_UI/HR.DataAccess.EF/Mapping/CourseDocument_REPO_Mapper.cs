using HR.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class CourseDocument_REPO_Mapper : EntityTypeConfiguration<CourseDocuments_REPO>
    {
        public CourseDocument_REPO_Mapper()
        {
            this.ToTable("REPO.CourseDocuments");

            this.HasKey(c=>c.Guid);
            this.Property(c => c.Guid).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();

            this.Property(c=>c.Content).IsRequired();

            this.Property(c=>c.FileName);

            this.Property(c=>c.FileType);

            this.Property(c=>c.CourseMaterialId);

            //this.HasRequired(c => c.CourseMaterial).WithRequiredDependent(c => c.Document);

        }
    }
}
