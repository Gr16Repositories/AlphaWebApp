using System.Text.Json.Serialization;

namespace AlphaWebApp.Models.Klarna
{
    public class OrderLine
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
    }
}
