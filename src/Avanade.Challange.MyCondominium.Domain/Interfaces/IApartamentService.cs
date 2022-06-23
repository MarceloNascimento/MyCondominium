using Avanade.Desafio.Condominio.Domain.Entities;

namespace Avanade.Challange.MyCondominium.Domain.Interfaces
{
    public interface IApartamentService
    {
        Person AddApartmentResident(Person resident, int apartmentId);
        Person RemoveApartmentResident(Person resident, int apartmentId);
        Person UpdateApartmentResident(Person resident, int apartmentId);
        Person GetApartmentResident(Person resident, int apartmentId);
    }
}
