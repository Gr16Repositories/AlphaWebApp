using AlphaWebApp.Models;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers
{
    public class WeatherForecastController : Controller
    {
        
        private readonly IWeatherForcastService _weatherForcastService;
        private readonly HttpClient _httpClient;
        public WeatherForecastController( IWeatherForcastService weatherForcastService, HttpClient httpClient)
        {
           
            _weatherForcastService = weatherForcastService;
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Index(string city, string lang)
        {
            if (string.IsNullOrEmpty(city))
            {
                return View();
            }
            var weather = _weatherForcastService.GetForecast(city, lang);
            return View("Index",weather);
        }

        public IActionResult GetForecast(string city, string lang)
        {
            if (string.IsNullOrEmpty(city))
            {
                return View();
            }
            var weather = _weatherForcastService.GetForecast(city, lang);
            return Json(new { forecast = weather });
        }
    }
}
