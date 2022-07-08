using Avanade.Challenge.MyCondominium.API.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avanade.Challenge.MyCondominium.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApartmentController : ControllerBase
    {
        private readonly IMediator Mediator;
        private readonly ILogger<ApartmentController> _logger;

        public ApartmentController(IMediator mediator, ILogger<ApartmentController> logger)
        {
            Mediator = mediator;
            _logger = logger;
        }

        [HttpGet(Name = "Get")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Processing request from {nameof(Get)}");
            var request = new ApartmentListAllRequest() { };
            var viewModel = await Mediator.Send(request, cancellationToken);

            return Ok(viewModel);
        }

        [HttpPost(Name = "Post")]
        public async Task<IActionResult> Post(ApartmentSaveOrUpdateRequest request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> Put(ApartmentSaveOrUpdateRequest request, CancellationToken cancellationToken)
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
            var request = new ApartmentDeletedViewModel(){Id = id};
            var viewModel = await Mediator.Send(request, cancellationToken);
            return Ok(viewModel);
        }
    }
}