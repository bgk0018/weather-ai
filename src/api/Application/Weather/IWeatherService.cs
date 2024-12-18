using Domain.Weather;

namespace Application.Weather;

public interface IWeatherService
{
    Task<WeatherMetrics> GetWeatherMetricsAsync(string zipCode);
    Task UpdateWeatherMetricsAsync(string zipCode, WeatherMetrics metrics);
} 