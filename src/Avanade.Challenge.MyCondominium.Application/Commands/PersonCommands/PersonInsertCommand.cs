using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Repositories;

namespace Avanade.Challenge.MyCondominium.Application.Commands.PersonListAll
{
    public class PersonInsertCommand
    {
        protected readonly IPersonRepository PersonRepository;

        public PersonInsertCommand(IPersonRepository PersonRepository)
        {
            this.PersonRepository = PersonRepository;
        }

        public async Task<Person> Execute(Person person)
        {
            return await this.PersonRepository.Insert(person);
        }
    }
}