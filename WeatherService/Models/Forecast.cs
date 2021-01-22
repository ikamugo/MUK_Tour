using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherService.Models
{
    public class Forecast
    {
        [JsonProperty("forecastday")]
        public IEnumerable<ForecastDay> ForecastDays { get; set; }
    }
}
