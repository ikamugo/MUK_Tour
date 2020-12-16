using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsMicroservice.Data.Models;

namespace EventsMicroservice.ViewModels
{
    public class CreateEventDto
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Venue { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
        public string Organizer { get; set; }
        public IEnumerable<OrganizerContact> OrganizerContacts { get; set; }
    }
}
