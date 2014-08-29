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
            Map(c => c.DataState).CustomSqlType("tinyint").Not.Nullable();
            Map(c => c.CreateDate).CustomSqlType("date").Not.Nullable();
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.FirstName).CustomSqlType("varchar").Length(50).Not.Nullable();
            Map(c => c.Surname).CustomSqlType("varchar").Length(50).Not.Nullable();
            Map(c => c.DateOfBirth).CustomSqlType("date").Not.Nullable();
            Map(c => c.City).CustomSqlType("varchar").Length(50).Not.Nullable();
            Map(c => c.PostalCode).CustomSqlType("varchar").Length(10).Not.Nullable();
            Map(c => c.Street).CustomSqlType("varchar").Length(50).Not.Nullable();
            Map(c => c.BuildingNumber).CustomSqlType("int").Not.Nullable();
            Map(c => c.ApartmentNumber).CustomSqlType("int").Nullable();
            Map(c => c.Phone).CustomSqlType("numeric").Length(10).Not.Nullable();
            Map(c => c.Email).CustomSqlType("varchar(80)").Length(80).Unique().Not.Nullable();
            Map(c => c.NIP).CustomSqlType("numeric").Length(11).Not.Nullable();
            Map(c => c.IDCard).CustomSqlType("varchar").Length(10).Not.Nullable();
            Map(c => c.PESEL).CustomType<string>().Length(11).Not.Nullable();//tez powinno byc uniq
#warning Problem z wielkoscia stringow taki zapis jest bledny  Map(c => c.Email).CustomSqlType("varchar").Length(80)
            References(c => c.Manager).ForeignKey("ManagerId").Cascade.Delete();
        }
    }
}
