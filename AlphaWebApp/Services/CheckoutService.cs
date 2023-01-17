using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AlphaWebApp.Services
{
    public class CheckoutService:ICheckoutService
    {
        private readonly HttpClient _httpClient;
        public CheckoutService( HttpClient httpClient)
        {
            _httpClient = httpClient;
           

        }
        

    }
}
