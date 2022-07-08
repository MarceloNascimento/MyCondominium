using Avanade.Challenge.MyCondominium.API.ViewModels;
using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
namespace Avanade.Challenge.MyCondominium.Application.Commands.PersonListAll
{
    public class PersonSaveOrUpdateCommand : IRequestHandler<PersonSaveOrUpdateRequest, PersonSaveOrUpdateViewModel>
    {
        protected readonly IPersonRepository PersonRepository;
        protected readonly IApartmentRepository ApartmentRepository;
        private readonly ILogger _logger;

        public PersonSaveOrUpdateCommand(ILogger logger, IPersonRepository personRepository, IApartmentRepository apartmentRepository)
        {
            this._logger = logger;
            this.PersonRepository = personRepository;
            this.ApartmentRepository = apartmentRepository;
        }

        public async Task<PersonSaveOrUpdateViewModel> Handle(PersonSaveOrUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null) return await Task.FromResult(new PersonSaveOrUpdateViewModel());

                var apartment = await ApartmentRepository.GetAsync(request.ApartmentId, cancellationToken);
                var entity = new Person()
                {
                    Id = request.Id,
                    Name = request.Name,
                    IsResident = request.IsResident,
                    CondominiumFee = request.CondominiumFee,
                    Apartment = apartment ?? new Apartment() { Id = request.ApartmentId },
                    Block = request.Block,
                    Created = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                };

                var TaskSaveOrUpdate = (entity.Id != 0) ? this.PersonRepository.InsertAsync(entity, cancellationToken)
                 : this.PersonRepository.UpdateAsync(entity, cancellationToken);

                var result = await TaskSaveOrUpdate;
                var viewModel = new PersonSaveOrUpdateViewModel()
                {
                    Id = result.Id,
                    Name = result.Name,
                    IsResident = result.IsResident,
                    CondominiumFee = result.CondominiumFee
                };

                return await Task.FromResult(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing result from {nameof(Handle)}", ex.Message);
                return await Task.FromResult(result: new PersonSaveOrUpdateViewModel());
            }
        }
    }
}