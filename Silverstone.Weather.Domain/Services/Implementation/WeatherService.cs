using System;
using System.Linq;
using System.Threading.Tasks;
using Silverstone.Weather.Domain.Model;

namespace Silverstone.Weather.Domain.Services.Implementation
{
    public class WeatherService : IWeatherService   
    {
        private readonly IOpenWeatherMapService _openWeatherMapService;
        private readonly IWeatherInfoMapper _weatherInfoMapper;

        public WeatherService(IOpenWeatherMapService openWeatherMapService, IWeatherInfoMapper weatherInfoMapper)
        {
            _openWeatherMapService = openWeatherMapService;
            _weatherInfoMapper = weatherInfoMapper;
        }

        /// <summary>
        /// Get the current weather information for a given location name
        /// </summary>
        /// <param name="location">Location to search for the current weather</param>
        /// <param name="units">Unit of measurement the temperature will be displayed in e.g. metric</param>
        /// <returns>Returns a Validation result which can return Successful with WeatherInfo or Error with an error message</returns>
        public async Task<ValidationResult<WeatherInfo>> GetCurrentWeather(string location, string units)
        {
            if (String.IsNullOrWhiteSpace(location) || String.IsNullOrEmpty(location))
            {
                return new ValidationResult<WeatherInfo>().Error("The location cannot be empty!");
            }

            var geoLocations = await _openWeatherMapService.GetGeoLocationsFromName(location, 1);
            if (geoLocations != null)
            {
                var geoLocation = geoLocations.FirstOrDefault();
                if (geoLocation != null)
                {
                    var weatherInfo = await _openWeatherMapService.GetWeatherFromCoordinates(geoLocation.Lat, geoLocation.Lon, units);
                    if (weatherInfo != null)
                    {
                        var currentWeather = _weatherInfoMapper.MapOpenWeatherMapWeatherInfo(weatherInfo);
                        return new ValidationResult<WeatherInfo>().Successful(currentWeather);

                    }
                    else
                    {
                        return new ValidationResult<WeatherInfo>().Error("Weather could not be found for this location!");
                    }
                }
                else
                {
                    return new ValidationResult<WeatherInfo>().Error("Invalid Location Entered, Try again!");
                }
            }
            else
            {
                return new ValidationResult<WeatherInfo>().Error("Invalid Location Entered, Try again!");
            }
        }
    }
}