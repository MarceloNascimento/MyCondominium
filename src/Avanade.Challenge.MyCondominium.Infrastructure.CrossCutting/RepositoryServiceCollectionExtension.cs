using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Avanade.Challenge.MyCondominium.Infrastructure.CrossCutting
{
    [ExcludeFromCodeCoverage]
    public static class RepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services,
                                                         IConfiguration configuration)
        {
            services.AddTransient<IApartmentsRepository, ApartmentsRepository>();
            return services;
        }
    }
}