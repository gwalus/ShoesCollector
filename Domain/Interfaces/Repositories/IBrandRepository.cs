using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IBrandRepository
    {
        Task<bool> AddBrandAsync(Brand brand);
        Task<List<Brand>> GetBrandsAsync();
    }
}
