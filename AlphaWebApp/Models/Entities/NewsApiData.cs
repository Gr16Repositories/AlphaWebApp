using AlphaWebApp.Models.SpotModels;
using Azure;
using Azure.Data.Tables;
using System.Text.Json.Serialization;

namespace AlphaWebApp.Models.Entities
{
    public class NewsApiData  : ITableEntity
    {
        public string Source { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string UrlToImaage { get; set; }

        public string PublishedAt { get; set; }

        public string Content { get; set; }

        public string PartitionKey { get; set; } = default!;

        public string RowKey { get; set; } = default!;

        public DateTimeOffset? Timestamp { get; set; } = default!;

        public ETag ETag { get; set; } = default!;
    }
}
