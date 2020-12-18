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

        [HttpGet]
        public string[] Get()
        {
            return new string[]
            {
                "churches", "hospitals", "hostels", "libraries", "mosques"
            };
        }

        [HttpGet("churches")]
        public async Task<IEnumerable<ServiceProvider>> GetChurchesAsync()
        {
            return GetServiceProviders(await _locationService.GetNearBy(_coordinates, "church"));
        }

        [HttpGet("hospitals")]
        public async Task<IEnumerable<ServiceProvider>> GetHospitalsAsync()
        {
            return GetServiceProviders(await _locationService.GetNearBy(_coordinates, "hospital"));
        }

        [HttpGet("hostels")]
        public async Task<IEnumerable<ServiceProvider>> GetHostelsAsync()
        {
            return GetServiceProviders(await _locationService.GetNearBy(_coordinates, "hostel"));
        }

        [HttpGet("libraries")]
        public async Task<IEnumerable<ServiceProvider>> GetLibrariesAsync()
        {
            return GetServiceProviders(await _locationService.GetNearBy(_coordinates, "library"));
        }

        [HttpGet("mosques")]
        public async Task<IEnumerable<ServiceProvider>> GetMosquesAsync()
        {
            return GetServiceProviders(await _locationService.GetNearBy(_coordinates, "mosque"));
        }

        private IEnumerable<ServiceProvider> GetServiceProviders(IEnumerable<NearByPlace> nearByPlaces)
        {
            return nearByPlaces
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