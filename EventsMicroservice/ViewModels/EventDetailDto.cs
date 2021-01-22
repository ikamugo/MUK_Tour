using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsMicroservice.Data.Models;

namespace EventsMicroservice.ViewModels
{
    public class EventDetailDto: ListEventDto
    {
        public string[] Posters { get; set; }
        public string Description { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Organizer { get; set; }
        public IEnumerable<OrganizerContact> OrganizerContacts { get; set; }
    }
}
