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
        public ActionResult<EventDetailDto> Get(string id)
        {
            var scheduledEvent = _eventsRepo.Get(id);
            if (scheduledEvent == null)
            {
                return NotFound();
            }
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
        public ActionResult<EventDetailDto> Put(string id, [FromBody] EventDetailDto eventDto)
        {
            var scheduledEvent = _eventsRepo.Get(id);
            if(scheduledEvent == null)
            {
                return NotFound();
            }

            _mapper.Map(eventDto, scheduledEvent);
            _eventsRepo.Update(scheduledEvent);
            return _mapper.Map<EventDetailDto>(scheduledEvent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var scheduledEvent = _eventsRepo.Get(id);
            Request.Headers.TryGetValue("User-Id", out var userId);
            if(scheduledEvent.CreatedByUserId == Guid.Parse(userId))
            {
                _eventsRepo.Remove(scheduledEvent);
                return Ok();
            }

            return Unauthorized();
        }
    }
}
