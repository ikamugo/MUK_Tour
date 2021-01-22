using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly string _apiKey = "f1071348d50a48b7960125830212101";
        private readonly string _baseUrl = "http://api.weatherapi.com/v1/forecast.json";

        // GET: api/<WeatherController>
        [HttpGet("current")]
        public async Task<ActionResult<CurrentWeather>> GetAsync(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                ModelState.AddModelError("location", "Location is required. Can be name or lat,long coordinates");
                return BadRequest(ModelState);
            }
            var apiResponse = await _baseUrl
                .SetQueryParams(new
                {
                    key = _apiKey,
                    q = location
                }).GetJsonAsync<WeatherApiResponse>();

            return apiResponse.Current;
        }

        // GET api/<WeatherController>/forecast
        [HttpGet("forecast")]
        public async Task<ActionResult<IEnumerable<ForecastDay>>> GetForecast(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                ModelState.AddModelError("location", "Location is required. Can be name or lat,long coordinates");
                return BadRequest(ModelState);
            }
            var apiResponse = await _baseUrl
                .SetQueryParams(new
                {
                    key = _apiKey,
                    q = location,
                    days = 10
                }).GetJsonAsync<WeatherApiResponse>();

            return apiResponse.Forecast.ForecastDays.ToList();
        }
    }
}
