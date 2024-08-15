using DDDTraining.Library.Loans.Domain.Services.Interfaces.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DDDTraining.Library.Loans.Domain
{
    public static class ServiceRegistration
    {
        public static void AddDomainConfiguration(this IServiceCollection services)
        {

            services.RegisterDomainServices();

        }

        private static IServiceCollection RegisterDomainServices(this IServiceCollection services)
        {
            var iServices = typeof(IDomainService).Assembly
                .GetTypes()
                .Where(t => t.IsInterface && typeof(IDomainService).IsAssignableFrom(t));

            foreach (var iService in iServices)
            {
                var service = Assembly.GetExecutingAssembly()
                                     .GetTypes()
                                     .FirstOrDefault(t => t.IsClass && iService.IsAssignableFrom(t))
                                 ?? throw new NotImplementedException(iService.Name);

                services.AddScoped(iService, service);
            }
            return services;
        }
    }
}
