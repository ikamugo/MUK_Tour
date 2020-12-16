using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsMicroservice.Data.Models
{
    public interface IEntity
    {
        string Id { get; set; }
    }
}
