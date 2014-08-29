using FluentNHibernate.Mapping;
using HR.Core.Models.RepoModels;

namespace HR.DataAccess.NH.Mappings
{
    public class VacationDocumentMapper: ClassMap<VacationDocument>
    {
        public VacationDocumentMapper()
        {
            Table("VacationDocuments");
            //Schema("REPO");

            Id(c => c.Id).GeneratedBy.GuidComb().CustomSqlType("uniqueidentifier");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.Name).CustomSqlType("varchar").Length(100);
            Map(c => c.Type).CustomSqlType("varchar").Length(30);
            Map(c => c.Content).CustomSqlType("binary");
            Map(c => c.Description).CustomSqlType("varchar").Length(1000).Nullable();

        }
    }
}
