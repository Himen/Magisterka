using FluentNHibernate.Mapping;
using HR.Core.Models;

namespace HR.DataAccess.NH.Mappings
{
    public class DelegationMapper: ClassMap<Delegation>
    {
        public DelegationMapper()
        {
            Table("Delegations");

            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.Name).CustomSqlType("varchar").Length(100);
            Map(c => c.Description).CustomSqlType("varchar").Length(300).Nullable();
            Map(c => c.StartDate).CustomSqlType("date");
            Map(c => c.EndDate).CustomSqlType("date");

            //do sprawdzenia
            References(c => c.Person);//.ForeignKey("PersonId").Cascade.Delete().Nullable();
        }
    }
}
