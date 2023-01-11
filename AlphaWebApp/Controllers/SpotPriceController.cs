using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers
{
    public class SpotPriceController : Controller
    {
        private readonly IStorageService _storageService;
        public SpotPriceController(IStorageService storageService)
        {
            _storageService= storageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public void StorePriceData()
        {
            _storageService.AddSpotPriceToTable();
        }


        public void GetAreaPrices()
        {
            var areaPrices = _storageService.GetEntities("SE2");
        }


        public void DeleteAreaData()
        {
            var entity = _storageService.GetEntities("SE2").FirstOrDefault();
            _storageService.DeleteEntity(entity.RowKey);
        }

        public void UpdateAreaData()
        {
            var entity = _storageService.GetEntities("SE2").FirstOrDefault();
            _storageService.UpdateEntity(entity.RowKey);
        }
    }
}
