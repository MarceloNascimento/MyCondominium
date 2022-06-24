using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Repositories;
using Avanade.Challenge.MyCondominium.Infra.Data.Repositories;

namespace Avanade.Challenge.MyCondominium.Application.Commands.ApartmentEdit
{
    public class ApartmentEditCommand
    {
        protected readonly IApartmentRepository ApartmentRepository;

        public ApartmentEditCommand(IApartmentRepository apartmentRepository)
        {
            this.ApartmentRepository = apartmentRepository;            
        }
        public async Task<Apartment> Execute(Apartment apartment)
        {
            return await this.ApartmentRepository.Update(apartment);
        }
    }
}