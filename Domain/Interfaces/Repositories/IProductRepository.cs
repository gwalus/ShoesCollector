using DatabaseCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<List<Product>> GetAvailable();
        Task<List<Product>> GetSold();
        Task<Product> GetById();
        Task<bool> Add(Product product);
        Task<bool> Update(Product product);
        Task<bool> ChangeStatus(int id);
    }
}
