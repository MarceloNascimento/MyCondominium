using Microsoft.Extensions.Logging;
using MediatR;
using Avanade.Challenge.MyCondominium.API.ViewModels;
using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Interfaces.Repositories;

namespace Avanade.Challenge.MyCondominium.Application.Commands.ApartmentInsert
{
    public class ApartmentSaveOrUpdateCommand : IRequestHandler<ApartmentSaveOrUpdateRequest, ApartmentSaveOrUpdateViewModel>
    {
        protected readonly IApartmentRepository ApartmentRepository;
        private readonly ILogger _logger;

        public ApartmentSaveOrUpdateCommand(ILogger Logger, IApartmentRepository apartmentRepository)
        {
            this._logger = Logger;
            this.ApartmentRepository = apartmentRepository;
        }

        public async Task<ApartmentSaveOrUpdateViewModel> Handle(ApartmentSaveOrUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null) return await Task.FromResult(new ApartmentSaveOrUpdateViewModel());
                var entity = new Apartment()
                {
                    Id = request.Id,
                    Name = request.Name,
                    Block = request.Block,
                    Floor = request.Floor,
                    Created = DateTime.UtcNow
                };

                var TaskSaveOrUpdate = (entity.Id != 0) ? this.ApartmentRepository.InsertAsync(entity, cancellationToken)
                 : this.ApartmentRepository.UpdateAsync(entity, cancellationToken);

                var result = await TaskSaveOrUpdate;
                var viewModel = new ApartmentSaveOrUpdateViewModel()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Block = result.Block,
                    Floor = result.Floor,
                    Created = result.Created
                };

                return await Task.FromResult(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing result from {nameof(Handle)}", ex.Message);
                return await Task.FromResult(result: new ApartmentSaveOrUpdateViewModel());
            }
        }
    }
}