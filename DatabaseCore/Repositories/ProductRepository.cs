using DatabaseCore.DataContext;
using Domain.Entities;
using Domain.Helpers.Enums;
using Domain.Helpers.Filters;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> Add(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeStatus(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAll(ProductFilter productFilter)
        {
            var query = _dbContext.Products.AsQueryable();

            switch (productFilter.Condition)
            {
                case nameof(ProductFilterEnum.Available):
                    return await query.Where(x => !x.IsSold).ToListAsync();
                case nameof(ProductFilterEnum.Sold):
                    return await query.Where(x => x.IsSold).ToListAsync();
                default:
                    return await query.ToListAsync();
            }
        }

        public Task<Product> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
