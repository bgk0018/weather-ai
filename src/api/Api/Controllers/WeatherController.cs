using Microsoft.AspNetCore.Mvc;
using Application.Weather;
using Domain.Weather;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet("{zipCode}")]
    public async Task<ActionResult<WeatherMetrics>> GetWeatherByZipCode(string zipCode)
    {
        var metrics = await _weatherService.GetWeatherMetricsAsync(zipCode);
        return Ok(metrics);
    }

    [HttpPost("{zipCode}/metrics")]
    public async Task<ActionResult> UpdateWeatherMetrics(string zipCode, [FromBody] WeatherMetrics metrics)
    {
        await _weatherService.UpdateWeatherMetricsAsync(zipCode, metrics);
        return NoContent();
    }
} 