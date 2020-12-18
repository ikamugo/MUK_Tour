using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServiceProvidersMicroservice.Models
{
    public class NearByPlace
    {
        [JsonProperty("title")]
        public string Name { get; set; }
        public Address Address { get; set; }
        public Location Position { get; set; }
        public IEnumerable<Location> Access { get; set; }
        public double Distance { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
    }
}
