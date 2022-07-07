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
            var apartment = await this.ApartmentRepository.Get(id);

            if (apartment is null) return await Task.FromResult(false);

            var TaskDelete = this.ApartmentRepository.Delete(apartment);

            return await TaskDelete;
        }
    }
}