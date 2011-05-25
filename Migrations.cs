using System.Data;
using WeatherDotCom.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace WeatherDotCom {
    public class Migrations : DataMigrationImpl {

        public int Create()
        {
            // Creating table WeatherPartRecord
            SchemaBuilder.CreateTable("WeatherPartRecord", table => table
                                                                    .ContentPartRecord()
                                                                    .Column("webServiceUrl", DbType.String)
                                                                    .Column("searchString", DbType.String)
                                                                    .Column("partnerId", DbType.String)
                                                                    .Column("licenseKey", DbType.String)
                                                                    .Column("minutesToCache", DbType.Int32)
                );

            ContentDefinitionManager.AlterPartDefinition(typeof(WeatherPart).Name, cfg => cfg.Attachable());

            ContentDefinitionManager.AlterTypeDefinition("WeatherPartRecord", cfg => cfg
                .WithPart("WeatherPart")
                .WithPart("WidgetPart")
                .WithPart("CommonPart")
                .WithSetting("Stereotype", "Widget"));

            return 1;
        }
    }
}