using FluentNHibernate.Mapping;
using HR.Core.Models;

namespace HR.DataAccess.NH.Mappings
{
    public class EmploymentMapper:ClassMap<Employment>
    {
        public EmploymentMapper()
        {
            Table("Employments");

            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.PositionCode).CustomSqlType("varchar").Length(10);
            Map(c => c.OrganiziationalUnitCode).CustomSqlType("varchar").Length(10);
            Map(c => c.EmploymentType).CustomType<int>().CustomSqlType("int");
            Map(c => c.StartDate).CustomSqlType("date");
            Map(c => c.EndDate).CustomSqlType("date").Nullable();

            References(c => c.Person);//.ForeignKey("PersonId").Cascade.Delete();

            References(c => c.Contract);//.ForeignKey("ContractId").Cascade.Delete();

            References(c => c.BankAccount);//.ForeignKey("BankAccountId").Cascade.Delete();
        }
    }
}
