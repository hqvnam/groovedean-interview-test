using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GrooveDean.API.Bussiness;
using GrooveDean.API.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Pegasi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        public readonly WeatherBussiness _weatherBussiness;

        public WeatherController(IHttpClientFactory httpClientFactory)
        {
            _weatherBussiness = new WeatherBussiness(httpClientFactory);
        }

        [HttpGet]
        public async Task<WeatherForecast> GetWeatherForecasts(string locationCode)
        {
            return await _weatherBussiness.GetWeatherForecasts(locationCode);
        }
    }
}
