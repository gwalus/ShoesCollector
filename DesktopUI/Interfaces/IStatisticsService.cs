using Domain.Entities;
using System.Threading.Tasks;

namespace DesktopUI.Interfaces
{
    public interface IStatisticsService
    {
        Task<Product> GetFirstPurchase();
        Task<Product> GetLatestPurchase();
        Task<Product> GetLatestSale();
        Task<int> GetDaysOfFirstPurchase();
        Task<int> GetDaysOfLatestPurchase();
        Task<int> GetDaysOfLatestSale();
        Task<double> GetBestProfit();
        Task<double> GetLowestProfit();
    }
}
