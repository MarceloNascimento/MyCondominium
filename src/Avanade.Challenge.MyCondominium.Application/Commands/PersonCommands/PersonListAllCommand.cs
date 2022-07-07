using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avanade.Challenge.MyCondominium.Domain.Repositories;
using Avanade.Challenge.MyCondominium.Domain.Entities;

namespace Avanade.Challenge.MyCondominium.Application.Commands.PersonListAll
{
    public class PersonListAllCommand
    {
        protected readonly IPersonRepository PersonRepository;

        public PersonListAllCommand(IPersonRepository personRepository)
        {
            this.PersonRepository = personRepository;
        }

        public async Task<IList<Person>> Execute()
        {
            return await this.PersonRepository.GetAll();
        }
    }
}