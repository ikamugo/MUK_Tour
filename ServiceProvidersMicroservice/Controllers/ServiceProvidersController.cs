using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceProvidersMicroservice.Models;
using ServiceProvidersMicroservice.Services;

namespace ServiceProvidersMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceProvidersController : ControllerBase
    {
        private readonly string _coordinates = "0.33363,32.56737";
        private readonly ILocationService _locationService;

        public ServiceProvidersController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("categories")]
        public string[] Get()
        {
            return new string[]
            {
                "church", "hospital", "hostel", "library", "mosque"
            };
        }

        [HttpGet("{category}")]
        public async Task<IEnumerable<ServiceProvider>> GetServiceProvidersAsync(string category)
        {
            var nearbyProviders = await _locationService.GetNearBy(_coordinates, category);
            return nearbyProviders
                .Select(x => new ServiceProvider
                {
                    Name = x.Address.Label,
                    Categories = x.Categories.Select(c => c.Name).ToArray(),
                    Distance = x.Distance,
                    Position = x.Position,
                    Contact = GetContactDto(x.Contacts)
                })
                .ToList();
        }

        private ContactDto GetContactDto(IEnumerable<Contact> contacts)
        {
            if (contacts == null)
                return null;

            return new ContactDto
            {
                Email = contacts
                .SelectMany(x => x.Email != null ? x.Email.Select(e => e.Value) : new string[] { })
                .ToArray(),
                Phone = contacts
                .SelectMany(x => x.Phone != null ? x.Phone.Select(e => e.Value) : new string[] { })
                .ToArray(),
                Website = contacts
                .SelectMany(x => x.Website != null ? x.Website.Select(e => e.Value) : new string[] { })
                .ToArray()
            };
        }
    }   
}