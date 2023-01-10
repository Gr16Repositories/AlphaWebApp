using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.Text.Json.Serialization;

namespace AlphaWebApp.Models.SpotModels
{
   

    public class TodaysSpotData
    {
        [JsonPropertyName("todaysSpotPrices")]
        public List<SpotPriceHour> TodaysSpotPrices { get; set; }

    }
    public class SpotPriceHour
    {
        [JsonPropertyName("spotData")]
        public List<AreaSpotsData> SpotData { get; set; }
    }

    public class AreaSpotsData
    {
        [JsonPropertyName("dateAndTime")]
        public DateTime DateAndTime { get; set; }

        [JsonPropertyName("areaName")]
        public string AreaName { get; set;}

        [JsonPropertyName("price")]
        public string Price { get; set; }


    }
}
