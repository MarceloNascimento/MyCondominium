using Microsoft.Extensions.Logging;
using MediatR;
using Avanade.Challenge.MyCondominium.API.ViewModels;
using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Interfaces.Repositories;

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

        public async Task<ApartmentDeletedViewModel> Handle(ApartmentDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null || request.Id is 0) { return await Task.FromResult(result: new ApartmentDeletedViewModel()); }

                var apartment = await this.ApartmentRepository.GetAsync(request.Id, cancellationToken);
                if (apartment != null)
                {
                    var TaskDelete = this.ApartmentRepository.DeleteAsync(apartment, cancellationToken);
                    return new ApartmentDeletedViewModel() { IsDeleted = await TaskDelete };
                }
                return new ApartmentDeletedViewModel() { IsDeleted = false };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing request from {nameof(Handle)}", ex.Message);
                return await Task.FromResult(new ApartmentDeletedViewModel());
            }
        }
    }
}