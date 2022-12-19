namespace AlphaWebApp.Services
{
    public interface IStorageService
    {
        public Uri uploadBlob(string pathfile);

        public Uri GetBlob(string pathfile);

        public void DeleteBlobImage(string pathfile, int categoryId);
    }
}
