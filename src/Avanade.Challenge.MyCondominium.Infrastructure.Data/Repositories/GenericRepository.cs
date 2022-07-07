
using Avanade.Challenge.MyCondominium.Domain.Interfaces.Repositories;
using Avanade.Challenge.MyCondominium.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Avanade.Challenge.MyCondominium.Infrastructure.Data.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        private DbSet<T> entities;

        public GenericRepository(DataContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }
        public async Task<IList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Insert(T entity)
        {
            if (entity is null) return null;

            var Task = _context.Set<T>().AddAsync(entity);
            var result = this._context.SaveChangesAsync();

            var insertedEntity = await Task;
            await result;

            return insertedEntity.Entity;
        }

        public async Task<T> Update(T entity)
        {
            if (entity is null) return null;

            var updatedEntity = _context.Set<T>().Update(entity).Entity;
            this._context.SaveChanges();

            return await Task.FromResult(updatedEntity);
        }

        public async Task<bool> Delete(T entity)
        {
            if (entity is null) return false;

            _context.Set<T>().Remove(entity);
            var result = this._context.SaveChanges();

            return await Task.FromResult(result > 0);
        }
    }
}