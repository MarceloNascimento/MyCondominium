using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Interfaces.Repositories;
using Avanade.Challenge.MyCondominium.Infrastructure.Data.Context;
namespace Avanade.Challenge.MyCondominium.Infrastructure.Data.Repositories
{
    public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(DataContext context)
        : base(context: context)
        { }
    }
}
