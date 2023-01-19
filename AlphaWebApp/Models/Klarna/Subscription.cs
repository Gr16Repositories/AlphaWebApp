using System.Text.Json.Serialization;

namespace AlphaWebApp.Models.Klarna
{
    public class Subscription
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("interval")]
        public string Intervel { get; set; }
        [JsonPropertyName("interval_count")]
        public int InervelCount { get; set; }
    }
}
