using Avanade.Challenge.MyCondominium.API.ViewModels;
using Avanade.Challenge.MyCondominium.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Avanade.Challenge.MyCondominium.Application.Commands.PersonListAll
{
    public class PersonListAllCommand : IRequestHandler<PersonListAllRequest, PersonListAllViewModel>
    {
        protected readonly IPersonRepository PersonRepository;
        private readonly ILogger _logger;

        public PersonListAllCommand(ILogger logger, IPersonRepository personRepository)
        {
            this._logger = logger;
            this.PersonRepository = personRepository;
        }

        public async Task<PersonListAllViewModel> Handle(PersonListAllRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entitiesTaskList = this.PersonRepository.GetAllAsync(cancellationToken);
                var PersonsViewModels = new PersonListAllViewModel
                {
                    PersonDTOs = new List<PersonListAllDto>()
                };

                PersonsViewModels.PersonDTOs = (await entitiesTaskList).Select(item => new PersonListAllDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Block = item.Apartment.Block,
                    Floor = item.Apartment.Floor,
                    Created = item.Created
                }).ToList();

                return await Task.FromResult(PersonsViewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing request from {nameof(Handle)}", ex.Message);
                return await Task.FromResult(result: new PersonListAllViewModel());
            }
        }
    }
}