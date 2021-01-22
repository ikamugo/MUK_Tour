using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherService.Models
{
    public class ForecastWeather
    {
        [JsonProperty("maxtemp_c")]
        public double High { get; set; }

        [JsonProperty("mintemp_c")]
        public double Low { get; set; }

        [JsonProperty("avgtemp_c")]
        public double Temperature { get; set; }

        [JsonProperty("maxwind_kph")]
        public double WindSpeed { get; set; }

        [JsonProperty("totalprecip_mm")]
        public double Precipitation { get; set; }

        [JsonProperty("avgvis_km")]
        public double Visibility { get; set; }
        
        [JsonProperty("avghumidity")]
        public double Humidity { get; set; }

        [JsonProperty("daily_will_it_rain")]
        public bool WillItRain { get; set; }

        [JsonProperty("daily_chance_of_rain")]
        public string ChanceOfRain { get; set; }

        [JsonProperty("uv")]
        public double UvIndex { get; set; }

        [JsonProperty("condition")]
        public WeatherCondition Condition { get; set; }
    }
}
