using System.Threading.Tasks;
using Silverstone.Weather.Domain.Services;
using System.Web.Mvc;
using Silverstone.Weather.Models;

namespace Silverstone.Weather.Controllers
{
    public class CurrentWeatherController : Controller
    {
        private readonly IWeatherService _weatherService;
        public CurrentWeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        public ActionResult Index()
        {
            return View("Index", new LocationCurrentWeather());
        }
        [HttpPost]
        public async Task<ActionResult> Index(LocationCurrentWeather locationCurrentWeather)
        {
            var currentWeather = await _weatherService.GetCurrentWeather(locationCurrentWeather.Location, locationCurrentWeather.Units);
            if (!currentWeather.Success)
            {
                ModelState.AddModelError(string.Empty, currentWeather.ErrorMessage);
                locationCurrentWeather.ErrorResult = currentWeather.ErrorMessage;
            }
            else
            {
                locationCurrentWeather.WeatherInfo = currentWeather.ResultItem;
            }

            return View("Index", locationCurrentWeather);
        }
    }
}