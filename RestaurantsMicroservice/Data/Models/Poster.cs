using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsMicroservice.Data.Models
{
    public class Poster
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] BinaryData { get; set; }
        public long Size { get; set; }
        public string FileExtension { get; set; }
    }
}
