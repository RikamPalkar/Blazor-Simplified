using DependencyInjectionDemo.Services.Interfaces;
using static DependencyInjectionDemo.Pages.Weather;
using System.Net.Http.Json;

namespace DependencyInjectionDemo.Services
{
    public class WeatherService(HttpClient httpClient) : IWeatherService
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<WeatherForecast[]> GetWeatherForecastsAsync()
        {
            return await _httpClient.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        }
    }

    public class WeatherForecast
    {
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
