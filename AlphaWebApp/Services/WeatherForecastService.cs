using AlphaWebApp.Data;
using AlphaWebApp.Models;
using AlphaWebApp.Models.Entities;
using Azure.Data.Tables;
using System;

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

        //public async Task AddWeatherForeCaseToTable()
        //{
        //    HttpClient httpClient = new HttpClient();
        //    var res = httpClient.GetAsync($"https://weatherapi.dreammaker-it.se/forecast?city=Linkoping&lang=en").Result;
        //    var forecast = res.Content.ReadFromJsonAsync<WeatherForecast>().Result;

        //    TableClient tableClient = _tableServerClient.GetTableClient(tableName: "Weather");
        //    tableClient.CreateIfNotExists();



        //        WeatherForecast weatherEntity = new();
        //        weatherEntity.City = forecast.City;
        //        weatherEntity.Summary = forecast.Summary;
        //        weatherEntity.TemperatureF = forecast.TemperatureF;
        //        weatherEntity.TemperatureC = forecast.TemperatureC;
        //        weatherEntity.Lang = forecast.Lang;
        //         weatherEntity.Humidity = forecast.Humidity;

        //    weatherEntity.Date = DateTime.SpecifyKind(DateTime.Now.Date, DateTimeKind.Utc);
        //        //newEntity.RowKey = item.Area + newEntity.DateAndTime;
        //        //newEntity.RowKey.Replace(" ", "");
        //        weatherEntity.RowKey = new string(Enumerable.Repeat(chars, 20)
        //                .Select(s => s[random.Next(s.Length)]).ToArray());
        //        tableClient.AddEntity(weatherEntity);

        //}

    }
}
