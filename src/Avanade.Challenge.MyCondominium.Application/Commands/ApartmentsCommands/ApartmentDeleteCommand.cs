using Avanade.Challenge.MyCondominium.Domain.Entities;
using Microsoft.Extensions.Logging;
using Avanade.Challenge.MyCondominium.Infrastructure.CrossCutting.Interfaces.Repositories;

namespace Avanade.Challenge.MyCondominium.Application.Commands.ApartmentsCommand
{
    public class ApartmentDeleteCommand : DeleteCommand<bool>
    {
        protected readonly IApartmentRepository ApartmentRepository;
        private readonly ILogger _logger;

        public ApartmentDeleteCommand(ILogger logger, IApartmentRepository apartmentRepository)
        {
            _logger = logger;
            this.ApartmentRepository = apartmentRepository;
        }

        public override async Task<bool> Execute(int id)
        {
            try
            {
                var apartment = id != 0 ? await this.ApartmentRepository.Get(id) : null;
                if (apartment is null) return await Task.FromResult(false);

                var TaskDelete = this.ApartmentRepository.Delete(apartment);
                return await TaskDelete;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing request from {nameof(Execute)}", ex.Message);
                return await Task.FromResult(false);
            }
        }
    }
}