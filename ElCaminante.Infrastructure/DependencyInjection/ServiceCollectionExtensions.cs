using ElCaminante.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ElCaminante.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            // Aquí puedes registrar más servicios de infraestructura en el futuro
            return services;
        }
    }
}