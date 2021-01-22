using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherService.Models
{
    public class CurrentWeather
    {
        [JsonProperty("temp_c")]
        public double Temperature { get; set; }
        [JsonProperty("is_day")]
        public bool IsDay { get; set; }
        [JsonProperty("condition")]
        public WeatherCondition Condition { get; set; }
        [JsonProperty("wind_kph")]
        public double WindSpeed { get; set; }
        [JsonProperty("wind_dir")]
        public string WindDirection { get; set; }
        [JsonProperty("wind_degree")]
        public double WindDegrees { get; set; }
        [JsonProperty("gust_kph")]
        public double WindGust { get; set; }
        [JsonProperty("pressure_mb")]
        public double Pressure { get; set; }
        [JsonProperty("precip_mm")]
        public double Precipitation { get; set; }
        [JsonProperty("humidity")]
        public double Humidity { get; set; }
        [JsonProperty("cloud")]
        public double Cloud { get; set; }
        [JsonProperty("feelslike_c")]
        public double FeelsLike { get; set; }
        [JsonProperty("vis_km")]
        public double Visibility { get; set; }
        [JsonProperty("uv")]
        public double UvIndex { get; set; }
    }

    public class WeatherCondition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public int Code { get; set; }
    }
}
