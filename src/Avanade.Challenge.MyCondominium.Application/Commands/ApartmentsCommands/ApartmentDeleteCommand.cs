using Microsoft.Extensions.Logging;
using Avanade.Challenge.MyCondominium.Infrastructure.CrossCutting.Interfaces.Repositories;

namespace Avanade.Challenge.MyCondominium.Application.Commands.ApartmentsCommand
{
    public class ApartmentDeleteCommand
    {
        private readonly ILogger _logger;
        protected readonly IApartmentRepository ApartmentRepository;

        public ApartmentDeleteCommand(ILogger logger, IApartmentRepository apartmentRepository)
        {
            _logger = logger;
            this.ApartmentRepository = apartmentRepository;
        }

        public async Task<bool> Execute(int id)
        {
            try
            {
                var apartment = await this.ApartmentRepository.Get(id);

                if (apartment is null) return await Task.FromResult(false);

                var TaskDelete = this.ApartmentRepository.Delete(apartment);

                return await TaskDelete;
            }
            catch (Exception ex)
            {   
                _logger.LogError("Processing request from {ApartmentDeleteCommand}", ex.Message);                
                return await Task.FromResult(false);
            }
        }
    }
}