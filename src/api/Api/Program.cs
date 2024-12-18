using Application.Weather.Commands;
using Application.Weather.Queries;
using Domain.Weather;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetWeatherMetricsQuery).Assembly));
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
app.MapGet("/api/weather/{zipCode}", async (string zipCode, IMediator mediator) =>
{
    var query = new GetWeatherMetricsQuery(zipCode);
    var result = await mediator.Send(query);
    return Results.Ok(result);
})
.WithName("GetWeatherByZipCode")
.WithOpenApi();

app.MapPost("/api/weather/{zipCode}/metrics", async (string zipCode, WeatherMetrics metrics, IMediator mediator) =>
{
    var command = new UpdateWeatherMetricsCommand(zipCode, metrics);
    await mediator.Send(command);
    return Results.NoContent();
})
.WithName("UpdateWeatherMetrics")
.WithOpenApi();

app.Run();
