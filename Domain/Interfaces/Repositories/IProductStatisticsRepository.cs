using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProductStatisticsRepository
    {
        Task<Product> GetFirstPurchase();
        Task<Product> GetLatestPurchase();
        Task<Product> GetLatestSale();
    }
}
