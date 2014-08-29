using FluentNHibernate.Mapping;
using HR.Core.Models;

namespace HR.DataAccess.NH.Mappings
{
    public class VacationMapper : ClassMap<Vacation>
    {
        public VacationMapper()
        {
            Table("Vacations");

            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.StartDate).CustomSqlType("date");
            Map(c => c.EndDate).CustomSqlType("date");
            Map(c => c.VacationType).CustomType<int>().CustomSqlType("int");
            Map(c => c.VacationAcceptation).CustomSqlType("tinyint");
            Map(c => c.Description).CustomSqlType("varchar").Length(300).Nullable();

            //Map(c => c.PersonId).CustomSqlType("bigint").Nullable();

            References(c => c.Person);//.ForeignKey("PersonId").Cascade.Delete();

            References(c => c.VacationDocument);//.ForeignKey("VacationDocumentId").Cascade.Delete();

        }
    }
}
