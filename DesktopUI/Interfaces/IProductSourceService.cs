using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Interfaces
{
    public interface IProductSourceService
    {
        Task<List<ProductSource>> GetProductSourcesAsync();
        Task<bool> AddProductSourceAsync(ProductSource productSource);
    }
}
