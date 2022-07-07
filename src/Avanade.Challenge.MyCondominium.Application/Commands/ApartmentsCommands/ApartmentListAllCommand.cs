using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Repositories;

namespace Avanade.Challenge.MyCondominium.Application.Commands.ApartmentListAll
{
    public class ApartmentListAllCommand
    {
        protected readonly IApartmentRepository ApartmentRepository;

        public ApartmentListAllCommand(IApartmentRepository apartmentRepository)
        {
            this.ApartmentRepository = apartmentRepository;
        }
        public async Task<IList<Apartment>> Execute()
        {
            return await this.ApartmentRepository.GetAll();
        }
    }
}