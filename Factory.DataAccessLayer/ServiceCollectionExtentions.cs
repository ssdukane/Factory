using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Omi.Application.Configuration;
using Omi.Application.Interfaces;
using Omi.Infra.Database;
using Omi.Infra.Repository;

namespace Omi.Infra
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OmiRepositoryContext>((sp) =>
            {
                _ = sp.UseSqlServer(configuration.GetConnectionString("DatabaseConnection"));
            });

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            return services;
        }
    }
}
