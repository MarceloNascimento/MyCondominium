using Avanade.Challenge.MyCondominium.Domain.Entities;

namespace Avanade.Challenge.MyCondominium.Infrastructure.CrossCutting.Interfaces
{
    public interface IPersonService
    {
        IList<Person>? ListEntries(Apartment apartment);
        Person AddEntry(Person resident);
        Person UpdateEntry(Person resident);
        bool RemoveEntry(Person resident);
    }
}
