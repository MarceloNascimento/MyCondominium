using Avanade.Challenge.MyCondominium.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Avanade.Challenge.MyCondominium.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPersonViewModel")]
        public IEnumerable<PersonViewModel> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new PersonViewModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost(Name = "PostPersonViewModel")]
        public IEnumerable<PersonViewModel> Post(PersonViewModel person)
        {
            return Enumerable.Range(1, 5).Select(index => new PersonViewModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPut(Name = "PutPersonViewModel")]
        public IEnumerable<PersonViewModel> Put(PersonViewModel person)
        {
            return Enumerable.Range(1, 5).Select(index => new PersonViewModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpDelete(Name = "DeletePersonViewModel")]
        public IEnumerable<PersonViewModel> Delete(int id)
        {
            return Enumerable.Range(1, 5).Select(index => new PersonViewModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}