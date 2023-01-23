using Azure;
using Azure.Data.Tables;
using System.ComponentModel;

namespace AlphaWebApp.Models.Entities
{
    public class SpotPriceEntity : ITableEntity
    {
        [DisplayName("Date")]
        public DateTime DateAndTime { get; set; }

        [DisplayName("Area Name")]
        public string AreaName { get; set; }

        [DisplayName("Low Price")]
        public double SpotPriceLow { get; set; }

        [DisplayName("High Price")]
        public double SpotPriceHigh { get; set; }

        public string PartitionKey { get; set; } = default!;

        public string RowKey { get; set; } = default!;

        public DateTimeOffset? Timestamp { get; set; } = default!;

        public ETag ETag { get; set; } = default!;

    }
}
