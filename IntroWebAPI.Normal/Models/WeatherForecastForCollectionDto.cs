namespace IntroWebAPI.Normal;

public class WeatherForecastForCollectionDto
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public IEnumerable<WeatherForecast> Values { get; set; } = [];

    public string NextPageUrl { get; set; } = null!;

    public string PreviousPageUrl { get; set; } = null!;
}
