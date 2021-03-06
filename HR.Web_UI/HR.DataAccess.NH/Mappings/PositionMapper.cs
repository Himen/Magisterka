﻿using FluentNHibernate.Mapping;
using HR.Core.Models.DictionaryModels;

namespace HR.DataAccess.NH.Mappings
{
    public class PositionMapper: ClassMap<Position>
    {
        public PositionMapper()
        {
            Table("Positions");
            //Schema("DIC");

            Id(c => c.Id).CustomSqlType("varchar").Length(10);
            Map(c => c.DataState).CustomSqlType("tinyint");
            Map(c => c.CreateDate).CustomSqlType("date");
            Map(c => c.EditDate).CustomSqlType("date").Nullable();

            Map(c => c.Name).CustomSqlType("varchar").Length(100);

        }
    }
}
