using AlphaWebApp.Models;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.ViewComponents
{
    public class CurrencyExchangeViewComponent : ViewComponent
    {
        private readonly ICurrencyExchangeService currencyExchangeService;

        public CurrencyExchangeViewComponent(ICurrencyExchangeService currencyExchangeService)
        {
            this.currencyExchangeService = currencyExchangeService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string from, string to)
        {
            return View();
        }
    }
}
