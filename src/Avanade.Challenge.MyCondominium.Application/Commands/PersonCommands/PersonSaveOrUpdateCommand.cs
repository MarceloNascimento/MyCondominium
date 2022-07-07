using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Avanade.Challenge.MyCondominium.Application.Commands.PersonListAll
{
    public class PersonSaveOrUpdateCommand : SaveOrUpdateCommand<Person>
    {
        protected readonly IPersonRepository PersonRepository;
        private readonly ILogger _logger;

        public PersonSaveOrUpdateCommand(ILogger logger, IPersonRepository PersonRepository)
        {
            this._logger = logger;
            this.PersonRepository = PersonRepository;
        }

        public override async Task<Person?> Execute(Person param)
        {
            try
            {
                if (param is null) return await Task.FromResult(new Person());

                var TaskSaveOrUpdate = (param.Id != 0) ? this.PersonRepository.Insert(param)
                 : this.PersonRepository.Update(param);
                return await TaskSaveOrUpdate;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing request from {nameof(Execute)}", ex.Message);
                return await Task.FromResult(new Person());
            }
        }
    }
}