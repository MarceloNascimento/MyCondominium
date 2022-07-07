using Microsoft.Extensions.Logging;
using Avanade.Challenge.MyCondominium.Infrastructure.CrossCutting.Interfaces.Repositories;
using Avanade.Challenge.MyCondominium.API.ViewModels;
using MediatR;

namespace Avanade.Challenge.MyCondominium.Application.Commands.ApartmentsCommand
{
    public class ApartmentDeleteCommand : IRequestHandler<ApartmentDeleteRequest, ApartmentDeletedViewModel>
    {
        protected readonly IApartmentRepository ApartmentRepository;
        private readonly ILogger _logger;

        public ApartmentDeleteCommand(ILogger logger, IApartmentRepository apartmentRepository)
        {
            _logger = logger;
            this.ApartmentRepository = apartmentRepository;
        }

        public async Task<ApartmentDeletedViewModel> IHandle(ApartmentDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var apartment = request.Id != 0 ? await this.ApartmentRepository.Get(request.Id) : null;
                if (apartment is null) return await Task.FromResult(new ApartmentDeletedViewModel());

                var TaskDelete = this.ApartmentRepository.Delete(apartment);
                return await TaskDelete;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing request from {nameof(IHandle)}", ex.Message);
                return return await Task.FromResult(new ApartmentDeletedViewModel());
            }
        }
    }
}