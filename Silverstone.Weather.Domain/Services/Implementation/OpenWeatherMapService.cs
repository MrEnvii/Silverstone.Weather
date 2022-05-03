using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Silverstone.Weather.Domain.Model;

namespace Silverstone.Weather.Domain.Services.Implementation
{
    public class OpenWeatherMapService : IOpenWeatherMapService
    {
        private readonly IWebRequestService _webRequestService;
        private readonly string _baseUrl;
        private readonly string _appId;

        public OpenWeatherMapService(IWebRequestService webRequestService, string baseUrl, string appId)
        {
            _webRequestService = webRequestService;
            _baseUrl = baseUrl;
            _appId = appId;
        }

        /// <summary>
        /// Get Current Weather information from a given Latitude and Longitude, and the unit of measurement the temperatures will be displayed in.
        /// </summary>
        /// <param name="lat">Latitude of the location</param>
        /// <param name="lon">Longitude of the location</param>
        /// <param name="units">Units of measurement for the temperature results</param>
        /// <returns>The Current Weather information for the given location</returns>
        public async Task<OpenWeatherMapWeatherInfo> GetWeatherFromCoordinates(double lat, double lon, string units)
        {
            var requestUri = new Uri($"{_baseUrl}data/2.5/weather?lat={lat}&lon={lon}&units={units}&appid={_appId}");

            var result = await _webRequestService.GetAsync(requestUri);
            if (result != null)
            {
                try
                {
                    var model = JsonConvert.DeserializeObject<OpenWeatherMapWeatherInfo>(result);
                    if (model != null)
                    {
                        model.Units = units;
                        return model;
                    }
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// Get Geo Locations for the given location name
        /// </summary>
        /// <param name="locationName">Location to search</param>
        /// <param name="limit">Limit to number of results returned from the OpenWeatherMap API (Max: 5)</param>
        /// <returns>List of Geo Location information for the given name, includes Latitude and Longitude values</returns>
        public async Task<List<GeoLocation>> GetGeoLocationsFromName(string locationName, int limit)
        {
            if (limit > 5)
            {
                //Limit at 5 due to API Subscription
                limit = 5;
            }

            var requestUri = new Uri($"{_baseUrl}geo/1.0/direct?q={locationName}&limit={limit}&appid={_appId}");

            var result = await _webRequestService.GetAsync(requestUri);
            if (result != null)
            {
                try
                {
                    var model = JsonConvert.DeserializeObject<List<GeoLocation>>(result);
                    return model;
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }
    }
}
