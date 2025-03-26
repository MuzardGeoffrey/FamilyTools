using EasyCompta.Server.IBusiness;
using EasyCompta.Server.Model;

using Microsoft.AspNetCore.Mvc;

namespace FamilyTools.EasyCompta.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
//    private static readonly string[] Summaries = new[]
//    {
//        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//    };

//    private readonly ILogger<WeatherForecastController> _logger;

//    public WeatherForecastController(ILogger<WeatherForecastController> logger)
//    {
//        _logger = logger;
//    }

//    [HttpGet(Name = "GetWeatherForecast")]
//    public IEnumerable<WeatherForecast> Get()
//    {
//        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//        {
//            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            TemperatureC = Random.Shared.Next(-20, 55),
//            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//        })
//        .ToArray();
//    }

//    app.MapGet(DEFAULT_ROUTE, async (IAccountPageBusiness business) =>
//{
//    var result = await business.GetPageByDate(DateTime.Now);
//    return result;
//});

//app.MapPost($"{DEFAULT_ROUTE}/line", async(IAccountLineBusiness business, AccountLine line) =>
//{
//    var result = await business.Create(line);
//    return result;
//});
}
