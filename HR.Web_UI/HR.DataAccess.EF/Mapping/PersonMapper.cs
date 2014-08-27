using HR.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class PersonMapper : EntityTypeConfiguration<Person>
    {
        /// <summary>
        /// dodac jeszcze varchat, length itd
        /// </summary>
        public PersonMapper()
        {
            this.ToTable("Persons");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("datetime2").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("datetime2").IsOptional();

            this.Property(c => c.FirstName).HasColumnType("varchar").HasMaxLength(50).IsRequired();

            this.Property(c => c.Surname).HasColumnType("varchar").HasMaxLength(50).IsRequired();

            this.Property(c => c.DateOfBirth).HasColumnType("date").IsRequired(); 

            this.Property(c => c.City).HasColumnType("varchar").HasMaxLength(50).IsRequired();

            this.Property(c => c.PostalCode).HasColumnType("varchar").HasMaxLength(10).IsRequired();

            this.Property(c => c.Street).HasColumnType("varchar").HasMaxLength(50).IsRequired(); 

            this.Property(c => c.BuildingNumber).HasColumnType("int").IsRequired();

            this.Property(c => c.ApartmentNumber).HasColumnType("int").IsOptional(); 

            this.Property(c => c.Phone).HasColumnType("numeric").IsRequired();

            this.Property(c => c.Email).HasColumnType("varchar").HasMaxLength(80).IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Email", 1) { IsUnique = true })); ;

            this.Property(c => c.NIP).HasColumnType("numeric").IsRequired();

            this.Property(c => c.IDCard).HasColumnType("varchar").HasMaxLength(10).IsRequired();

            this.Property(c => c.PESEL).HasColumnType("varchar").HasMaxLength(11).IsRequired();

            this.Property(c=>c.ManagerId).HasColumnType("bigint").IsOptional();

            this.HasOptional(c => c.Manager).WithMany().HasForeignKey(c=>c.ManagerId);

            //this.Property(c => c.ContactPersonId).HasColumnType("bigint").IsOptional();;
            

            

        }
    }
}
