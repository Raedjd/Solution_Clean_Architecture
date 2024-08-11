
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SolutionProject.Application
{
public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly( Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
