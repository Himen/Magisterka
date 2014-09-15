using FluentNHibernate.Mapping;
using HR.Core.Models;

namespace HR.DataAccess.NH.Mappings
{
    public class BankAccountMapper: ClassMap<BankAccount>
    {
        public BankAccountMapper()
        {
            Table("BankAccounts");
            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.BankName).CustomSqlType("varchar").Length(100);
            Map(c => c.BankAddress).CustomSqlType("varchar").Length(100);
            Map(c => c.AccountNumber).CustomSqlType("varchar").Length(24);

            HasOne(c => c.Employment).ForeignKey("Id").Cascade.Delete();
        }
    }
}
