using FluentNHibernate.Mapping;
using HR.Core.Models;

namespace HR.DataAccess.NH.Mappings
{
    public class AdditionalInformationMapper: ClassMap<AdditionalInformation>
    {
        public AdditionalInformationMapper()
        {
            Table("AdditionalInformation");
            Id(c => c.Id).GeneratedBy.Identity().CustomSqlType("bigint");
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.FacebookAccount).CustomSqlType("varchar").Length(100).Nullable();
            Map(c => c.GoogleAccount).CustomSqlType("varchar").Length(100).Nullable();
            Map(c => c.GoldenLineAccount).CustomSqlType("varchar").Length(100).Nullable();
            Map(c => c.TwitterAccount).CustomSqlType("varchar").Length(100).Nullable();
            Map(c => c.LinkInAccount).CustomSqlType("varchar").Length(100).Nullable();

            References(c => c.Person);
            //referencja do Person
        }
    }
}
