using Microsoft.VisualBasic;

namespace AlphaWebApp.Models
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public int  TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public int Humidity { get; set; }   

        public int WindSpeed { get; set; }

        public DateTime Date { get; set; }

        public string  City { get; set; }

        public string  Description { get; set; }
    }
}
