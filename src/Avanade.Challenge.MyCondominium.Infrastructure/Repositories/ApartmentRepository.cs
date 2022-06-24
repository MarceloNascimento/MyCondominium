using Avanade.Challenge.MyCondominium.Domain.Repositories;
using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
namespace Avanade.Challenge.MyCondominium.Infra.Data.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private DataContext _context { get; set; }

        public ApartmentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IList<Apartment>> GetAll()
        {
            var entities = this._context.Apartments.ToListAsync();
            return await entities;
        }

        public async Task<Apartment> Insert(Apartment apartment)
        {
            var ApartmentTask = this._context.Apartments.AddAsync(apartment);
            var result = this._context.SaveChangesAsync();

            var entity = await ApartmentTask;
            await result;

            return entity.Entity;
        }

        public async Task<Apartment> Update(Apartment apartment)
        {
            var entity = this._context.Apartments.Update(apartment).Entity;
            this._context.SaveChanges();

            return await Task.FromResult(entity);
        }

        public async Task<bool> Delete(Apartment apartment)
        {
            this._context.Apartments.Remove(apartment);
            var result = this._context.SaveChanges();

            return await Task.FromResult(result > 0);
        }
    }
}
