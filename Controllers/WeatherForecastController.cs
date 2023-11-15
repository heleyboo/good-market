using System.Reflection;
using GoodMarket.Queue;
using GoodMarket.Queue.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace GoodMarket.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IRabitMQProducer _rabitMQProducer;
    
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IRabitMQProducer rabitMQProducer)
    {
        _logger = logger;
        _rabitMQProducer = rabitMQProducer;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var res = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
        
        // ProduceMessage produceMessage = new ProduceMessage();
        // produceMessage.CreateMessage("Hello");
        
        _logger.LogInformation("WeatherForecastController Get - this is a nice message to test the logs", DateTime.UtcNow);
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var index =
            $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}";
        
        _logger.LogInformation(index);
        _rabitMQProducer.SendProductMessage(res);
        
        return res;
    }
}
