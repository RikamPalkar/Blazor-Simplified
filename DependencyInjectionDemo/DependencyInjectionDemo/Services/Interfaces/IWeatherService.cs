using static DependencyInjectionDemo.Pages.Weather;

namespace DependencyInjectionDemo.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherForecast[]> GetWeatherForecastsAsync();
    }
}
