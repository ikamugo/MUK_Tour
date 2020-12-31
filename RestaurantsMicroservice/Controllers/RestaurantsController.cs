using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantsMicroservice.Data;
using RestaurantsMicroservice.Data.Models;
using RestaurantsMicroservice.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly RestaurantsDataContext _context;

        public RestaurantsController(RestaurantsDataContext context)
        {
            _context = context;
        }

        // GET: api/<RestaurantsController>
        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _context.Restaurants.ToList();
        }

        // GET api/<RestaurantsController>/5
        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get(int id)
        {
            var restaurant = _context.Restaurants
                .Include(x => x.Location)
                .Include(x => x.Menus)
                .SingleOrDefault(x => x.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        // POST api/<RestaurantsController>
        [HttpPost]
        public ActionResult<Restaurant> Post([FromBody] EditRestaurantDto dto)
        {
            Request.Headers.TryGetValue("User-Id", out var userId);
            var restaurant = new Restaurant
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Location = new Location
                {
                    Latitude = dto.Location.Lat,
                    Longitude = dto.Location.Lng
                },
                ManagerId = Guid.Parse(userId)
            };

            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return Get(restaurant.Id);
        }

        // PUT api/<RestaurantsController>/5
        [HttpPut("{id}")]
        public ActionResult<Restaurant> Put(int id, [FromBody] EditRestaurantDto dto)
        {
            Request.Headers.TryGetValue("User-Id", out var userId);
            var restaurant = _context.Restaurants
                .Include(x => x.Location)
                .SingleOrDefault(x => x.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            if (restaurant.ManagerId != Guid.Parse(userId))
            {
                return Forbid();
            }

            restaurant.Name = dto.Name;
            restaurant.Email = dto.Email;
            restaurant.Phone = dto.Phone;
            restaurant.Location.Latitude = dto.Location.Lat;
            restaurant.Location.Longitude = dto.Location.Lng;
            _context.SaveChanges();
            return restaurant;
        }

        [HttpGet("{id}/menu")]
        public ActionResult<object> GetMenu(int id)
        {
            var menu = _context.Menus
                .Include(x => x.Category)
                .Include(x => x.Restaurant)
                .Where(x => x.RestaurantId == id)
                .ToList();

            return menu;
        }


        [HttpGet("{id}/menu/{menuId}")]
        public ActionResult<Menu> GetMenuItem(int menuId)
        {
            var menu = _context.Menus
                .Include(x => x.Category)
                .Include(x => x.Restaurant)
                .Include(x => x.Poster)
                .SingleOrDefault(x => x.Id == menuId);

            return menu;
        }

        [HttpPost("{id}/menu/")]
        public ActionResult<Menu> CreateMenuItem(int id, [FromForm] EditMenuDto dto)
        {
            var menu = new Menu
            {
                RestaurantId = id,
                CategoryId = dto.CategoryId,
                Description = dto.Description,
                Name = dto.Name,
                Price = dto.Price,
            };

            if (dto.Image != null)
            {
                var fileName = Path.GetFileName(dto.Image.FileName);
                var poster = new Poster
                {
                    FileExtension = Path.GetExtension(fileName),
                    Name = dto.Image.FileName,
                    ContentType = dto.Image.ContentType,
                    Size = dto.Image.Length
                };
                using (var memoryStream = new MemoryStream())
                {
                    dto.Image.CopyTo(memoryStream);
                    poster.BinaryData = memoryStream.ToArray();
                }
                menu.Poster = poster;
            }

            _context.Menus.Add(menu);
            _context.SaveChanges();
            return GetMenuItem(menu.Id);
        }

        [HttpPut("{restaurantId}/menu/{menuId}")]
        public ActionResult<Menu> EditMenuItem(int menuId, [FromForm] EditMenuDto dto)
        {
            var menu = _context.Menus
                .Include(x => x.Poster)
                .SingleOrDefault(x => x.Id == menuId);

            if (menu == null)
            {
                return NotFound();
            }

            menu.CategoryId = dto.CategoryId;
            menu.Description = dto.Description;
            menu.Name = dto.Name;
            menu.Price = dto.Price;

            if (dto.Image != null)
            {
                if (menu.Poster == null)
                {
                    menu.Poster = new Poster();
                }

                var fileName = Path.GetFileName(dto.Image.FileName);
                menu.Poster.FileExtension = Path.GetExtension(fileName);
                menu.Poster.Name = dto.Image.FileName;
                menu.Poster.ContentType = dto.Image.ContentType;
                menu.Poster.Size = dto.Image.Length;
                
                using (var memoryStream = new MemoryStream())
                {
                    dto.Image.CopyTo(memoryStream);
                    menu.Poster.BinaryData = memoryStream.ToArray();
                }
                
            }
            _context.SaveChanges();
            return GetMenuItem(menu.Id);
        }

        [HttpGet("{id}/menu/{menuId}/poster")]
        public ActionResult GetMenuItemPoster(int menuId)
        {
            var poster = _context.Posters
                .SingleOrDefault(x => x.MenuId == menuId);

            if (poster == null)
            {
                return NotFound();
            }
            return File(poster.BinaryData, poster.ContentType, poster.Name);
        }

        [HttpGet("{id}/poster")]
        public ActionResult GetPoster(int id)
        {
            var poster = _context.Logos
                .SingleOrDefault(x => x.RestaurantId == id);

            if (poster == null)
            {
                return NotFound();
            }
            return File(poster.BinaryData, poster.ContentType, poster.Name);
        }

        [HttpPost("{id}/poster")]
        public ActionResult UploadPoster(int id, [FromForm] FileUploadDto uploadDto)
        {
            Request.Headers.TryGetValue("User-Id", out var userId);
            var restaurant = _context.Restaurants
                .Include(x => x.Logo)
                .SingleOrDefault(x => x.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            if (restaurant.ManagerId != Guid.Parse(userId))
            {
                return Forbid();
            }

            if (restaurant.Logo == null)
            {
                restaurant.Logo = new Logo();
            }
            var fileName = Path.GetFileName(uploadDto.Image.FileName);
            restaurant.Logo.FileExtension = Path.GetExtension(fileName);
            restaurant.Logo.Name = uploadDto.Image.FileName;
            restaurant.Logo.ContentType = uploadDto.Image.ContentType;
            restaurant.Logo.Size = uploadDto.Image.Length;

            using (var memoryStream = new MemoryStream())
            {
                uploadDto.Image.CopyTo(memoryStream);
                restaurant.Logo.BinaryData = memoryStream.ToArray();
            }
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/<RestaurantsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Request.Headers.TryGetValue("User-Id", out var userId);
            var restaurant = _context.Restaurants
                .Include(x => x.Location)
                .Include(x => x.Menus).ThenInclude(m => m.Specials)
                .SingleOrDefault(x => x.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            if (restaurant.ManagerId != Guid.Parse(userId))
            {
                return Forbid();
            }

            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
            return Ok();
        }
    }
}
