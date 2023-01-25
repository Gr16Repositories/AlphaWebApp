using AlphaWebApp.Models.Entities;
using AlphaWebApp.Models.SpotModels;
using AlphaWebApp.Models.ViewModels;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json;

namespace AlphaWebApp.ViewComponents
{
    public class SpotPriceViewComponent : ViewComponent
    {


        public SpotPriceViewComponent()
        {

        }

        public IViewComponentResult Invoke()
        {
            HttpClient _spotHttpClient = new HttpClient();
            var request = _spotHttpClient.GetStringAsync("https://spotfunc.azurewebsites.net/api/SpotPriceRequest?code=vgUdbbCJSApniy7OgY2tfEJuTomMaNzZ-QWTNcMYS8h-AzFuS91H_w==").Result;
            if (request != null)
            {
                TodaysSpotData todaysData = JsonConvert.DeserializeObject<TodaysSpotData>(request);
                var allData = todaysData.TodaysSpotPrices.SelectMany(a => a.SpotData).ToList();


                List<AreaData> areaData = new List<AreaData>();

                var se1Data = allData.Where(d => d.AreaName == "SE1").ToList();
                var se1High = se1Data.Max(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 100000));
                var se1Low = se1Data.Min(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
                areaData.Add(new AreaData() { Area = "SE1", PriceHigh = se1High, PriceLow = se1Low });
                ViewBag.SE1 = se1Data;
                ViewBag.SE1High = se1High;
                ViewBag.SE1Low = se1Low;

                var se2Data = allData.Where(e => e.AreaName == "SE2").ToList();
                var se2High = se2Data.Max(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 100000));
                var se2Low = se2Data.Min(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
                areaData.Add(new AreaData() { Area = "SE2", PriceHigh = se2High, PriceLow = se2Low });
                ViewBag.SE2 = se2Data;
                ViewBag.SE2High = se2High;
                ViewBag.SE2Low = se2Low;

                var se3Data = allData.Where(e => e.AreaName == "SE3").ToList();
                var se3High = se3Data.Max(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 100000));
                var se3Low = se3Data.Min(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
                areaData.Add(new AreaData() { Area = "SE3", PriceHigh = se3High, PriceLow = se3Low });
                ViewBag.SE3 = se3Data;
                ViewBag.SE3High = se3High;
                ViewBag.SE3Low = se3Low;


                var se4Data = allData.Where(e => e.AreaName == "SE4").ToList();
                var se4High = se4Data.Max(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 100000));
                var se4Low = se4Data.Min(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
                areaData.Add(new AreaData() { Area = "SE4", PriceHigh = se4High, PriceLow = se4Low });
                ViewBag.SE4 = se4Data;
                ViewBag.SE4High = se4High;
                ViewBag.SE4Low = se4Low;

                ViewBag.AllSpotPrice = allData;
                ViewBag.AreaData = areaData;

                return View(allData);


            }
            else
            {
                return Content(string.Empty);
            }

        }
    }
}
