using DatabaseCore.DataContext;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseCore.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BrandRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddBrandAsync(Brand brand)
        {
            await _dbContext.Brands.AddAsync(brand);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Brand>> GetBrandsAsync()
        {
            return await _dbContext.Brands.ToListAsync();
        }
    }
}
