using Domain.Weather;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Weather.Commands;

public record UpdateWeatherMetricsCommand(string ZipCode, WeatherMetrics Metrics) : IRequest;

public class UpdateWeatherMetricsCommandHandler : IRequestHandler<UpdateWeatherMetricsCommand>
{
    private readonly IMemoryCache _cache;

    public UpdateWeatherMetricsCommandHandler(IMemoryCache cache)
    {
        _cache = cache;
    }

    public Task Handle(UpdateWeatherMetricsCommand request, CancellationToken cancellationToken)
    {
        var metrics = request.Metrics;
        metrics.ZipCode = request.ZipCode;
        metrics.Timestamp = DateTime.UtcNow;

        var cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromHours(1));

        _cache.Set(request.ZipCode, metrics, cacheOptions);

        return Task.CompletedTask;
    }
} 