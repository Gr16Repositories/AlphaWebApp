using Azure.Storage.Blobs;
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
            string containerName = "news-images";
            BlobContainerClient containerClient = 
                                _blobServiceClient.GetBlobContainerClient(containerName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/articles");
            BlobClient blobClient= containerClient.GetBlobClient(pathfile);
            string fileNameWithPath = Path.Combine(path, pathfile);
            blobClient.Upload(fileNameWithPath, true);

            return blobClient.Uri;
        }
    }
}
