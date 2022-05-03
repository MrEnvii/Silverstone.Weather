using System.Threading.Tasks;
using Silverstone.Weather.Domain.Model;

namespace Silverstone.Weather.Domain.Services
{
    public interface IWeatherInfoMapper
    {
        WeatherInfo MapOpenWeatherMapWeatherInfo(OpenWeatherMapWeatherInfo openWeatherMapWeatherInfo);
    }
}