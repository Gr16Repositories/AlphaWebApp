using Azure.Storage.Blobs;
using System.Security.Policy;

namespace AlphaWebApp.Services
{
    public class StorageService : IStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly BlobServiceClient _blobServiceClient;

        public StorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _blobServiceClient = new BlobServiceClient(_configuration["AzureWebJobsStorge"]);
        }

        public Uri uploadBlob(string pathfile)
        {
            string containerName = "news-images";// if you want to use a small image on blob so change the name to the folder like "news-images-sm" that exactly the name in storgeacount on azure
            BlobContainerClient containerClient = 
                                _blobServiceClient.GetBlobContainerClient(containerName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/articles");
            BlobClient blobClient= containerClient.GetBlobClient(pathfile);
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
           // return null;
        }
    }
}
