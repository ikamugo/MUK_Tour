using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantsMicroservice.Data.Models
{
    public class Location
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public Restaurant Restaurant { get; set; }
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
        [JsonPropertyName("lng")]
        public double Longitude { get; set; }
    }
}
