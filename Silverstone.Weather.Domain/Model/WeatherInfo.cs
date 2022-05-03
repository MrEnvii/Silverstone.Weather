using System;

namespace Silverstone.Weather.Domain.Model
{
    public class WeatherInfo
    {
        public string LocationName { get; set; }
        public string IconSrc { get; set; }
        public string IconAlt { get; set; }
        public double Temp { get; set; }
        public double TempMax { get; set; }
        public double TempMin { get; set; }
        public string TempUnit { get; set; }
        public double Humidity { get; set; }
        public DateTimeOffset Sunrise { get; set; }
        public DateTimeOffset Sunset { get; set; }
    }
}