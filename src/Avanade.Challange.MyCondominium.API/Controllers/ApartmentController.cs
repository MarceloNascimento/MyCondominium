using Avanade.Challange.MyCondominium.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Avanade.Challange.MyCondominium.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApartmentController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ApartmentController> _logger;

        public ApartmentController(ILogger<ApartmentController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<ApartmentViewModel> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new ApartmentViewModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}