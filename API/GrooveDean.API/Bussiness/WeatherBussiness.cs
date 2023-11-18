using System;
using System.Net.Http;
using System.Threading.Tasks;
using GrooveDean.API.Model;
using Newtonsoft.Json;

namespace GrooveDean.API.Bussiness
{
    public class WeatherBussiness
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public readonly HttpClient client = null;
        public WeatherBussiness(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

            if (client == null)
            {
                client = _httpClientFactory.CreateClient("API Client");               
            }
        }

        public async Task<WeatherForecast> GetWeatherForecasts(string locationCode)
        {
            // init request
            var apiUrl = $"https://api.weatherapi.com/v1/current.json?q={locationCode}/";
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri(apiUrl);
            request.Method = HttpMethod.Get;
            request.Headers.Add("key", Constants.Constants.APIKEY);

            // Call the API & wait for response.
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                // Read all of the response and deserialise it into an instace of
                // WeatherForecast class
                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<WeatherForecast>(content);
            }

            return null;
        }
    }
}
