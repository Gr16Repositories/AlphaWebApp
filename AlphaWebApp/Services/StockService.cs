using AlphaWebApp.Models;

namespace AlphaWebApp.Services
{
    public class StockService : IStockService
    {
        private readonly HttpClient _httpClient;

        public StockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    
        public StockDetails GetStockDetails(string region)
        {
            StockDetails result = new StockDetails();
            var response = _httpClient.GetAsync("https://stockapinewsapp.azurewebsites.net/summary?region={region}").Result;
            if(response.IsSuccessStatusCode)
            {
               result  = response.Content.ReadFromJsonAsync<StockDetails>().Result;
            }
            return result;
        }
    }
}
