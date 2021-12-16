using Domain.Entities;
using Domain.Helpers.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(ProductFilter productFilter);
        Task<Product> GetByIdAsync();
        Task<bool> AddAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> ChangeStatusAsync(int id);
    }
}
