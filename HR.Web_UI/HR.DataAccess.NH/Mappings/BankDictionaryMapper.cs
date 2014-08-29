using FluentNHibernate.Mapping;
using HR.Core.Models.DictionaryModels;

namespace HR.DataAccess.NH.Mappings
{
    public class BankDictionaryMapper : ClassMap<BankDictionary>
    {
        public BankDictionaryMapper()
        {
            Table("Banks");
            //Schema("DIC");

            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.Name).CustomSqlType("varchar").Length(100);
            Map(c => c.Address).CustomSqlType("varchar").Length(100);
        }
    }
}
