using AlphaWebApp.Models;

namespace AlphaWebApp.Services
{
    public interface IStockService
    {
       StockDetails GetStockDetails(string region);

    }
}
