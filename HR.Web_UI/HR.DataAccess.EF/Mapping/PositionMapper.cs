using HR.Core.Models.DictionaryModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.DataAccess.EF.Mapping
{
    public class PositionMapper: EntityTypeConfiguration<Position>
    {
        public PositionMapper()
        {
            this.ToTable("Positions",schemaName:"DIC");

            this.HasKey(c => c.Id);
            //this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).HasColumnType("varchar").HasMaxLength(10).IsRequired();

            this.Property(c => c.DataState).HasColumnType("tinyint").IsRequired();

            this.Property(c => c.CreateDate).HasColumnType("date").IsRequired();

            this.Property(c => c.EditDate).HasColumnType("date").IsOptional();

            this.Property(c=>c.Name).HasColumnType("varchar").HasMaxLength(100).IsRequired();

        }
    }
}
