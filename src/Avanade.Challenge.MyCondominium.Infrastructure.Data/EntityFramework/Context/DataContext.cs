using Avanade.Challenge.MyCondominium.Infra.Data.Mappings;
using Avanade.Challenge.MyCondominium.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Avanade.Challenge.MyCondominium.Infrastructure.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Apartment> Apartments { get; set; }

        public DataContext() { }
        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string projectPath = $@"{AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"src\" }, StringSplitOptions.None)[0]}src\Avanade.Challenge.MyCondominium.API\";
            IConfigurationRoot configuration = new ConfigurationBuilder() 
            .SetBasePath(projectPath)
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
        
            if (!options.IsConfigured)
            {
                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new ApartmentMap());
        }
    }
}
