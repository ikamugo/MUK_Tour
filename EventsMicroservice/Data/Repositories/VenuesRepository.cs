using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsMicroservice.Data.Models;
using EventsMicroservice.Data.Repositories.Interfaces;
using EventsMicroservice.Data.Settings;

namespace EventsMicroservice.Data.Repositories
{
    public class VenuesRepository : GenericRepository<Venue>, IVenuesRepository
    {
        public VenuesRepository(IDatabaseSettings settings) 
            : base(settings, settings.VenuesCollection)
        {
        }
    }
}
