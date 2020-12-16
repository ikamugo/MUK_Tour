using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EventsMicroservice.ViewModels
{
    public class UploadPostersDto
    {
        public string EventId { get; set; }
        public IFormFile[] Files { get; set; }
    }
}
