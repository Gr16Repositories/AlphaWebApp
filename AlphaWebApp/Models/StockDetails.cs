using System.ComponentModel;
using System.Text.Json.Serialization;

namespace AlphaWebApp.Models
{
    public class StockDetails
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("close")]
        public decimal Close { get; set; }
        [JsonPropertyName("prevClose")]
        [DisplayName("Previous Close")]
        public decimal PrevClose { get; set; }
        [JsonPropertyName("percentChange")]
        [DisplayName("Percentage Change")]
        public decimal PercentChange { get; set; }
    }

    public class StockResponse
    {
        [JsonPropertyName("top10")]
        public IEnumerable<StockDetails> Top10 { get; set; }
    }
}
