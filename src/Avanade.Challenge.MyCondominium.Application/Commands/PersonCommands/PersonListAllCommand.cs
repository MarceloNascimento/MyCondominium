
using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Avanade.Challenge.MyCondominium.Application.Commands.PersonListAll
{
    public class PersonListAllCommand : ListCommand<IList<Person>>
    {
        protected readonly IPersonRepository PersonRepository;
        private readonly ILogger _logger;

        public PersonListAllCommand(ILogger logger, IPersonRepository personRepository)
        {
            this._logger = logger;
            this.PersonRepository = personRepository;
        }

        public override async Task<IList<Person>> Execute()
        {
            try
            {
                var TaskList = this.PersonRepository.GetAll();
                return await TaskList;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing request from {nameof(Execute)}", ex.Message);
                return await Task.FromResult(result: new List<Person>());
            }
        }
    }
}