using Domain.Weather;
using MediatR;
using Serilog;

namespace Application.Weather.Commands;

public record UpdateWeatherMetricsCommand(string ZipCode, WeatherMetrics Metrics) : IRequest;

public class UpdateWeatherMetricsCommandHandler : IRequestHandler<UpdateWeatherMetricsCommand>
{
    private readonly ILogger _logger;

    public UpdateWeatherMetricsCommandHandler(ILogger logger)
    {
        _logger = logger;
    }

    public Task Handle(UpdateWeatherMetricsCommand request, CancellationToken cancellationToken)
    {
        var metrics = request.Metrics;
        metrics.ZipCode = request.ZipCode;
        metrics.Timestamp = DateTime.UtcNow;

        _logger.Information(
            "Update request received for zip code {ZipCode}: Temperature: {Temperature}°F, Humidity: {Humidity}%, Precipitation: {Precipitation} inches",
            metrics.ZipCode,
            metrics.Temperature,
            metrics.Humidity,
            metrics.Precipitation);

        return Task.CompletedTask;
    }
} 