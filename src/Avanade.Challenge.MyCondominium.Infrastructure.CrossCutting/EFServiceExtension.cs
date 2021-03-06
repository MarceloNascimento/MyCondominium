using Avanade.Challenge.MyCondominium.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Avanade.Challenge.MyCondominium.Infrastructure.CrossCutting
{
    [ExcludeFromCodeCoverage]
    public static class EFServiceExtension
    {

        public static IServiceCollection AddEFCore(this IServiceCollection services,
                                                   IConfiguration configuration)
        {
            
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            return services;
        }
    }
}

