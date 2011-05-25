using WeatherDotCom.Models;
using Orchard;

namespace WeatherDotCom.Services
{
    public interface IWeatherChannelService : IDependency
    {
        Weather GetCurrentConditions(WeatherPart part);
    }
}