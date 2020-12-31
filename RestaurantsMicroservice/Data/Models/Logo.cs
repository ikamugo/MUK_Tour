using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsMicroservice.Data.Models
{
    public class Logo
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] BinaryData { get; set; }
        public long Size { get; set; }
        public string FileExtension { get; set; }
    }
}
