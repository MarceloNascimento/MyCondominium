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
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Processing request from {nameof(GetAsync)}");
            var request = new PersonListAllRequest() { };
            var viewModel = await Mediator.Send(request, cancellationToken);

            return Ok(viewModel);
        }

        [HttpPost(Name = "Post")]
        public async Task<IActionResult> PostAsync(PersonSaveOrUpdateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Processing request from {nameof(PostAsync)}");
            if (request.Id == 0)
            {
                var viewModel = await Mediator.Send(request, cancellationToken);
                return Ok(viewModel);
            }
            return BadRequest(request);
        }

        [HttpPut(Name = "Put")]
        public async Task<IActionResult> PutAsync(PersonSaveOrUpdateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Processing request from {nameof(PutAsync)}");
            if (request.Id > 0)
            {
                var viewModel = await Mediator.Send(request, cancellationToken);
                return Ok(viewModel);
            }

            return BadRequest(request);
        }

        [HttpDelete(Name = "Delete")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Processing request from {nameof(DeleteAsync)}");
            var request = new PersonDeletedViewModel(){Id = id};
            var viewModel = await Mediator.Send(request, cancellationToken);
            return Ok(viewModel);
        }
    }
}