using System.Text.Json.Serialization;

namespace AlphaWebApp.Models.Klarna
{
    public class Checkout
    { 
    [JsonPropertyName("intent")]
    public string Intent { get; set; }
    [JsonPropertyName("purchase_country")]
    public string PurchaseCountry { get; set; }
    [JsonPropertyName("purchase_currency")]
    public string PurchaseCurrency { get; set; }
    [JsonPropertyName("locale")]
    public string Local { get; set; }
    [JsonPropertyName("order_amount")]
    public int OrderAmount { get; set; }
    [JsonPropertyName("order_lines")]
    public IEnumerable<OrderLine> OrderLine { get; set; }
   
    [JsonPropertyName("subscription")]
    public Subscription Subscription { get; set; }
   
    [JsonPropertyName("reference")]
    public int Reference { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
    [JsonPropertyName("unit_price")]
    public int Unit_price { get; set; }
    [JsonPropertyName("tax_rate")]
    public int TaxRate { get; set; }
    [JsonPropertyName("total_amount")]
    public int TotalAmount { get; set; }
    [JsonPropertyName("total_discount_amount")]
    public int TotalDiscountAmount { get; set; }
    [JsonPropertyName("total_tax_amount")]
    public int TotalTaxAmount { get; set; }


    }

}
