using DDDTraining.Library.Loans.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DDDTraining.Library.Loans.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddDomainConfiguration();
        }
    }
}
