using MediatR;
using Microsoft.Extensions.Logging;
using Avanade.Challenge.MyCondominium.API.ViewModels;
using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Interfaces.Repositories;

namespace Avanade.Challenge.MyCondominium.Application.Commands.PersonListAll
{
    public class PersonDeleteCommand : IRequestHandler<PersonDeleteRequest, PersonDeletedViewModel>
    {
        protected readonly IPersonRepository PersonRepository;
        private readonly ILogger _logger;

        public PersonDeleteCommand(ILogger logger, IPersonRepository PersonRepository)
        {
            this._logger = logger;
            this.PersonRepository = PersonRepository;
        }

         public async Task<PersonDeletedViewModel> Handle(PersonDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null || request.Id is 0) { return await Task.FromResult(result: new PersonDeletedViewModel()); }

                var person = request.Id != 0 ? await this.PersonRepository.Get(request.Id) : new Person();
                var TaskDelete = this.PersonRepository.Delete(person);

                return new PersonDeletedViewModel() { IsDeleted = await TaskDelete };

            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing request from {nameof(Handle)}", ex.Message);
                return await Task.FromResult(new PersonDeletedViewModel());
            }
        }
    }
}