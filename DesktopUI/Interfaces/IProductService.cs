using DesktopUI.ViewModelDtos;
using DesktopUI.ViewModels;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts(ProductSearchFilterViewModel productSearchFilter);
        Task<bool> AddProductAsync(ProductApiToAdd product);
        void SetProductView(List<Product> products);
        Task UpdateProductAsync(ProductApiToUpdate productToUpdate);
    }
}
