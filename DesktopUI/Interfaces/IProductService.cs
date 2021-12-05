using DesktopUI.ViewModels;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts(ProductSearchFilterViewModel productSearchFilter);
        void SetProductView(List<Product> products);
    }
}
