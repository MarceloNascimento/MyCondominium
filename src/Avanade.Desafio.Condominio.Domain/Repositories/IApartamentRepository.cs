using Avanade.Desafio.Condominio.Domain.Entities;

namespace Avanade.Challange.MyCondominium.Domain.Repositories
{
    public interface IApartamentRepository
    {
        Apartment Insert(Apartment apartment);
        Apartment Update(Apartment apartment);
        Apartment Delete(Apartment apartment);
        IList<Apartment> GetAll();
    }
}
