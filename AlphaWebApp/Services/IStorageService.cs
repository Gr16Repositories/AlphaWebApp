using AlphaWebApp.Models.Entities;

namespace AlphaWebApp.Services
{
    public interface IStorageService
    {
        public Uri uploadBlob(string pathfile);

        public Uri GetBlob(string pathfile);

        public void DeleteBlobImage(string pathfile, int categoryId);

        void AddSpotPriceToTable();

        List<SpotPriceEntity> GetEntities(string partitionKey);

        void DeleteEntity(string rowKey);


        void UpdateEntity(string rowKey);

    }
}
