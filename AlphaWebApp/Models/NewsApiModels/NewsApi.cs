using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace AlphaWebApp.Models.SpotModels
{
    public class NewsArticlesList
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("totalResults")]
        public int Total { get; set; }
        [JsonPropertyName("articles")]
        public List<NewsArticle> NewsArticles { get; set; }
    }

    public class NewsArticle
    {
        [JsonPropertyName("source")]
        public Source Source { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string  Description { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("urlToImage")]
        public string UrlToImaage { get; set; }
        [JsonPropertyName("publishedAt")]
        public string PublishedAt { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }

    }


    public class Source
    {
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }


   
}
