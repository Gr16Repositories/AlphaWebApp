using AlphaWebApp.Models;
using AlphaWebApp.Models.Entities;
using AlphaWebApp.Models.SpotModels;
using Azure.Data.Tables;
using Azure.Storage.Blobs;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Security.Policy;

namespace AlphaWebApp.Services
{
    public class StorageService : IStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly TableServiceClient _tableServerClient;
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static Random random = new Random();

        public StorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _blobServiceClient = new BlobServiceClient(_configuration["AzureWebJobsStorge"]);
            _tableServerClient = new TableServiceClient(_configuration["AzureWebJobsStorge"]);
        }

        public Uri uploadBlob(string pathfile)
        {
            string containerName = "news-images";// if you want to use a small image on blob so change the name to the folder like "news-images-sm" that exactly the name in storgeacount on azure
            BlobContainerClient containerClient =
                                _blobServiceClient.GetBlobContainerClient(containerName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/articles");
            BlobClient blobClient = containerClient.GetBlobClient(pathfile);
            string fileNameWithPath = Path.Combine(path, pathfile);
            blobClient.Upload(fileNameWithPath, true);
            return blobClient.Uri;
        }

        public Uri GetBlob(string blobName)
        {
            string containerName = "news-images-sm";
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobclient = containerClient.GetBlobClient(blobName);
            return blobclient.Uri;
        }

        public void DeleteBlobImage(string pathfile, int categoryId)
        {
            string containerName = "news-images";// if you want to use a small image on blob so change the name to the folder like "news-images-sm" that exactly the name in storgeacount on azure
            BlobContainerClient containerClient =
                                _blobServiceClient.GetBlobContainerClient(containerName + "/" + categoryId);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/articles" + "/" + categoryId);
            BlobClient blobClient = containerClient.GetBlobClient(categoryId + "/" + pathfile);
            blobClient.Delete();
        }

        public async void AddSpotPriceToTable()
        {
            // add request for data 
            HttpClient _spotHttpClient = new HttpClient();
            var request = await _spotHttpClient.GetStringAsync("https://spotfunc.azurewebsites.net/api/SpotPriceRequest?code=vgUdbbCJSApniy7OgY2tfEJuTomMaNzZ-QWTNcMYS8h-AzFuS91H_w==");
            TodaysSpotData todaysData = JsonConvert.DeserializeObject<TodaysSpotData>(request);
            var allData = todaysData.TodaysSpotPrices.SelectMany(a => a.SpotData).ToList();

            List<AreaData> areaData = new List<AreaData>();

            var se1Data = allData.Where(d => d.AreaName == "SE1").ToList();
            var se1High = se1Data.Max(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
            var se1Low = se1Data.Min(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
            areaData.Add(new AreaData() { Area = "SE1", PriceHigh = se1High, PriceLow = se1Low });

            var se2Data = allData.Where(d => d.AreaName == "SE2").ToList();
            var se2High = se2Data.Max(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
            var se2Low = se2Data.Min(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
            areaData.Add(new AreaData() { Area = "SE2", PriceHigh = se2High, PriceLow = se2Low });


            var se3Data = allData.Where(d => d.AreaName == "SE3").ToList();
            var se3High = se3Data.Max(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
            var se3Low = se3Data.Min(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
            areaData.Add(new AreaData() { Area = "SE3", PriceHigh = se3High, PriceLow = se3Low });


            var se4Data = allData.Where(d => d.AreaName == "SE4").ToList();
            var se4High = se4Data.Max(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
            var se4Low = se4Data.Min(p => (Convert.ToDouble(p.Price.Replace(" ", "")) / 1000));
            areaData.Add(new AreaData() { Area = "SE4", PriceHigh = se4High, PriceLow = se4Low });

            TableClient tableClient = _tableServerClient.GetTableClient(tableName: "spotprice");
            tableClient.CreateIfNotExists();

            foreach (var item in areaData)
            {
                SpotPriceEntity newEntity = new();
                newEntity.AreaName = item.Area;
                newEntity.SpotPriceHigh = item.PriceHigh;
                newEntity.SpotPriceLow = item.PriceLow;
                newEntity.PartitionKey = item.Area;
                newEntity.DateAndTime = DateTime.SpecifyKind(DateTime.Now.Date, DateTimeKind.Utc);
                //newEntity.RowKey = item.Area + newEntity.DateAndTime;
                //newEntity.RowKey.Replace(" ", "");
                newEntity.RowKey = new string(Enumerable.Repeat(chars, 20)
                        .Select(s => s[random.Next(s.Length)]).ToArray()); 
                tableClient.AddEntity(newEntity);
            }
        }

        public List<SpotPriceEntity> GetEntities(string partitionKey)
        {
            TableClient tableClient = _tableServerClient.GetTableClient
                (tableName: "spotprice");
            var list = tableClient.Query<SpotPriceEntity>(r => r.PartitionKey == partitionKey).ToList();
            return list;
        }

        public void DeleteEntity(string rowKey)
        {
            TableClient tableClient = _tableServerClient.GetTableClient
              (tableName: "spotprice");
            var tableEntity = tableClient.Query<SpotPriceEntity>(e => e.RowKey == rowKey).FirstOrDefault();
            tableClient.DeleteEntity(tableEntity.PartitionKey, tableEntity.RowKey);
        }

        public void UpdateEntity(string rowKey)
        {
            TableClient tableClient = _tableServerClient.GetTableClient
             (tableName: "spotprice");
            var tableEntity = tableClient.Query<SpotPriceEntity>(e => e.RowKey == rowKey).FirstOrDefault();
            tableClient.UpdateEntity<SpotPriceEntity>(tableEntity, tableEntity.ETag);
        }



    }
}
