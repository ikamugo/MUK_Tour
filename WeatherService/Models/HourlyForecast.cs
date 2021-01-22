using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherService.Models
{
    public class HourlyForecast: CurrentWeather
    {
        public DateTime Time { get; set; }
        [JsonProperty("will_it_rain")]
        public bool WillItRain { get; set; }

        [JsonProperty("chance_of_rain")]
        public string ChanceOfRain { get; set; }
    }
}
