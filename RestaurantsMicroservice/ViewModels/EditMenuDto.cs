using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RestaurantsMicroservice.ModelValidation;

namespace RestaurantsMicroservice.ViewModels
{
    public class EditMenuDto
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        [MaxFileSize(5*1024*1024)]
        [AllowedFileExtensions(new string[] { ".jpg", ".jpeg", ".png"})]
        public IFormFile Image { get; set; }
        
    }
}
