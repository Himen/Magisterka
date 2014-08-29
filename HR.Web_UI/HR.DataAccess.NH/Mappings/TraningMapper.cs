using FluentNHibernate.Mapping;
using HR.Core.Models;

namespace HR.DataAccess.NH.Mappings
{
    public class TraningMapper:ClassMap<Training>
    {
        public TraningMapper()
        {
            Table("Tranings");

            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.Name).CustomSqlType("varchar").Length(90);
            Map(c => c.Type).CustomType<int>().CustomSqlType("int");
            Map(c => c.DateOfPass).CustomSqlType("date");
            Map(c => c.Description).CustomSqlType("varchar").Length(600);

            //Map(c => c.PersonId).CustomSqlType("bigint");

            References(c => c.Person);//.ForeignKey("PersonId").Cascade.Delete();
        }
    }
}
