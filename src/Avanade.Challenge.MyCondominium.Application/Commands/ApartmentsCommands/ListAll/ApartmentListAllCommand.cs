using Microsoft.Extensions.Logging;
using MediatR;
using Avanade.Challenge.MyCondominium.API.ViewModels;
using Avanade.Challenge.MyCondominium.Domain.Interfaces.Repositories;

namespace Avanade.Challenge.MyCondominium.Application.Commands.ApartmentListAll
{
    public class ApartmentListAllCommand : IRequestHandler<ApartmentListAllRequest, ApartmentListAllViewModel>
    {
        protected readonly IApartmentRepository ApartmentRepository;
        protected ILogger _logger { get; set; }

        public ApartmentListAllCommand(ILogger logger, IApartmentRepository apartmentRepository)
        {
            this._logger = logger;
            this.ApartmentRepository = apartmentRepository;
        }

        public async Task<ApartmentListAllViewModel?> Handle(ApartmentListAllRequest request
            , CancellationToken cancellationToken)
        {
            try
            {
                var entitiesTaskList = this.ApartmentRepository.GetAllAsync(cancellationToken);
                var apartmentsViewModels = new ApartmentListAllViewModel
                {
                    ApartmentDTOs = new List<ApartmentListAllDto>()
                };


                if (entitiesTaskList == null) return null;

                apartmentsViewModels.ApartmentDTOs = (await entitiesTaskList)
                    .Select(item => new ApartmentListAllDto()
                {
                    Id = item.Id,
                    Name = item?.Name,
                    Block = item?.Block,
                    Floor = item?.Floor,
                    Created = item?.Created
                }).ToList();

                return await Task.FromResult(apartmentsViewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing request from {nameof(Handle)}", ex.Message);
                return await Task.FromResult(result: new ApartmentListAllViewModel());
            }
        }
    }
}