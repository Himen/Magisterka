using FluentNHibernate.Mapping;
using HR.Core.Models;

namespace HR.DataAccess.NH.Mappings
{
    public class AccountLogMapper : ClassMap<AccountLog>
    {
        public AccountLogMapper()
        {
            Table("AccountLogs");
            Schema("LOG");
            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();
            Map(c => c.Action).CustomSqlType("varchar").Length(100);
            Map(c => c.ActionType).CustomType<int>().CustomSqlType("smallint");
            Map(c => c.ActionDescription).CustomSqlType("varchar").Length(100).Nullable();
            Map(c => c.StartDate).CustomSqlType("date");
            Map(c => c.EndDate).CustomSqlType("date");

            //nhforge.org/blogs/nhibernate/archive/2008/09/06/a-fluent-interface-to-nhibernate-part-3-mapping-relations.aspx
            //References(c=>c.Account).
        }
    }
}
