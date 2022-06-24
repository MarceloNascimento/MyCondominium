using Avanade.Challenge.MyCondominium.Domain.Repositories;

namespace Avanade.Challenge.MyCondominium.Application.Commands.ApartmentListAll
{
    public class ApartmentDeleteCommand
    {
        protected readonly IApartmentRepository ApartmentRepository;

        public ApartmentDeleteCommand(IApartmentRepository apartmentRepository)
        {
            this.ApartmentRepository = apartmentRepository;
        }

        public async Task<bool> Execute(int id)
        {
            return await this.ApartmentRepository.Delete(id);
        }
    }
}