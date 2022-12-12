namespace AlphaWebApp.Services
{
    public interface IStorageService
    {
        Uri uploadBlob(string pathfile);

        Uri GetBlob(string pathfile);
    }
}
