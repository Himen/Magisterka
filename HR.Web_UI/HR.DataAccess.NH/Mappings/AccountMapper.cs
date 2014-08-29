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
            Map(c => c.DataState).CustomSqlType("tinyint").Not.Nullable();
            Map(c => c.CreateDate).CustomSqlType("date").Not.Nullable();
            Map(c => c.EditDate).CustomSqlType("date").Nullable();
            Map(c => c.UserName).CustomSqlType("varchar").Length(80).Unique();
            Map(c => c.Password).CustomSqlType("varchar").Length(20).Not.Nullable();
            Map(c => c.AccountType).CustomType<int>().CustomSqlType("smallint").Not.Nullable();
            Map(c=>c.Photo).CustomSqlType("image").Nullable();

            //dowiedziec jak sie klucz mapuje
            //HasMany(c => c.AccountLogs).KeyColumn("AccountId").Cascade.Delete();

            
            //powinno wystarczyc
            References(c => c.Person);
        }
    }
}
