using Avanade.Challenge.MyCondominium.Domain.Interfaces.Repositories;
using Avanade.Challenge.MyCondominium.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Avanade.Challenge.MyCondominium.Infrastructure.Data.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;

        protected GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<T?> GetAsync(int id, CancellationToken cancellationToken)
        {
            var result = _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
            return await result;
        }

        public async Task<IList<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = _context.Set<T>();
            var result = entities.ToListAsync<T>(cancellationToken);
            return await result;
        }

        public async Task<T> InsertAsync(T entity, CancellationToken cancellationToken)
        {
            if (entity is null) return null;

            var Task = _context.Set<T>().AddAsync(entity, cancellationToken);
            var result = _context.SaveChangesAsync(cancellationToken);

            var insertedEntity = await Task;
            await result;

            return insertedEntity.Entity;
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            if (entity is null) return null;

            _context.Entry(entity).State = EntityState.Modified;
            var updatedEntity = _context.Set<T>().Update(entity).Entity;
            _ = await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(updatedEntity);
        }

        public async Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            if (entity is null) return false;

            _ = _context.Set<T>().Remove(entity);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(result > 0);
        }
    }
}