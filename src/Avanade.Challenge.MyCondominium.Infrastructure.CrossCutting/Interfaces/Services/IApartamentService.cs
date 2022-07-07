using Avanade.Challenge.MyCondominium.Domain.Entities;

namespace Avanade.Challenge.MyCondominium.Infrastructure.CrossCutting.Interfaces
{
    public interface IApartamentService
    {
        Person AddApartmentResident(Person resident, int apartmentId);
        Person RemoveApartmentResident(Person resident, int apartmentId);
        Person UpdateApartmentResident(Person resident, int apartmentId);
        Person GetApartmentResident(Person resident, int apartmentId);
    }
}
