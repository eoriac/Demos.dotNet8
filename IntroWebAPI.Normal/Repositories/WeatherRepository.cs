
namespace IntroWebAPI.Normal;

public class WeatherRepository : IWeatherRepository
{
    private readonly List<WeatherForecast> weatherForecasts = new()
    {
        new WeatherForecast
        {
            Summary = "Freezing",
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(4)),
            TemperatureC = Random.Shared.Next(-20, 55),
        },
        new WeatherForecast
        {
            Summary = "Chilly",
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
            TemperatureC = Random.Shared.Next(-20, 55),
        }        
        //, "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public void AddWeatherForecast(WeatherForecast weatherForecast)
    {
        this.weatherForecasts.Add(weatherForecast);
    }

    public IList<WeatherForecast> GetWeatherForecasts()
    {
        return this.weatherForecasts;
    }
}
