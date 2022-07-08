using Avanade.Challenge.MyCondominium.Domain.Interfaces.Repositories;
using Avanade.Challenge.MyCondominium.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Avanade.Challenge.MyCondominium.Infrastructure.CrossCutting
{
    [ExcludeFromCodeCoverage]
    public static class RepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IApartmentRepository, ApartmentRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            return services;
        }
    }
}