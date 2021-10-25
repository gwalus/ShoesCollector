using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProductPricesStatisticsRepository
    {
        Task<double> GetBestProfitAsync();
        Task<double> GetLowestProfitAsync();
        Task<double> GetBiggestPurchaseAsync();
        Task<double> GetLowestPurchaseAsync();
    }
}