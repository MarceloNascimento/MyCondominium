
using Avanade.Challange.MyCondominium.Domain.Interfaces;
using Avanade.Challange.MyCondominium.Domain.Repositories;
using Avanade.Desafio.Condominio.Domain.Entities;

namespace Avanade.Challange.MyCondominium.Domain.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IList<Person>? ListEntries(Apartment apartment)
        {
            throw new NotImplementedException();
        }

        public Person AddEntry(Person resident)
        {
            throw new NotImplementedException();
        }

        public Person UpdateEntry(Person resident)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEntry(Person resident)
        {
            throw new NotImplementedException();
        }
    }
}
