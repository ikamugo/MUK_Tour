using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherService.Models
{
    public class AstronomyForecast
    {
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Moonrise { get; set; }
        public string MoonSet { get; set; }
    }
}
