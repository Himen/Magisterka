using FluentNHibernate.Mapping;
using HR.Core.Models;

namespace HR.DataAccess.NH.Mappings
{
    public class ContactPersonMapper: ClassMap<ContactPerson>
    {
        public ContactPersonMapper()
        {
            Table("ContactPersons");

            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.FirstName).CustomSqlType("varchar").Length(60);
            Map(c => c.Surname).CustomSqlType("varchar").Length(60);
            Map(c => c.City).CustomSqlType("varchar").Length(60);
            Map(c => c.Street).CustomSqlType("varchar").Length(60);
            Map(c => c.BuildingNumber).CustomSqlType("int");
            Map(c => c.ApartmentNumber).CustomSqlType("int").Nullable();
            Map(c => c.PostalCode).CustomSqlType("varchar").Length(10);
            Map(c => c.Phone).CustomSqlType("numeric").Length(12);
            Map(c => c.Email).CustomSqlType("varchar").Length(60);

            //referencja do person
            References(c => c.Person);
        }
    }
}
