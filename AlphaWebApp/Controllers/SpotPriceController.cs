using AlphaWebApp.Models.ViewModels;
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
            _storageService.AddSpotPriceToTable();
            SpotPricesVM allAreas = new SpotPricesVM();
            allAreas.SpotPriceListSE1 = _storageService.GetEntities("SE1");
            allAreas.SpotPriceListSE1 = _storageService.GetEntities("SE2");
            allAreas.SpotPriceListSE1 = _storageService.GetEntities("SE3");
            allAreas.SpotPriceListSE1 = _storageService.GetEntities("SE4");

            return View(allAreas);
        }

        public void StorePriceData()
        {
            _storageService.AddSpotPriceToTable();
        }


        public ActionResult GetAreaPrices(string area = "SE1")
        {
            var areaPrices = _storageService.GetEntities(area); 
            return View(areaPrices);
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
