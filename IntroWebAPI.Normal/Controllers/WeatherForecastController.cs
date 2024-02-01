using Microsoft.AspNetCore.JsonPatch;
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

    [HttpGet(Name = "GetWeatherForecasts")]
    public ActionResult<IEnumerable<WeatherForecast>> Get()
    {       
        //WeatherForecast
        this._logger.LogInformation("Getting weather forecasts");        

        return Ok(this.weatherRepository.GetWeatherForecasts());
    }

    [HttpGet("{id}", Name = "GetWeatherForecast")]
    public ActionResult<WeatherForecast> Get([FromRoute]Guid id)
    {       
        //WeatherForecast/<id>
        this._logger.LogInformation("Getting weather forecasts");

        var weatherForecast = this.weatherRepository.GetWeatherForecast(id);

        if(weatherForecast == null){
            return NotFound();
        }

        return Ok(weatherForecast);
    }    

    [HttpPost]
    public IActionResult Post([FromBody]WeatherForecastForCreationDto weatherForecast)
    {
        this._logger.LogInformation("Create weather forecast");

        this._logger.LogDebug($"Create Weather Forecast {weatherForecast}");

        var weatherForecastEntity = new WeatherForecast()
        {
            Id = Guid.NewGuid(),
            Location = weatherForecast.Location,
            TemperatureC = weatherForecast.TemperatureC,
            Date = weatherForecast.Date,
            Summary = weatherForecast.Summary
        };

        this.weatherRepository.AddWeatherForecast(weatherForecastEntity);

        return CreatedAtRoute(
            "GetWeatherForecast", 
            new { id = weatherForecastEntity.Id}, 
            weatherForecastEntity);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {        
        //WeatherForecast/<id>
        var weatherForecast = this.weatherRepository.GetWeatherForecast(id);

        if (weatherForecast == null)
        {
            return NotFound();
        }

        this.weatherRepository.Delete(weatherForecast);

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody]WeatherForecastForUpdateDto weatherForecastForUpdate)
    {
        var weatherForecastEntity = this.weatherRepository.GetWeatherForecast(id);

        if (weatherForecastEntity == null)
        {
            return NotFound();
        }

        weatherForecastEntity.Location = weatherForecastForUpdate.Location;
        weatherForecastEntity.TemperatureC = weatherForecastForUpdate.TemperatureC;
        weatherForecastEntity.Date = weatherForecastForUpdate.Date;
        weatherForecastEntity.Summary = weatherForecastForUpdate.Summary;

        this.weatherRepository.UpdateWeatherForecast(weatherForecastEntity);

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(Guid id, [FromBody]JsonPatchDocument<WeatherForecastForUpdateDto> patchDocument)
    {
        var weatherForecastEntity = this.weatherRepository.GetWeatherForecast(id);

        if (weatherForecastEntity == null)
        {
            return NotFound();
        }

        var weatherForecastForUpdate = new WeatherForecastForUpdateDto()
        {
            Location = weatherForecastEntity.Location,
            TemperatureC = weatherForecastEntity.TemperatureC,
            Summary = weatherForecastEntity.Summary,
            Date = weatherForecastEntity.Date
        };

        patchDocument.ApplyTo(weatherForecastForUpdate, ModelState);

        if (ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }

        if(TryValidateModel(weatherForecastForUpdate) == false)
        {
            return BadRequest(ModelState);
        }

        weatherForecastEntity.Location = weatherForecastForUpdate.Location;
        weatherForecastEntity.TemperatureC = weatherForecastForUpdate.TemperatureC;
        weatherForecastEntity.Date = weatherForecastForUpdate.Date;
        weatherForecastEntity.Summary = weatherForecastForUpdate.Summary;

        this.weatherRepository.UpdateWeatherForecast(weatherForecastEntity);

        return NoContent();
    }
}
