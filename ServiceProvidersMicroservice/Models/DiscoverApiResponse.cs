using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvidersMicroservice.Models
{
    public class DiscoverApiResponse
    {
        public List<NearByPlace> Items { get; set; }
    }
}
