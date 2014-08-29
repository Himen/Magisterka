using FluentNHibernate.Mapping;
using HR.Core.Models;

namespace HR.DataAccess.NH.Mappings
{
    public class ContractMapper:ClassMap<Contract>
    {
        public ContractMapper()
        {
            Table("Contracts");

            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.StartDate).CustomSqlType("date");
            Map(c => c.EndDate).CustomSqlType("date");
            Map(c => c.ContractType).CustomType<int>().CustomSqlType("int");
            Map(c => c.ContractDimension).CustomType<int>().CustomSqlType("int");
            Map(c => c.BenefitPerHour).CustomSqlType("float").Nullable();
            Map(c => c.MonthBenefit).CustomSqlType("float").Nullable();

        }
    }
}
