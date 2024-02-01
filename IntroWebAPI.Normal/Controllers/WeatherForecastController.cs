using Microsoft.AspNetCore.Mvc;

namespace IntroWebAPI.Normal.Controllers;

[ApiController]
// [Route("[controller]")]
[Route("WeatherForecast")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherRepository weatherRepository;
    private readonly INotificationService notificationService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, 
    IWeatherRepository weatherRepository,
    INotificationService notificationService)
    {
        _logger = logger;
        this.weatherRepository = weatherRepository;
        this.notificationService = notificationService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {       
        this._logger.LogInformation("Getting weather forecasts");

        this.notificationService.Notify("some message");

        return this.weatherRepository.GetWeatherForecasts();
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        this._logger.LogInformation("Create weather forecast");

        this._logger.LogDebug($"Create Weather Forecast {weatherForecast}");

        this.weatherRepository.AddWeatherForecast(weatherForecast);

        return Ok();
    }
}
