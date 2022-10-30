using Microsoft.Extensions.DependencyInjection;
using Omi.Application.Configuration;

namespace Omi.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicatoinServices( this IServiceCollection services, ApplicationOptions options)
        {

            //services.AddRecurringJobs();
             return services;
        }
    }
}
