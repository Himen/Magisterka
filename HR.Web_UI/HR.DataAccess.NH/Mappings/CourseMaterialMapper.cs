using FluentNHibernate.Mapping;
using HR.Core.Models;
using HR.Core.Models.RepoModels;


namespace HR.DataAccess.NH.Mappings
{
    public class CourseMaterialMapper : ClassMap<CourseMaterial>
    {
        public CourseMaterialMapper()
        {
            Table("CourseMaterials");
            //Schema("REPO");

            Id(c => c.Id).GeneratedBy.GuidComb().CustomSqlType("uniqueidentifier");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.Name).CustomSqlType("varchar").Length(100);
            Map(c => c.CourseType).CustomType<int>().CustomSqlType("int");
            Map(c => c.Document).CustomSqlType("binary");
            Map(c => c.DocumentName).CustomSqlType("varchar").Length(200);
            Map(c => c.Description).CustomSqlType("varchar").Length(2000).Nullable();

            //Map(c => c.PersonId).CustomSqlType("bigint").Nullable();

            //do sprawdzenia
            References(c => c.Person);//.ForeignKey("PersonId").Cascade.Delete().Nullable();
        }
    }
}
