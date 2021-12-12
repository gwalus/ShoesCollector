using Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProductGroupDataRepository
    {
        Task<List<ProductGroupData>> GetSoldProductGroupData();
        Task<List<ProductGroupData>> GetPurchaseProductGroupData();
        Task<List<ProductGroupData>> GetLossProductGroupData();
    }
}
