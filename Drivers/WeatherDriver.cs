using WeatherDotCom.Models;
using WeatherDotCom.Services;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace WeatherDotCom.Drivers
{
    public class WeatherDriver : ContentPartDriver<WeatherPart>
    {
        protected IWeatherChannelService WeatherChannelService { get; private set; }

        public WeatherDriver(IWeatherChannelService weatherChannelService)
        {
            WeatherChannelService = weatherChannelService;
        }

        //GET
        protected override DriverResult Display(WeatherPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_WeatherWidget", () => shapeHelper.Parts_WeatherWidget(
                WeatherResults: WeatherChannelService.GetCurrentConditions(part),
                WidgetConfiguration: part));
        }

        // GET
        protected override DriverResult Editor(WeatherPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_WeatherWidget_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/WeatherWidget",
                    Model: part,
                    Prefix: Prefix));
        }

        // POST
        protected override DriverResult Editor(WeatherPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}