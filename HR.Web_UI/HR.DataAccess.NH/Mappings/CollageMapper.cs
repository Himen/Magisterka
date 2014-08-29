using FluentNHibernate.Mapping;
using HR.Core.Models;

namespace HR.DataAccess.NH.Mappings
{
    public class CollageMapper: ClassMap<College>
    {
        public CollageMapper()
        {
            Table("Collages");

            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.Name).CustomSqlType("varchar").Length(50);
            Map(c => c.FieldOfStudy).CustomSqlType("varchar").Length(30);
            Map(c => c.Specialization).CustomSqlType("varchar").Length(40);
            Map(c => c.AcademicTitle).CustomType<int>().CustomSqlType("int");
            Map(c => c.TitleOfResearch).CustomSqlType("varchar").Length(60);
            Map(c => c.Progres).CustomType<int>().CustomSqlType("int");
            Map(c => c.StartDate).CustomSqlType("date");
            Map(c => c.EndDate).CustomSqlType("date").Nullable();

            //Map(c => c.PersonId).Nullable();

            //Referecnaja do Person
            References(c => c.Person);
        }
    }
}
