using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Avanade.Challenge.MyCondominium.Application.Commands.ApartmentEdit
{
    public class ApartmentEditCommand
    {
        protected readonly IApartmentRepository ApartmentRepository;
        private ILogger _logger;

        public ApartmentEditCommand(ILogger Logger, IApartmentRepository apartmentRepository)
        {
            _logger = Logger;
            this.ApartmentRepository = apartmentRepository;
        }
        public async Task<Apartment?> Execute(Apartment? apartment)
        {
            try
            {
                if (apartment is null) return null;

                var TaskUpdate = this.ApartmentRepository.Update(apartment);
                return await TaskUpdate;
            }
            catch (Exception ex)
            {
                _logger.LogError("Processing request from {ApartmentDeleteCommand}", ex.Message);
                return null;
            }
        }
    }
}