using Domain.Dtos;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProductGroupDataRepository
    {
        Task<ProductGroupData> GetSoldProductGroupData();
        Task<ProductGroupData> GetPurhcaseProductGroupData();
        Task<ProductGroupData> GetLossProductGroupData();
    }
}
