using DatabaseCore.Repositories;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Extensions
{
    public static class ApplicationRepositoryExtension
    {
        public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
