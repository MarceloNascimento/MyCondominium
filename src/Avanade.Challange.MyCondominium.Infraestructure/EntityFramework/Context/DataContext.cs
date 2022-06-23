using Avanade.Challange.MyCondominium.Infra.Data.Mappings;
using Avanade.Desafio.Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Avanade.Challange.MyCondominium.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new ApartmentMap());
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Apartment> Apartments { get; set; }

    }
}
