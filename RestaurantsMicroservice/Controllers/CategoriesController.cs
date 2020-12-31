using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantsMicroservice.Data;
using RestaurantsMicroservice.Data.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly RestaurantsDataContext _context;

        public CategoriesController(RestaurantsDataContext context)
        {
            _context = context;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.Categories
                .OrderBy(x => x.Name)
                .ToList();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            var category = _context.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            return category;
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public Category Post([FromBody] Category dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public ActionResult<Category> Put(int id, [FromBody] Category dto)
        {
            var category = _context.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }

            category.Name = dto.Name;
            _context.SaveChanges();
            return category;
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var category = _context.Categories
                .Include(x => x.Menus)
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if(category == null)
            {
                return NotFound();
            }

            if (category.Menus.Any())
            {
                return UnprocessableEntity(new
                {
                    Error = "Cannot delete category containing menu items. Delete menu items first."
                });
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok("Category Deleted");
        }
    }
}
