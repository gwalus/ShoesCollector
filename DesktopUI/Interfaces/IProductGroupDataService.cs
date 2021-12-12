using Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Interfaces
{
    public interface IProductGroupDataService
    {
        Task<List<ProductGroupData>> GetProductSoldGroupData();
        Task<List<ProductGroupData>> GetProductPurchaseGroupData();
        Task<List<ProductGroupData>> GetProductLossGroupData();
    }
}
