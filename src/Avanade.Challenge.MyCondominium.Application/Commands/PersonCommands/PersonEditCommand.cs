using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Repositories;

namespace Avanade.Challenge.MyCondominium.Application.Commands.PersonListAll
{
    public class PersonEditCommand
    {
        protected readonly IPersonRepository PersonRepository;

        public PersonEditCommand(IPersonRepository PersonRepository)
        {
            this.PersonRepository = PersonRepository;
        }

        public async Task<Person> Execute(Person person)
        {
            return await this.PersonRepository.Update(person);
        }
    }
}