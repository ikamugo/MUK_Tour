using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventsMicroservice.Data.Models;
using EventsMicroservice.ViewModels;

namespace EventsMicroservice.AutoMapperProfiles
{
    public class EventsProfile: Profile
    {
        public EventsProfile()
        {
            CreateMap<CreateEventDto, ScheduledEvent>();
            CreateMap<ScheduledEvent, ListEventDto>();
            CreateMap<ScheduledEvent, EventDetailDto>();
        }
    }
}
