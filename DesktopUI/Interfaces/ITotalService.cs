using System.Threading.Tasks;

namespace DesktopUI.Interfaces
{
    public interface ITotalService
    {
        Task<int> GetTotalCount(bool? isSold = null);
        Task<double> GetTotalPurchase(bool? isSold = null);
        Task<double> GetTotalSell(bool? isSold = null);
        Task<double> GetTotalShip(bool? isSold = null);
        Task<double> GetTotalWithoutShip(bool? isSold = null);
        Task<double> GetTotalProfit(bool? isSold = null);
        void SetProductTotalsView(bool? isSold = null, string description = null);
    }
}
