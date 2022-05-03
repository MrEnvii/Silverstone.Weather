using System.Threading.Tasks;
using Silverstone.Weather.Domain.Model;

namespace Silverstone.Weather.Domain.Services
{
    public interface IWeatherService
    {
        Task<ValidationResult<WeatherInfo>> GetCurrentWeather(string location, string units);
    }
}