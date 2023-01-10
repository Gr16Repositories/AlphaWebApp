using Azure;
using Azure.Data.Tables;

namespace AlphaWebApp.Models.Entities
{
    public class SpotPriceEntity : ITableEntity
    {
        public DateTime DateAndTime { get; set; }

        public string AreaName { get; set; }

        public double SpotPriceLow { get; set; }

        public double SpotPriceHigh { get; set; }

        public string PartitionKey { get; set; } = default!;

        public string RowKey { get; set; } = default!;

        public DateTimeOffset? Timestamp { get; set; } = default!;

        public ETag ETag { get; set; } = default!;

    }
}
