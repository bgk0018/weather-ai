using Domain.Weather;
using MediatR;

namespace Application.Weather.Queries;

public record GetWeatherMetricsQuery(string ZipCode) : IRequest<WeatherMetrics>;

public class GetWeatherMetricsQueryHandler : IRequestHandler<GetWeatherMetricsQuery, WeatherMetrics>
{
    private readonly IMemoryCache _cache;

    public GetWeatherMetricsQueryHandler(IMemoryCache cache)
    {
        _cache = cache;
    }

    public Task<WeatherMetrics> Handle(GetWeatherMetricsQuery request, CancellationToken cancellationToken)
    {
        if (_cache.TryGetValue<WeatherMetrics>(request.ZipCode, out var metrics))
        {
            return Task.FromResult(metrics);
        }

        return Task.FromResult(new WeatherMetrics { ZipCode = request.ZipCode });
    }
} 