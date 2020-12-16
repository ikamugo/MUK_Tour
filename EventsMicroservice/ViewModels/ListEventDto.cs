using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsMicroservice.ViewModels
{
    public class ListEventDto
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string Venue { get; set; }
    }
}
