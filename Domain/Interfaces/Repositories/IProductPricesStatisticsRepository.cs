using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProductPricesStatisticsRepository
    {
        Task<double> GetBestProfit();
        Task<double> GetLowestProfit();
        Task<double> GetBiggestPurchase();
        Task<double> GetLowestPurchase();
    }
}