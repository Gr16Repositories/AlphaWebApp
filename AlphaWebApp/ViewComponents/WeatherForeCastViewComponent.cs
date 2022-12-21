using AlphaWebApp.Data;
using AlphaWebApp.Models;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.ViewComponents
{
    public class WeatherForeCastViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly IWeatherForcastService _weatherForecastService;

        public WeatherForeCastViewComponent(ApplicationDbContext db,IWeatherForcastService weatherForcastService)
        {
            _db = db;
            _weatherForecastService = weatherForcastService;    
        }
        public IViewComponentResult Invoke(string city , string lang)
        {
            WeatherForecast weatherReport = _weatherForecastService.GetForecast(city, lang);
            if(weatherReport != null)
            return View(weatherReport);
            else
                return Content(string.Empty);
        }
    }
}
