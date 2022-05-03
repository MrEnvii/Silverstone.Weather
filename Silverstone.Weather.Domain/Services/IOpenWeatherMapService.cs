using System.Collections.Generic;
using System.Threading.Tasks;
using Silverstone.Weather.Domain.Model;

namespace Silverstone.Weather.Domain.Services
{
    public interface IOpenWeatherMapService
    {
        Task<OpenWeatherMapWeatherInfo> GetWeatherFromCoordinates(double lat, double lon, string units);
        Task<List<GeoLocation>> GetGeoLocationsFromName(string name, int limit);
    }
}
