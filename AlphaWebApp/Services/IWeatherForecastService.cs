using AlphaWebApp.Models;

namespace AlphaWebApp.Services
{
    public interface IWeatherForcastService
    {
        WeatherForecast GetForecast(string city, string lang = "en");
    }
}
