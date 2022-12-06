using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace AlphaWebApp.Models
{
    public class WeatherForecast
    {
        public int Id { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public int TemperatureC { get; set; }

        [Required]
        public int TemperatureF { get; set; }

        [Required]
        public int Humidity { get; set; }

        [Required]
        public int WindSpeed { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
