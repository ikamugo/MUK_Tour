using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantsMicroservice.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public Logo Logo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public Guid ManagerId { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
    }
}
