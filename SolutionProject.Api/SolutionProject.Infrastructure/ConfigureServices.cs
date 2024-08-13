﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolutionProject.Application.Contracts.Persistence;
using SolutionProject.Infrastructure.Persistance.Repositories;
namespace SolutionProject.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Connextion To SQL server
            string dbConnectionString = configuration.GetConnectionString("DefaultConnection");
          
            services.AddDbContext<ApplicationDBContext>((provider, builder) =>
            {
                builder.UseSqlServer(
                    dbConnectionString,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });
            });

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            return services;
        }
    }
}
