
using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Repositories;

namespace Avanade.Challenge.MyCondominium.Application.Commands.PersonListAll
{
    public class PersonDeleteCommand : Command
    {
        protected readonly IPersonRepository PersonRepository;
        protected int Id {get;set;}

        public PersonDeleteCommand(IPersonRepository PersonRepository)
        {
            this.PersonRepository = PersonRepository;
        }

        public override async Task<bool> Execute()
        {   
            var person = await this.PersonRepository.Get(Id);            
            if(person is null ) return true;

            return await this.PersonRepository.Delete(person);
        }
    }
}