using WeatherDotCom.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace WeatherDotCom.Handlers
{
    public class WeatherHandler : ContentHandler
    {
        public WeatherHandler(IRepository<WeatherPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}