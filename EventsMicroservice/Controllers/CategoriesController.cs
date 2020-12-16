using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsMicroservice.Data.Models;
using EventsMicroservice.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _repository;

        public CategoriesController(ICategoriesRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<EventCategory> Get()
        {
            var categories = _repository.GetAll();
            return categories.OrderBy(x => x.Name);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public EventCategory Post([FromBody] EventCategory category)
        {
            return _repository.Add(category);
        }
    }
}
