using DatabaseCore.Repositories;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Extensions
{
    public static class ApplicationRepositoryExtension
    {
        public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductStatisticsRepository, ProductStatisticsRepository>();
            services.AddScoped<IProductDatesStatisticsRepository, ProductStatisticsRepository>();
            services.AddScoped<IProductPricesStatisticsRepository, ProductStatisticsRepository>();

            return services;
        }
    }
}
