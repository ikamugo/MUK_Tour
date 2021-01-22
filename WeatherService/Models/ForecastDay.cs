using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherService.Models
{
    public class ForecastDay
    {
        public DateTime Date { get; set; }

        [JsonProperty("day")]
        public ForecastWeather ForecastWeather { get; set; }

        [JsonProperty("astro")]
        public AstronomyForecast Astro { get; set; }

        [JsonProperty("hour")] 
        public IEnumerable<HourlyForecast> Hourly { get; set; }
    }
}
