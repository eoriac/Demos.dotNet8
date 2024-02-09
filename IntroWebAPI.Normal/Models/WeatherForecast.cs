using System.ComponentModel.DataAnnotations.Schema;

namespace IntroWebAPI.Normal;

public class WeatherForecast
{
    public Guid Id { get; set; }

    public string? Location { get; set; } = null!;

    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    [NotMapped]
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; } = null!;

    public Guid CityId { get; set; }
}

public class City
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public string? Description { get; set; } = null!;
}
