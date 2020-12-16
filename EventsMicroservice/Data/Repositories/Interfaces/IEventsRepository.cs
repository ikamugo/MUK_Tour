using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsMicroservice.Data.Models;

namespace EventsMicroservice.Data.Repositories.Interfaces
{
    public interface IEventsRepository: IGenericRepository<ScheduledEvent>
    {
    }
}
