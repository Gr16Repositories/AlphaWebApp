using AlphaWebApp.Models;
using System.Net.Http;

namespace AlphaWebApp.Services
{
    public class StockService : IStockService
    {
        private readonly HttpClient _httpClient;

        public StockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    
        public IEnumerable<StockDetails> GetStockDetails(string region)
        {
            IEnumerable<StockDetails> result = Enumerable.Empty<StockDetails>();
            var response = _httpClient.GetAsync($"https://stockapinewsapp.azurewebsites.net/summary?region={region}").Result;
            if(response.IsSuccessStatusCode)
            {
               result = response.Content.ReadFromJsonAsync<StockResponse>().Result.Top10;
            }
            return result;
        }
    }
}
