using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Interfaces.Repositories;
using Avanade.Challenge.MyCondominium.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
namespace Avanade.Challenge.MyCondominium.Infrastructure.Data.Repositories
{
    public class ApartmentRepository : GenericRepository<Apartment>
    {
        private DataContext _context { get; set; }
        public ApartmentRepository(DataContext context) 
        : base(context: context)
        {
            _context = context;
        }
        public async Task<Apartment?> Get(int id)
        {
            if (id is 0) return null;

            var task = _context.Set<Apartment>().FirstOrDefaultAsync(s => s.Id == id);
            return await task;
        }
    }
}
