using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsMicroservice.Data.Models
{
    public enum ContactType
    {
        Email = 1,
        Phone
    }
    public class OrganizerContact
    {
        public ContactType Type { get; set; }
        public string Contact { get; set; }
    }
}
