using Avanade.Challenge.MyCondominium.Domain.Entities;

namespace Avanade.Challenge.MyCondominium.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> Insert(Person Person);
        Task<Person> Update(Person Person);
        Task<bool> Delete(int id);
        Task<IList<Person>> GetAll();
    }
}
