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
            /*Map(c => c.PersonId);
            Map(c => c.BankAccountId);
            Map(c => c.ContractId);*/

            

            HasOne(c => c.Contract).ForeignKey("Id").Cascade.Delete();

            HasOne(c => c.BankAccount).ForeignKey("Id").Cascade.Delete();
        }
    }
}
