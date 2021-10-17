using Domain.Entities;
using Domain.Helpers.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll(ProductFilter productFilter);
        Task<Product> GetById();
        Task<bool> Add(Product product);
        Task<bool> Update(Product product);
        Task<bool> ChangeStatus(int id);
    }
}
