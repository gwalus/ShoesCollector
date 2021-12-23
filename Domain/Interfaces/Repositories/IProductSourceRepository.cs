using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProductSourceRepository
    {
        Task<bool> AddProductSourceAsync(ProductSource productSource);
        Task<List<ProductSource>> GetProductSourcesAsync();
    }
}
