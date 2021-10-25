using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProductStatisticsRepository
    {
        Task<Product> GetFirstPurchaseAsync();
        Task<Product> GetLatestPurchaseAsync();
        Task<Product> GetLatestSaleAsync();
    }
}
