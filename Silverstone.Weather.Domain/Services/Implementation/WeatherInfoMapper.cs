using System.Linq;
using Silverstone.Weather.Domain.Model;

namespace Silverstone.Weather.Domain.Services.Implementation
{
    public class WeatherInfoMapper : IWeatherInfoMapper
    {
        private readonly IUnixDateTimeService _unixDateTimeService;
        public WeatherInfoMapper(IUnixDateTimeService unixDateTimeService)
        {
            _unixDateTimeService = unixDateTimeService;
        }

        /// <summary>
        /// Maps the data returned from the OpenWeatherMap Api to the WeatherInfo object, currently used in the front end
        /// </summary>
        /// <param name="openWeatherMapWeatherInfo">Weather Information from the OpenWeatherMap Api</param>
        /// <returns>WeatherInfo object with the icon, and temperature unit converted</returns>
        public WeatherInfo MapOpenWeatherMapWeatherInfo(OpenWeatherMapWeatherInfo openWeatherMapWeatherInfo)
        {
            var iconInfo = openWeatherMapWeatherInfo.Weather.FirstOrDefault() ?? new Model.Weather
            {
                Icon = "",
                Main = "None",
            };

            return new WeatherInfo
            {
                LocationName = openWeatherMapWeatherInfo.Name,
                IconSrc = $"http://openweathermap.org/img/wn/{iconInfo.Icon}@2x.png",
                IconAlt = iconInfo.Main,
                Temp = openWeatherMapWeatherInfo.Main.Temp,
                TempMax = openWeatherMapWeatherInfo.Main.Temp_Max,
                TempMin = openWeatherMapWeatherInfo.Main.Temp_Min,
                Humidity = openWeatherMapWeatherInfo.Main.Humidity,
                Sunrise = _unixDateTimeService.UnixTimeStampToDateTime(openWeatherMapWeatherInfo.Sys.Sunrise + openWeatherMapWeatherInfo.Timezone),
                Sunset = _unixDateTimeService.UnixTimeStampToDateTime(openWeatherMapWeatherInfo.Sys.Sunset + openWeatherMapWeatherInfo.Timezone),
                TempUnit = openWeatherMapWeatherInfo.Units == "metric" ? "°C" : "°F",
            };
        }
    }
}