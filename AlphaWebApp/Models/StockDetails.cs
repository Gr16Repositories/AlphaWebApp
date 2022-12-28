using System.ComponentModel;

namespace AlphaWebApp.Models
{
    public class StockDetails
    {
        public string Name { get; set; }

        public string Symbol { get; set; }

        public decimal Close { get; set; }

        [DisplayName("Previous Close")]
        public decimal PrevClose { get; set; }

        [DisplayName("Percentage Change")]
        public decimal PercentChange { get; set; }
    }
}
