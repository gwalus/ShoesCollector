using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Interfaces
{
    public interface IBrandService
    {
        Task<bool> AddBrandAsync(Brand brand);
        Task<List<Brand>> GetBrandAsync();
    }
}
