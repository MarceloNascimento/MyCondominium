using Avanade.Desafio.Condominio.Domain.Entities;

namespace Avanade.Challange.MyCondominium.Domain.Repositories
{
    public interface IPersonRepository
    {
        Person Insert(Person Person);
        Person Update(Person Person);
        Person Delete(Person Person);
        IList<Person> GetAll();
    }
}
