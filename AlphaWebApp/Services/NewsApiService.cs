using AlphaWebApp.Models.Entities;
using AlphaWebApp.Models.SpotModels;
using Azure.Data.Tables;
using System;

namespace AlphaWebApp.Services
{
    public class NewsApiService : INewsApiService
    {
        private readonly IStorageService _storageService;
        
        public NewsApiService( IStorageService storageService)
        {
            _storageService= storageService;
        }


        public void StoreNewsApiArticleInTable()
        {
            var allarticlesData = _storageService.GetLattestSwedishArticles();

            List<NewsApiData> areaData = new List<NewsApiData>();

            // after I get the data I will continue  put it in the azure table in order to make new request every some time 


            //var se1Data = allarticlesData.Where(a => d.AreaName == "SE1").ToList();
            //var se1High = se1Data.Max(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
            //var se1Low = se1Data.Min(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
            //areaData.Add(new AreaData() { Area = "SE1", PriceHigh = se1High, PriceLow = se1Low });

            //var se2Data = allData.Where(d => d.AreaName == "SE2").ToList();
            //var se2High = se2Data.Max(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
            //var se2Low = se2Data.Min(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
            //areaData.Add(new AreaData() { Area = "SE2", PriceHigh = se2High, PriceLow = se2Low });


            //var se3Data = allData.Where(d => d.AreaName == "SE3").ToList();
            //var se3High = se3Data.Max(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
            //var se3Low = se3Data.Min(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
            //areaData.Add(new AreaData() { Area = "SE3", PriceHigh = se3High, PriceLow = se3Low });


            //var se4Data = allData.Where(d => d.AreaName == "SE4").ToList();
            //var se4High = se4Data.Max(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
            //var se4Low = se4Data.Min(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
            //areaData.Add(new AreaData() { Area = "SE4", PriceHigh = se4High, PriceLow = se4Low });

            //TableClient tableClient = _tableServerClient.GetTableClient(tableName: "spotprice");
            //tableClient.CreateIfNotExists();

            //foreach (var item in areaData)
            //{
            //    SpotPriceEntity newEntity = new();
            //    newEntity.AreaName = item.Area;
            //    newEntity.SpotPriceHigh = item.PriceHigh;
            //    newEntity.SpotPriceLow = item.PriceLow;
            //    newEntity.PartitionKey = item.Area;
            //    newEntity.DateAndTime = DateTime.SpecifyKind(DateTime.Now.Date, DateTimeKind.Utc);
            //    //newEntity.RowKey = item.Area + newEntity.DateAndTime;
            //    //newEntity.RowKey.Replace(" ", "");
            //    newEntity.RowKey = new string(Enumerable.Repeat(chars, 20)
            //            .Select(s => s[random.Next(s.Length)]).ToArray());
            //    tableClient.AddEntity(newEntity);
            //}
        }


    }
}
