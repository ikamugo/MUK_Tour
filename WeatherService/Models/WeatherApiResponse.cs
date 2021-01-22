using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherService.Models
{
    public class WeatherApiResponse
    {
        public CurrentWeather Current { get; set; }
        public Forecast Forecast { get; set; }
    }
}
