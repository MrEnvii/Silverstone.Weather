using Silverstone.Weather.Domain.Model;

namespace Silverstone.Weather.Models
{
    public class LocationCurrentWeather
    {
        public string Location { get; set; }
        public string Units { get; set; } = "metric";
        public WeatherInfo WeatherInfo { get; set; }
        public string ErrorResult { get; set; }
    }
}