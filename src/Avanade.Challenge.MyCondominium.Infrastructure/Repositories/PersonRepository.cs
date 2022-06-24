
using Avanade.Challenge.MyCondominium.Domain.Repositories;
using Avanade.Challenge.MyCondominium.Domain.Entities;

namespace Avanade.Challenge.MyCondominium.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Person>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Person> Insert(Person Person)
        {
            throw new NotImplementedException();
        }

        public Task<Person> Update(Person Person)
        {
            throw new NotImplementedException();
        }
    }
}
