using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventsMicroservice.Data.Models;
using EventsMicroservice.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenuesController : ControllerBase
    {
        private readonly IVenuesRepository _venuesRepository;
        private readonly IMapper _mapper;

        public VenuesController(IMapper mapper, IVenuesRepository venuesRepository)
        {
            _mapper = mapper;
            _venuesRepository = venuesRepository;
        }

        // GET: api/<VenuesController>
        [HttpGet]
        public IEnumerable<Venue> Get()
        {
            return _venuesRepository.GetAll();
        }

        // GET api/<VenuesController>/5
        [HttpGet("{id}")]
        public Venue Get(string id)
        {
            return _venuesRepository.Get(id);
        }

        // POST api/<VenuesController>
        [HttpPost]
        public Venue Post([FromBody] Venue venueDto)
        {
            var venue = _venuesRepository.Add(venueDto);
            return venue;
        }

        // PUT api/<VenuesController>/5
        [HttpPut("{id}")]
        public ActionResult<Venue> Put([FromBody] Venue venueDto)
        {
            var venue = _venuesRepository.Get(venueDto.Id);
            if(venue == null)
            {
                return NotFound();
            }
            return _venuesRepository.Update(venueDto);
        }

        // DELETE api/<VenuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var venue = _venuesRepository.Get(id);
            if (venue == null)
            {
                return NotFound();
            }
            _venuesRepository.Remove(id);
            return Ok();
        }
    }
}
