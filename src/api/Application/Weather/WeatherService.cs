using Domain.Weather;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Weather;

public class WeatherService : IWeatherService
{
    private readonly IMemoryCache _cache;

    public WeatherService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public async Task<WeatherMetrics> GetWeatherMetricsAsync(string zipCode)
    {
        if (_cache.TryGetValue<WeatherMetrics>(zipCode, out var metrics))
        {
            return metrics;
        }

        // Return empty metrics if none exist
        return new WeatherMetrics { ZipCode = zipCode };
    }

    public async Task UpdateWeatherMetricsAsync(string zipCode, WeatherMetrics metrics)
    {
        metrics.ZipCode = zipCode;
        metrics.Timestamp = DateTime.UtcNow;
        
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromHours(1));

        _cache.Set(zipCode, metrics, cacheOptions);
    }
} 