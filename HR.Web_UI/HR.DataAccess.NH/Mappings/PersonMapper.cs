using FluentNHibernate.Mapping;
using HR.Core.Models;

namespace HR.DataAccess.NH.Mappings
{
    public class PersonMapper : ClassMap<Person>
    {
        public PersonMapper()
        {
            Table("Persons");

            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.FirstName).CustomSqlType("varchar").Length(50);
            Map(c => c.Surname).CustomSqlType("varchar").Length(50);
            Map(c => c.DateOfBirth).CustomSqlType("date");
            Map(c => c.City).CustomSqlType("varchar").Length(50);
            Map(c => c.PostalCode).CustomSqlType("varchar").Length(10);
            Map(c => c.Street).CustomSqlType("varchar").Length(50);
            Map(c => c.BuildingNumber).CustomSqlType("int");
            Map(c => c.ApartmentNumber).CustomSqlType("int").Nullable();
            Map(c => c.Phone).CustomSqlType("numeric").Length(10);
            Map(c => c.Email).CustomSqlType("varchar").Length(80).Unique();
            Map(c => c.NIP).CustomSqlType("numeric").Length(11);
            Map(c => c.IDCard).CustomSqlType("varchar").Length(10);
            Map(c => c.PESEL).CustomSqlType("varchar").Length(11);//tez powinno byc uniq

            References(c => c.Manager).ForeignKey("ManagerId").Cascade.Delete();
        }
    }
}
