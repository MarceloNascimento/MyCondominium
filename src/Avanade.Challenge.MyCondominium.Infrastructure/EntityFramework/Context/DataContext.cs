using Avanade.Challenge.MyCondominium.Infra.Data.Mappings;
using Avanade.Challenge.MyCondominium.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Avanade.Challenge.MyCondominium.Infra.Data.Context
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
