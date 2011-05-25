using System;

namespace WeatherDotCom.Models
{
    public class Weather
    {        
        public LocationInfo LocationInfo { get; set; }
        public CurrentConditions CurrentConditions { get; set; }
        public DateTime TimeCached { get; set; }
        public String ApiStatus { get; set; }
    }
}