using FluentNHibernate.Mapping;
using HR.Core.Models;

namespace HR.DataAccess.NH.Mappings
{
    public class BenefitsProfitMapper: ClassMap<BenefitsProfit>
    {
        public BenefitsProfitMapper()
        {
            Table("BenefitsProfits");

            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.StartDate).CustomSqlType("date");
            Map(c => c.EndDate).CustomSqlType("date");
            Map(c => c.BenefitBrutto).CustomSqlType("float");
            Map(c => c.BenefitNetto).CustomSqlType("float");
            Map(c => c.BenefitType).CustomType<int>().CustomSqlType("int");
            Map(c => c.Retirement).CustomSqlType("float");
            Map(c => c.Disability).CustomSqlType("float");
            Map(c => c.Sikness).CustomSqlType("float");
            Map(c => c.Health).CustomSqlType("float");
            Map(c => c.Taxable).CustomSqlType("float");
            Map(c => c.AdvanceAt_PIT).CustomSqlType("float");

            References(c => c.Person);
        }
    }
}
