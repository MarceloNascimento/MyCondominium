
using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Repositories;

namespace Avanade.Challenge.MyCondominium.Application.Commands.PersonListAll
{
    public class PersonDeleteCommand
    {
        protected readonly IPersonRepository PersonRepository;

        public PersonDeleteCommand(IPersonRepository PersonRepository)
        {
            this.PersonRepository = PersonRepository;
        }

        public async Task<bool> Execute(int id)
        {
            return await this.PersonRepository.Delete(id);
        }
    }
}