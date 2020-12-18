using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EventsMicroservice.Data.Models
{
    public enum VenueType
    {
        Indoor = 1,
        Outdoor
    }
    public class Venue : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; }
        public string Name { get; set; }
        public VenueType Type { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
