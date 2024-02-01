namespace IntroWebAPI.Normal;

public interface IWeatherRepository
{
    IList<WeatherForecast> GetWeatherForecasts();

    void AddWeatherForecast(WeatherForecast weatherForecast);
}
