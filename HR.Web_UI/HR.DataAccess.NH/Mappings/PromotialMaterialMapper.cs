using FluentNHibernate.Mapping;
using HR.Core.Models.RepoModels;

namespace HR.DataAccess.NH.Mappings
{
    public class PromotialMaterialMapper : ClassMap<PromotialMaterial>
    {
        public PromotialMaterialMapper()
        {
            Table("PromotialMaterials");
            //Schema("REPO");

            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint"); 
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.Title).CustomSqlType("varchar").Length(100);
            Map(c => c.Content).CustomSqlType("varchar").Length(1000);

            //Map(c => c.PersonId).CustomSqlType("bigint");
            References(c => c.Person);//.ForeignKey("PersonId").Cascade.Delete();

        }
    }
}
