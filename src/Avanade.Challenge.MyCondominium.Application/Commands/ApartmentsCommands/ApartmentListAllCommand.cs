using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Repositories;
using Microsoft.Extensions.Logging;
namespace Avanade.Challenge.MyCondominium.Application.Commands.ApartmentListAll
{
    public class ApartmentListAllCommand
    {
        protected readonly IApartmentRepository ApartmentRepository;
        public ILogger _logger { get; set; }

        public ApartmentListAllCommand(ILogger Logger,IApartmentRepository apartmentRepository)
        {
            this._logger = Logger;
            this.ApartmentRepository = apartmentRepository;
        }
        
        public async Task<IList<Apartment>> Execute()
        {
            try
            {
                var TaskUpdate = this.ApartmentRepository.GetAll();
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