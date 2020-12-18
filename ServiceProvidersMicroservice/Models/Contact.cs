using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServiceProvidersMicroservice.Models
{
    public class Contact
    {
        public IEnumerable<ContactValue> Email { get; set; }
        public IEnumerable<ContactValue> Phone { get; set; }
        [JsonProperty(PropertyName = "www")]
        public IEnumerable<ContactValue> Website { get; set; }
    }

    public class ContactValue
    {
        public string Value { get; set; }
    }
}
