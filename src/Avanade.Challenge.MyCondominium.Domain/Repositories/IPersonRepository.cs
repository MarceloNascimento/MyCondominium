using Avanade.Challenge.MyCondominium.Domain.Entities;

namespace Avanade.Challenge.MyCondominium.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<IList<Person>> GetAll();
        Task<Person?> Get(int id);
        Task<Person> Insert(Person person);
        Task<Person> Update(Person person);
        Task<bool> Delete(Person person);        
    }
}
