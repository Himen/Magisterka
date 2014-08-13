using FluentNHibernate.Mapping;
using HR.Core.Models;
namespace HR.DataAccess.NH.Mappings
{
    public class AccountMapper: ClassMap<Account>
    {
        public AccountMapper()
        {
            Table("Accounts");
            Id(c => c.Id).GeneratedBy.Identity();
            Map(c => c.Password).CustomSqlType("nvarchar(30)");
            Map(c=>c.Photo);
            Map(c=>c.UserName);
            Map(c=>c.AccountType);
            Map(c=>c.DataState);
        }
    }
}
