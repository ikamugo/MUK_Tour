using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EventsMicroservice.Data.Models;
using EventsMicroservice.Data.Repositories.Interfaces;
using EventsMicroservice.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EventsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostersController : Controller
    {
        private readonly IPostersRepository _repository;

        public PostersController(IPostersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var poster = _repository.Get(id);
            return File(poster.BinaryData, poster.ContentType, poster.Name);
        }

        [HttpPost]
        public IActionResult Post([FromForm]UploadPostersDto postersDto)
        {

            if(postersDto.Files != null)
            {
                foreach(var file in postersDto.Files)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var poster = new EventPoster()
                    {
                        ScheduledEventId = postersDto.EventId,
                        FileExtension = Path.GetExtension(fileName),
                        Name = file.FileName,
                        ContentType = file.ContentType,
                        Size = file.Length
                    };

                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        poster.BinaryData = memoryStream.ToArray();
                    }
                    _repository.Add(poster);
                }
            }

            return Ok();
        }
    }
}
