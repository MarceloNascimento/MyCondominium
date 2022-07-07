using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Avanade.Challenge.MyCondominium.Application.Commands.ApartmentInsert
{
    public class ApartmentSaveOrUpdateCommand : SaveOrUpdateCommand<Apartment>
    {
        protected readonly IApartmentRepository ApartmentRepository;
        private readonly ILogger _logger;

        public ApartmentSaveOrUpdateCommand(ILogger Logger, IApartmentRepository apartmentRepository)
        {
            this._logger = Logger;
            this.ApartmentRepository = apartmentRepository;
        }

        public override async Task<Apartment> Execute(Apartment param)
        {
            try
            {
                if (param is null) return await Task.FromResult(new Apartment());

                var TaskSaveOrUpdate = (param.Id != 0) ? this.ApartmentRepository.Insert(param)
                 : this.ApartmentRepository.Update(param);
                return await TaskSaveOrUpdate;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing request from {nameof(Execute)}", ex.Message);
                return await Task.FromResult(new Apartment());
            }
        }
    }
}