using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProductDatesStatisticsRepository
    {
        Task<int> GetDaysOfFirstPurchaseAsync();
        Task<int> GetDaysOfLatestPurchaseAsync();
        Task<int> GetDaysOfLatestSaleAsync();
    }
}
