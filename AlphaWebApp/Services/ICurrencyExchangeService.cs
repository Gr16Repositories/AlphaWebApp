using AlphaWebApp.Models;

namespace AlphaWebApp.Services
{
    public interface ICurrencyExchangeService
    {
        Task<Currency> GetCurrencyExchangeValue(string from, string to);
    }
}
