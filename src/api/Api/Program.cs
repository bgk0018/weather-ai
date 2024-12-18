using Application.Weather;
using Domain.Weather;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Weather endpoints
app.MapGet("/api/weather/{zipCode}", async (string zipCode, IWeatherService weatherService) =>
{
    var metrics = await weatherService.GetWeatherMetricsAsync(zipCode);
    return Results.Ok(metrics);
})
.WithName("GetWeatherByZipCode")
.WithOpenApi();

app.MapPost("/api/weather/{zipCode}/metrics", async (string zipCode, WeatherMetrics metrics, IWeatherService weatherService) =>
{
    await weatherService.UpdateWeatherMetricsAsync(zipCode, metrics);
    return Results.NoContent();
})
.WithName("UpdateWeatherMetrics")
.WithOpenApi();

app.Run();
