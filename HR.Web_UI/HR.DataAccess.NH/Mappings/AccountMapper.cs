using FluentNHibernate.Mapping;
using HR.Core.Models;

namespace HR.DataAccess.NH.Mappings
{
    public class AccountMapper: ClassMap<Account>
    {
        public AccountMapper()
        {
            Table("Accounts");
            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();
            Map(c => c.UserName).CustomSqlType("varchar").Length(80).Unique();
            Map(c => c.Password).CustomSqlType("varchar").Length(20);
            Map(c => c.AccountType).CustomType<int>().CustomSqlType("smallint");
            Map(c=>c.Photo).CustomSqlType("image").Nullable();

            HasMany<AccountLog>(c => c.AccountLogs).Cascade.AllDeleteOrphan();

            //powinno wystarczyc
            References(c=>c.Person)
        }
    }
}
