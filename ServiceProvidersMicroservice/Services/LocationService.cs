using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceProvidersMicroservice.Models;

namespace ServiceProvidersMicroservice.Services
{
    public class LocationService : ILocationService
    {
        private readonly string _apiKey = "TG7sUM3IEwg0r8q70A8NkSI68Q0rz4_wXBxBjHaHd7M";
        private readonly string _url = "https://discover.search.hereapi.com/v1/discover";
        public async Task<IEnumerable<NearByPlace>> GetNearBy(string coordinates, string category)
        {
            var apiResponse = await _url
                .SetQueryParams(new
                {
                    at = coordinates,
                    q = category,
                    apiKey = _apiKey
                }).GetJsonAsync<DiscoverApiResponse>();

            return apiResponse.Items;
        }
    }
}