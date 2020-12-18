using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvidersMicroservice.Models
{
    public class ServiceProvider
    {
        public string Name { get; set; }
        public Location Position { get; set; }
        public double Distance { get; set; }
        public string[] Categories { get; set; }
        public ContactDto Contact { get; set; }
    }

    public class ContactDto
    {
        public string[] Email { get; set; }
        public string[] Phone { get; set; }
        public string[] Website { get; set; }
    }
}
