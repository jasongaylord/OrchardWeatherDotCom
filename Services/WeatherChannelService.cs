using System;
using System.Xml;
using System.Xml.Serialization;
using WeatherDotCom.Models;
using JetBrains.Annotations;
using Orchard.Caching;
using Orchard.Services;

namespace WeatherDotCom.Services
{
    [UsedImplicitly]
    public class WeatherChannelService : IWeatherChannelService
    {
        protected ICacheManager CacheManager { get; private set; }
        protected IClock Clock { get; private set; }

        public WeatherChannelService(ICacheManager cacheManager, IClock clock)
        {
            CacheManager = cacheManager;
            Clock = clock;
        }

        public Weather GetCurrentConditions(WeatherPart part)
        {
            var cacheKey = "WeatherDotComWeather_For_" + part.SearchString;

            return CacheManager.Get(cacheKey, ctx =>
                                                  {
                                                      ctx.Monitor(Clock.When(TimeSpan.FromMinutes(part.MinutesToCache)));
                                                      return RetrieveCurrentConditions(part);
                                                  });
        }

        protected Weather RetrieveCurrentConditions(WeatherPart part)
        {
            // Initialize objects
            var currentConditions = new CurrentConditions();
            var locationInfo = new LocationInfo();
            var weather = new Weather();

            // New Source
            var callingUrl = String.Format(part.WebServiceUrl, part.SearchString, part.PartnerId, part.LicenseKey);
            var xmlSerializer = new XmlSerializer(typeof(weather));
            var wcResults = (weather)xmlSerializer.Deserialize(XmlReader.Create(callingUrl));

            var loc = (weatherLoc)wcResults.Items[1];
            var cc = (weatherCC)wcResults.Items[2];

            // Pass XSD objects to new model (not necessary, but provides cleaner, easier property access)
            locationInfo.LocationName = loc.dnam;
            locationInfo.Latitude = loc.lat;
            locationInfo.Longitude = loc.lon;
            locationInfo.Sunrise = loc.sunr;
            locationInfo.Sunset = loc.suns;
            locationInfo.TimeZone = loc.zone;

            currentConditions.BarometricPressure = cc.bar[0].r;
            currentConditions.BarometricPressureDirection = cc.bar[0].d;
            currentConditions.Description = cc.t;
            currentConditions.DescriptionIconNumber = cc.icon;
            currentConditions.Dewpoint = cc.dewp;
            currentConditions.FeelsLike = cc.flik;
            currentConditions.Humidity = cc.hmid;
            currentConditions.MoonIconNumber = cc.moon[0].icon;
            currentConditions.MoonType = cc.moon[0].t;
            currentConditions.Temperature = cc.tmp;
            currentConditions.UvDescription = cc.uv[0].t;
            currentConditions.UvIndex = cc.uv[0].i;
            currentConditions.Visibility = cc.vis;
            currentConditions.WindDirection = cc.wind[0].t;
            currentConditions.WindGust = cc.wind[0].gust;
            currentConditions.WindSpeed = cc.wind[0].s;

            weather.CurrentConditions = currentConditions;
            weather.LocationInfo = locationInfo;
            weather.TimeCached = DateTime.UtcNow;
            weather.ApiStatus = String.Format(part.WebServiceUrl, part.SearchString, part.PartnerId, part.LicenseKey);

            return weather;
        }
    }
}