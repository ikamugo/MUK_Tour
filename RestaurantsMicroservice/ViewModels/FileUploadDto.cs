using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RestaurantsMicroservice.ViewModels
{
    public class FileUploadDto: IValidatableObject
    {
        [Required(ErrorMessage = "Please select and upload a file.")]
        public IFormFile Image { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var imageFile = ((FileUploadDto)validationContext.ObjectInstance).Image;
            var extension = Path.GetExtension(imageFile.FileName);
            var size = imageFile.Length;
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(extension.ToLower()))
                yield return new ValidationResult($"File extension is not valid. Acceptable formats are {string.Join(", ", allowedExtensions)}");

            if (size > (5 * 1024 * 1024))
                yield return new ValidationResult("File size is bigger than 5MB.");
        }
    }
}
