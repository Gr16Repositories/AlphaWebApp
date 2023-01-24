using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers
{
    public class CurrencyExchangeController : Controller
    {
        private readonly ICurrencyExchangeService currency;

        public CurrencyExchangeController(ICurrencyExchangeService currency)
        {
            this.currency = currency;
        }

        public async Task<IActionResult> Index(string from , string to)
        {
            var res = await currency.GetCurrencyExchangeValue(from, to);
            return Json(res);
        }
    }
}
