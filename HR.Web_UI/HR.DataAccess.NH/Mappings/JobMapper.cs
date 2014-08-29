using FluentNHibernate.Mapping;
using HR.Core.Models;

namespace HR.DataAccess.NH.Mappings
{
    public class JobMapper:ClassMap<Job>
    {
        public JobMapper()
        {
            Table("Jobs");

            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.CompanyName).CustomSqlType("varchar").Length(100);
            Map(c => c.Position).CustomSqlType("varchar").Length(100);
            Map(c => c.StartDate).CustomSqlType("date");
            Map(c => c.EndDate).CustomSqlType("date").Nullable();
            Map(c => c.Description).CustomSqlType("varchar").Length(300).Nullable();

            //Map(c => c.PersonId).CustomSqlType("bigint").Nullable();

            //Person
            References(c => c.Person);


        }
    }
}
