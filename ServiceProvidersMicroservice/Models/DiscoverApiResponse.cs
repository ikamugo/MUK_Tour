using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvidersMicroservice.Models
{
    public class DiscoverApiResponse
    {
        public IEnumerable<NearByPlace> Items { get; set; }
    }
}
