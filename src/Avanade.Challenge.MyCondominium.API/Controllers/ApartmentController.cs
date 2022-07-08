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
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Processing request from {nameof(GetAsync)}");
            var request = new ApartmentListAllRequest() { };
            var viewModel = await Mediator.Send(request, cancellationToken);

            return Ok(viewModel);
        }

        [HttpPost(Name = "Post")]
        public async Task<IActionResult> PostAsync(ApartmentSaveOrUpdateRequest request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> PutAsync(ApartmentSaveOrUpdateRequest request, CancellationToken cancellationToken)
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
            var request = new ApartmentDeletedViewModel(){Id = id};
            var viewModel = await Mediator.Send(request, cancellationToken);
            return Ok(viewModel);
        }
    }
}