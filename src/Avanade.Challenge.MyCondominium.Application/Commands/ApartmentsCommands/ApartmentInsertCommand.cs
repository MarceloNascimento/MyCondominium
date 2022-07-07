using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Avanade.Challenge.MyCondominium.Application.Commands.ApartmentInsert
{
    public class ApartmentInsertCommand
    {
        protected readonly IApartmentRepository ApartmentRepository;
        public ILogger _logger { get; }

        public ApartmentInsertCommand(ILogger Logger, IApartmentRepository apartmentRepository)
        {
            this._logger = Logger;
            this.ApartmentRepository = apartmentRepository;
        }

        public async Task<Apartment> Execute(Apartment apartment)
        {
            try
            {
                if (apartment is null) return null;

                var TaskUpdate = this.ApartmentRepository.Insert(apartment);
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