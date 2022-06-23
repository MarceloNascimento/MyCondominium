using Avanade.Desafio.Condominio.Domain.Entities;

namespace Avanade.Challange.MyCondominium.Domain.Interfaces
{
    public interface IPersonService
    {
        IList<Person>? ListEntries(Apartment apartment);
        Person AddEntry(Person resident);
        Person UpdateEntry(Person resident);
        bool RemoveEntry(Person resident);
    }
}
