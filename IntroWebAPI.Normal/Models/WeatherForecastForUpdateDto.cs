namespace IntroWebAPI.Normal;

public class WeatherForecastForUpdateDto
{
    public string Location { get; set; }

    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }
}
