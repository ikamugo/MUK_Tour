using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvidersMicroservice.Models
{
    public class Address
    {
        public string Label { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string District { get; set; }
    }
}
