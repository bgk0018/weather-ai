using Domain.Weather;
using MediatR;

namespace Application.Weather.Queries;

public record GetWeatherMetricsQuery(string ZipCode) : IRequest<WeatherMetrics>;

public class GetWeatherMetricsQueryHandler : IRequestHandler<GetWeatherMetricsQuery, WeatherMetrics>
{
    private static readonly Dictionary<string, WeatherMetrics> StaticData = new()
    {
        ["12345"] = new WeatherMetrics 
        { 
            ZipCode = "12345",
            Temperature = 72.5,
            Humidity = 45.0,
            Precipitation = 0.0,
            Timestamp = DateTime.UtcNow
        },
        ["94105"] = new WeatherMetrics 
        { 
            ZipCode = "94105",
            Temperature = 65.2,
            Humidity = 75.0,
            Precipitation = 0.2,
            Timestamp = DateTime.UtcNow
        },
        ["10001"] = new WeatherMetrics 
        { 
            ZipCode = "10001",
            Temperature = 68.0,
            Humidity = 60.0,
            Precipitation = 0.1,
            Timestamp = DateTime.UtcNow
        }
    };

    public Task<WeatherMetrics> Handle(GetWeatherMetricsQuery request, CancellationToken cancellationToken)
    {
        if (StaticData.TryGetValue(request.ZipCode, out var metrics))
        {
            return Task.FromResult(metrics);
        }

        // Return default metrics for unknown zip codes
        return Task.FromResult(new WeatherMetrics 
        { 
            ZipCode = request.ZipCode,
            Temperature = 70.0,
            Humidity = 50.0,
            Precipitation = 0.0,
            Timestamp = DateTime.UtcNow
        });
    }
} 