using DDDTraining.Library.Loans.Domain.Repositories.Base;
using DDDTraining.Library.Loans.Infraestructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace DDDTraining.Library.Loans.Infraestructure
{
    public static class ServiceRegistration
    {
        public static void AddDatabaseInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseContext(configuration)
                .RegisterRepositories();
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            var iRepositories = typeof(IRepository).Assembly
                .GetTypes()
                .Where(t => t.IsInterface && typeof(IRepository).IsAssignableFrom(t));

            foreach (var iRepository in iRepositories)
            {
                var repository = Assembly.GetExecutingAssembly()
                                     .GetTypes()
                                     .FirstOrDefault(t => t.IsClass && iRepository.IsAssignableFrom(t))
                                 ?? throw new NotImplementedException(iRepository.Name);

                services.AddScoped(iRepository, repository);
            }
            return services;
        }

        private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services for entity framework

            services.AddDbContext<LibraryDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("DDDTraining.Library.Loans.Api")));

            #endregion

            #region Configuración del Unit of Work

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            return services;
        }
    }
}
