using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Avanade.Challenge.MyCondominium.Application.Commands.PersonListAll
{
    public class PersonDeleteCommand : DeleteCommand<bool>
    {
        protected readonly IPersonRepository PersonRepository;
        private readonly ILogger _logger;

        public PersonDeleteCommand(ILogger logger, IPersonRepository PersonRepository)
        {
            this._logger = logger;
            this.PersonRepository = PersonRepository;
        }

        public override async Task<bool> Execute(int id)
        {
            try
            {
                var person = id != 0 ? await this.PersonRepository.Get(id) : null;
                if (person is null) return await Task.FromResult(false);

                var TaskDelete = this.PersonRepository.Delete(person);
                return await TaskDelete;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing request from {nameof(Execute)}", ex.Message);
                return await Task.FromResult(false);
            }
        }
    }
}