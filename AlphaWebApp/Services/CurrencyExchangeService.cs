using AlphaWebApp.Models;

namespace AlphaWebApp.Services
{
    public class CurrencyExchangeService : ICurrencyExchangeService
    {

        private readonly HttpClient httpClient;

        public CurrencyExchangeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Currency> GetCurrencyExchangeValue(string from, string to)
        {
            Currency currencyResult = new Currency();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://currency-exchange.p.rapidapi.com/exchange?from={from}&to={to}&q=1.0"),
                Headers =
                {
                 { "X-RapidAPI-Key", "1bfec01b87msh0e84173c20590e8p133cfcjsn0729a6962c95" },
                 { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                currencyResult.result = await response.Content.ReadAsStringAsync();
                return currencyResult;
            }
        }       
    }
}
