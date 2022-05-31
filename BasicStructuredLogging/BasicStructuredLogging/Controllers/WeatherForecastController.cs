using Microsoft.AspNetCore.Mvc;

namespace BasicStructuredLogging.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    [Route("Forecast")]
    public IEnumerable<WeatherForecast> GetForecasts()
    {
        _logger.LogInformation("Executing {MethodCalled} at {ExecutionTime}", 
            "GetForecast", DateTime.Now);
        _logger.LogInformation("Something else...");
        
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
    
    [HttpGet()]
    [Route("Forecast/{id}")]
    public WeatherForecast GetForecast(string id)
    {
        _logger.LogInformation("Executing {MethodCalled} at {ExecutionTime}", 
            "GetForecast/id", DateTime.Now);
        _logger.LogInformation("Input id: {ID}", id);
        
        return new WeatherForecast 
        {
            Date = DateTime.Now,
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)] 
        };
    }
}