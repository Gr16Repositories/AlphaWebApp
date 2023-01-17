using System.Text.Json.Serialization;

namespace AlphaWebApp.Models.Klarna
{
    public class Session
    {
        [JsonPropertyName("OrderAmount")]

        public int OrderAmount { get; set; }
        [JsonPropertyName("OrderLine")]
        public string OrderLine { get; set; }
        [JsonPropertyName("PurchaseCountry")]
        public string PurchaseCountry { get; set; }
        [JsonPropertyName("PurchaseCurrency")]
        public int PurchaseCurrency { get; set; }


    }
}
