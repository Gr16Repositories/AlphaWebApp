using AlphaWebApp.Data;
using AlphaWebApp.Models;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.ViewComponents
{
    public class StockViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly IStockService _stockService;

        public StockViewComponent(ApplicationDbContext db, IStockService stockService)
        {
            _db = db;
            _stockService = stockService;
        }

        public IViewComponentResult Invoke(string region)
        {
            IEnumerable<StockDetails> stockDetails = _stockService.GetStockDetails(region);
            if (stockDetails != null)
                return View(stockDetails);
            else
                return Content(string.Empty);
        }

    }
}
