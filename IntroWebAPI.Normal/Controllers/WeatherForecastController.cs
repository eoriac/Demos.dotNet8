using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace IntroWebAPI.Normal.Controllers;

[ApiController]
// [Route("[controller]")]
[Route("WeatherForecast")]
public class WeatherForecastController : ControllerBase
{
    // Debería obtenerse de una configuración
    const int MaxPageSize = 50;

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
    public ActionResult<WeatherForecastForCollectionDto> Get(string? location, string? queryPattern, string? orderBy, int pageNumber = 1, int pageSize = 5)
    {       
        //WeatherForecast
        this._logger.LogInformation("Getting weather forecasts");

        // 
        if (pageSize > MaxPageSize)
        {
            // pageSize = MaxPageSize;

            return BadRequest();
        }

        var weatherResults = this.weatherRepository.GetWeatherForecasts().ToList();

        if (string.IsNullOrWhiteSpace(location) == false)
        {
            weatherResults = weatherResults.Where(wt => 
            {
                // n instrucciones.
                return wt.Location == location;
            }).ToList();

            // weatherResults = this.weatherRepository.GetWeatherForecasts().Where(wt => wt.Location == location).ToList();
        }

        if (string.IsNullOrWhiteSpace(queryPattern) == false)
        {
            weatherResults = weatherResults.Where(wt => 
            {
                /*
                var queryLocation = string.Compare(wt.Location, queryPattern, StringComparison.InvariantCultureIgnoreCase) != 0;
                var querySummary = string.Compare(wt.Summary, queryPattern, StringComparison.InvariantCultureIgnoreCase) != 0;
                */

                var queryLocation = wt.Location.Contains(queryPattern, StringComparison.InvariantCultureIgnoreCase);
                var querySummary = wt.Summary?.Contains(queryPattern, StringComparison.InvariantCultureIgnoreCase) ?? false;

                return queryLocation || querySummary;
            }).ToList();

            // weatherResults = this.weatherRepository.GetWeatherForecasts().Where(wt => wt.Location == location).ToList();
        }

        if (string.IsNullOrWhiteSpace(orderBy) == false)
        {
            orderBy = orderBy.ToLower();

            weatherResults = weatherResults.OrderBy(wt => 
            {
                return orderBy switch
                {
                    "temperaturec" => wt.TemperatureC,
                    "location" => wt.Location,
                    "date" => wt.Date,
                    _ => (object)wt.Date,
                };
            }).ToList();
        }

        weatherResults = weatherResults
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToList();        

        var results = new WeatherForecastForCollectionDto()
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            // NextPageUrl = 
            Values = weatherResults
        };

        Response.Headers.TryAdd("X-PageNumber", pageNumber.ToString());
        Response.Headers.TryAdd("X-PageSize", pageSize.ToString());
        Response.Headers.TryAdd("X-NextPage", string.Empty);
        Response.Headers.TryAdd("X-PreviousPage", string.Empty);

        return Ok(results);
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
