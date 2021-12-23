using DatabaseCore.DataContext;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseCore.Repositories
{
    public class ProductSourceRepository : IProductSourceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductSourceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddProductSourceAsync(ProductSource productSource)
        {
            await _dbContext.ProductSources.AddRangeAsync(productSource);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<ProductSource>> GetProductSourcesAsync()
        {
            return await _dbContext.ProductSources.ToListAsync();
        }
    }
}
