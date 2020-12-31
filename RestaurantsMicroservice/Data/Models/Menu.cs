using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestaurantsMicroservice.Data.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        [JsonIgnore] 
        public Restaurant Restaurant { get; set; }
        [JsonIgnore] 
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public Poster Poster { get; set; }
        public double Price { get; set; }
        [JsonIgnore]
        public IEnumerable<SpecialMenu> Specials { get; set; }
    }
}
