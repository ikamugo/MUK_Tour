using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantsMicroservice.Data.Models;

namespace RestaurantsMicroservice.Data
{
    public class RestaurantsDataContext : DbContext
    {
        public RestaurantsDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Poster> Posters { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<SpecialMenu> SpecialMenus { get; set; }
    }
}
