using AlphaWebApp.Models;

namespace AlphaWebApp.Services
{
    public interface IStockService
    {
        IEnumerable<StockDetails> GetStockDetails(string region);

    }
}
