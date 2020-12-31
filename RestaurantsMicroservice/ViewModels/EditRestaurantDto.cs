using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsMicroservice.ViewModels
{
    public class EditRestaurantDto
    {
        public int Id { get; set; }
        public LocationDto Location { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class LocationDto 
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
