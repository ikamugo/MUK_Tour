using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceProvidersMicroservice.Models;

namespace ServiceProvidersMicroservice.Services        
{
    public interface ILocationService
    {
        Task<IEnumerable<NearByPlace>> GetNearBy(string coordinates, string category);
    }
}
