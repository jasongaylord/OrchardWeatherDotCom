namespace WeatherDotCom.Models
{
    public class CurrentConditions
    {
        public string Temperature { get; set; }
        public string FeelsLike { get; set; }
        public string Description { get; set; }
        public string DescriptionIconNumber { get; set; }
        public string BarometricPressure { get; set; }
        public string BarometricPressureDirection { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public string WindGust { get; set; }
        public string Humidity { get; set; }
        public string Visibility { get; set; }
        public string UvIndex { get; set; }
        public string UvDescription { get; set; }
        public string Dewpoint { get; set; }
        public string MoonIconNumber { get; set; }
        public string MoonType { get; set; }
    }
}