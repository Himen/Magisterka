using FluentNHibernate.Mapping;
using HR.Core.Models;

namespace HR.DataAccess.NH.Mappings
{
    public class WorkRegistryMapper : ClassMap<WorkRegistry>
    {
        public WorkRegistryMapper()
        {
            Table("WorkRegistrys");

            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.Date).CustomSqlType("date");
            Map(c => c.DateOut).CustomSqlType("time").Nullable();
            Map(c => c.DateIn).CustomSqlType("time").Nullable();

            //Map(c => c.PersonId).CustomSqlType("bigint");

            References(c => c.Person);//.ForeignKey("PersonId").Cascade.Delete();
        }
    }
}
