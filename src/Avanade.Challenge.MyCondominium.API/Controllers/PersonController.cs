using Avanade.Challenge.MyCondominium.API.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avanade.Challenge.MyCondominium.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator Mediator;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IMediator mediator, ILogger<PersonController> logger)
        {
            Mediator = mediator;
            _logger = logger;
        }

        [HttpGet(Name = "Get")]
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

        [HttpPost(Name = "Post")]
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

        [HttpPut(Name = "Put")]
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

        [HttpDelete(Name = "Delete")]
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