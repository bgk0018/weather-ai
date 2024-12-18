namespace Domain.Weather;

public class WeatherMetrics
{
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public double Precipitation { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string ZipCode { get; set; } = string.Empty;
} 