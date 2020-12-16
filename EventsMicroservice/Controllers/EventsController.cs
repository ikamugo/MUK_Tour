using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventsMicroservice.Data.Models;
using EventsMicroservice.Data.Repositories.Interfaces;
using EventsMicroservice.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEventsRepository _eventsRepo;
        private readonly IPostersRepository _postersRepo;

        public EventsController(IMapper mapper, IEventsRepository eventsRepo, IPostersRepository postersRepo)
        {
            _mapper = mapper;
            _eventsRepo = eventsRepo;
            _postersRepo = postersRepo;
        }


        // GET: api/Events
        [HttpGet]
        public IEnumerable<ListEventDto> Get()
        {
            var events = _eventsRepo.Find(x => x.Date >= DateTime.Now);
            return _mapper.Map<IEnumerable<ListEventDto>>(events);
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public EventDetailDto Get(string id)
        {
            var scheduledEvent = _eventsRepo.Get(id);
            var posters = _postersRepo.Find(x => x.ScheduledEventId == id);
            var eventDto = _mapper.Map<EventDetailDto>(scheduledEvent);
            eventDto.Posters = posters.Select(x => x.Id).ToArray();
            return eventDto;
        }

        // POST: api/Events
        [HttpPost]
        public EventDetailDto Post([FromBody] CreateEventDto eventDto)
        {
            var newEvent = _mapper.Map<ScheduledEvent>(eventDto);
            Request.Headers.TryGetValue("User-Id", out var userId);
            newEvent.CreatedByUserId = Guid.Parse(userId);

            var result = _eventsRepo.Add(newEvent);
            return _mapper.Map<EventDetailDto>(result);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
