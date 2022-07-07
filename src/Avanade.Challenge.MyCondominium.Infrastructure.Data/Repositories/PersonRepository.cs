
using Avanade.Challenge.MyCondominium.Domain.Repositories;
using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Avanade.Challenge.MyCondominium.Infrastructure.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private DataContext _context { get; set; }

        public PersonRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IList<Person>> GetAll()
        {
            var entities = this._context.People.ToListAsync();
            return await entities;
        }

        public async Task<Person?> Get(int id)
        {
            var entity = this._context.People.Where(x => x.Id == id).FirstOrDefaultAsync();
            return await entity;
        }

        public async Task<Person> Insert(Person person)
        {
            var personTask = this._context.People.AddAsync(person);
            var result = this._context.SaveChangesAsync();

            var entity = await personTask;
            await result;

            return entity.Entity;
        }

        public async Task<Person> Update(Person person)
        {
            var entity = this._context.People.Update(person).Entity;
            this._context.SaveChanges();

            return await Task.FromResult(entity);
        }

        public async Task<bool> Delete(Person person)
        {
            this._context.People.Remove(person);
            var result = this._context.SaveChanges();

            return await Task.FromResult(result > 0);
        }
    }
}
