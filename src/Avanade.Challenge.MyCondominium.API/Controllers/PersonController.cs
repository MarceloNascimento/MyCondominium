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
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Processing request from {nameof(Get)}");
            var request = new PersonListAllRequest() { };
            var viewModel = await Mediator.Send(request, cancellationToken);

            return Ok(viewModel);
        }

        [HttpPost(Name = "Post")]
        public async Task<IActionResult> Post(PersonSaveOrUpdateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Processing request from {nameof(Post)}");
            if (request.Id == 0)
            {
                var viewModel = await Mediator.Send(request, cancellationToken);
                return Ok(viewModel);
            }
            return BadRequest(request);
        }

        [HttpPut(Name = "Put")]
        public async Task<IActionResult> Put(PersonSaveOrUpdateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Processing request from {nameof(Put)}");
            if (request.Id > 0)
            {
                var viewModel = await Mediator.Send(request, cancellationToken);
                return Ok(viewModel);
            }

            return BadRequest(request);
        }

        [HttpDelete(Name = "Delete")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Processing request from {nameof(Delete)}");
            var request = new PersonDeletedViewModel(){Id = id};
            var viewModel = await Mediator.Send(request, cancellationToken);
            return Ok(viewModel);
        }
    }
}