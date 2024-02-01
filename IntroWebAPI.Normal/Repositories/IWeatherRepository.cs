
namespace IntroWebAPI.Normal;

public interface IWeatherRepository
{
    IList<WeatherForecast> GetWeatherForecasts();

    void AddWeatherForecast(WeatherForecast weatherForecast);

    WeatherForecast GetWeatherForecast(Guid id);

    void Delete(WeatherForecast weatherForecast);
    
    void UpdateWeatherForecast(WeatherForecast weatherForecastEntity);
}
