using HR.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
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

            this.HasKey(c=>c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint");

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date");

            this.Property(c => c.FirstName);

            this.Property(c => c.Surname);

            this.Property(c => c.IDCard);

            this.Property(c => c.NIP);// jakos dodac.HasMaxLength(50);

            this.Property(c => c.PESEL);

            this.Property(c => c.DateOfBirth);

            this.Property(c => c.Profession);

            this.Property(c=>c.ApartmentNumber);

            this.Property(c => c.BuildingNumber);

            this.Property(c => c.City);

            this.Property(c => c.PostalCode);

            this.Property(c => c.DataState);

            this.HasMany<College>(c => c.Colleges).WithRequired(c => c.Person).HasForeignKey(c => c.IdPerson);

        }
    }
}
