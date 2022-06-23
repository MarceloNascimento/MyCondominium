using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Avanade.Challange.MyCondominium.Infra.CrossCutting
{
    [ExcludeFromCodeCoverage]
    public static class RepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services,
                                                         IConfiguration configuration)
        {
            //services.AddTransient<IApartmentsWriteRepository, ApartmentsWriteRepository>();
            return services;
        }
    }
}