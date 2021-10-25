using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProductDatesStatisticsRepository
    {
        Task<int> GetDaysOfFirstPurchase();
        Task<int> GetDaysOfLatestPurchase();
        Task<int> GetDaysOfLatestSale();
    }
}
