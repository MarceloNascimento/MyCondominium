using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Repositories;

namespace Avanade.Challenge.MyCondominium.Application.Commands.ApartmentInsert
{
    public class ApartmentInsertCommand
    {
        protected readonly IApartmentRepository ApartmentRepository;

        public ApartmentInsertCommand(IApartmentRepository apartmentRepository)
        {
            this.ApartmentRepository = apartmentRepository;
        }

        public async Task<Apartment> Execute(Apartment apartment){

              return  await this.ApartmentRepository.Insert(apartment);
        }
    }
}