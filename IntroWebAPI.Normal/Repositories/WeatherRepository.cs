
namespace IntroWebAPI.Normal;

public class WeatherRepository : IWeatherRepository
{
    private readonly Dictionary<Guid, WeatherForecast> weatherForecasts = new()
    {
        {
            Guid.Parse("2e648dae-7e7d-4289-a5d4-4dedca70ca8d"), 
            new WeatherForecast
                {
                    Id = Guid.Parse("2e648dae-7e7d-4289-a5d4-4dedca70ca8d"),
                    Location = "Madrid",
                    Summary = "Freezing",
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(4)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                }
        },
        { 
            Guid.Parse("f011e50e-98eb-4f8c-90c8-cd2dfbd5b27a"),
            new WeatherForecast
            {
                Id = Guid.Parse("f011e50e-98eb-4f8c-90c8-cd2dfbd5b27a"),
                Location = "Valencia",
                Summary = "Chilly",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                TemperatureC = Random.Shared.Next(-20, 55),
            }
        }
        //, "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public void AddWeatherForecast(WeatherForecast weatherForecast)
    {
        this.weatherForecasts.Add(weatherForecast.Id, weatherForecast);
    }

    public void Delete(WeatherForecast weatherForecast)
    {
        this.weatherForecasts.Remove(weatherForecast.Id);
    }

    public WeatherForecast GetWeatherForecast(Guid id)
    {
        this.weatherForecasts.TryGetValue(id, out var result);

        return result;
    }

    public IList<WeatherForecast> GetWeatherForecasts()
    {
        return this.weatherForecasts.Values.ToList();
    }

    public void UpdateWeatherForecast(WeatherForecast weatherForecastEntity)
    {
        this.weatherForecasts[weatherForecastEntity.Id] = weatherForecastEntity;
    }
}
