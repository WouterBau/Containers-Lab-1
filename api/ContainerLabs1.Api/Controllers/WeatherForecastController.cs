using ContainerLabs1.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ContainerLabs1.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ILogTasks _logTasks;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ILogTasks logTasks)
    {
        _logger = logger;
        _logTasks = logTasks;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var lastLog = _logTasks.GetLastLogEntry();
        await _logTasks.AddLogEntry($"Requested forecast at {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm")}");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            LastMessage = lastLog?.Message
        })
        .ToArray();
    }
}
