using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EventsMicroservice.Data.Models
{
    public class EventPoster: IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ScheduledEventId { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] BinaryData { get; set; }
        public long Size { get; set; }
        public string FileExtension { get; set; }
    }
}
