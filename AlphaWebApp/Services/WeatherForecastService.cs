using AlphaWebApp.Data;
using AlphaWebApp.Models;

namespace AlphaWebApp.Services
{
    public class WeatherForcastService: IWeatherForcastService
    {
        
        private readonly HttpClient _httpClient;
        
        public WeatherForcastService(  HttpClient httpClient)
        {
              
            _httpClient = httpClient;

        }

        public WeatherForecast GetForecast(string city, string lang = "en")
        {
            var res = _httpClient.GetAsync($"https://weatherapi.dreammaker-it.se/forecast?city={city}&lang={lang}").Result;
            if (!res.IsSuccessStatusCode)
            {
                return null;
            }
            var forecast = res.Content.ReadFromJsonAsync<WeatherForecast>().Result;
            return forecast;
        }
        
    }
}
