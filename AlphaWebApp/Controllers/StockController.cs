using AlphaWebApp.Models;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockService _stockService;
        private readonly HttpClient _httpClient;

        public StockController(IStockService stockService, HttpClient httpClient)
        {
            _stockService = stockService;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index(string region)
        {
            region = "uk";
            IEnumerable<StockDetails> stockDetails = await Task.Run(() => _stockService.GetStockDetails(region));
            if (stockDetails != null)
                return View(stockDetails);
            else
                return View();
        }
    }
}
