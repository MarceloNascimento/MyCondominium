using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Avanade.Challenge.MyCondominium.Application.Commands.ApartmentListAll
{
    public class ApartmentListAllCommand : ListCommand<IList<Apartment>>
    {
        protected readonly IApartmentRepository ApartmentRepository;
        public ILogger _logger { get; set; }

        public ApartmentListAllCommand(ILogger Logger, IApartmentRepository apartmentRepository)
        {
            this._logger = Logger;
            this.ApartmentRepository = apartmentRepository;
        }

        public override async Task<IList<Apartment>> Execute()
        {
            try
            {
                var TaskList = this.ApartmentRepository.GetAll();
                return await TaskList;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing request from {nameof(Execute)}", ex.Message);
                return await Task.FromResult(result: new List<Apartment>());
            }
        }
    }
}