using HR.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class ContactPersonMapper: EntityTypeConfiguration<ContactPerson>
    {
        public ContactPersonMapper()
        {
            this.ToTable("ContactPersons");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("bigint").IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c => c.FirstName).HasColumnType("varchar").HasMaxLength(60).IsRequired();

            this.Property(c => c.Surname).HasColumnType("varchar").HasMaxLength(60).IsRequired();

            this.Property(c => c.City).HasColumnType("varchar").HasMaxLength(60).IsRequired();

            this.Property(c => c.Street).HasColumnType("varchar").HasMaxLength(60).IsRequired();

            this.Property(c => c.BuildingNumber).HasColumnType("int").IsRequired();

            this.Property(c => c.ApartmentNumber).HasColumnType("int").IsOptional();

            this.Property(c => c.PostalCode).HasColumnType("varchar").HasMaxLength(10).IsRequired();

            this.Property(c => c.Phone).HasColumnType("numeric").IsRequired();

            this.Property(c => c.Email).HasColumnType("varchar").HasMaxLength(60).IsRequired();

            this.HasRequired(c => c.Person).WithOptional(c => c.ContactPerson).Map(c => c.MapKey("PersonId")).WillCascadeOnDelete(true);
        }
    }
}
