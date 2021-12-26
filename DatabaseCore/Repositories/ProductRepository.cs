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

        public async Task<bool> AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public Task<bool> ChangeStatusAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync(ProductFilter productFilter)
        {
            var query = _dbContext.Products.AsQueryable();

            switch (productFilter.Condition)
            {
                case nameof(ProductFilterEnum.Available):
                    query = query.Where(x => !x.IsSold);
                    break;
                case nameof(ProductFilterEnum.Sold):
                    query = query.Where(x => x.IsSold);
                    break;
            }

            if (!string.IsNullOrEmpty(productFilter.ProductName))
                query = query.Where(x => x.Name.ToLower().Contains(productFilter.ProductName.ToLower()));

            if (!string.IsNullOrEmpty(productFilter.Brand))
                query = query.Where(x => x.Brand.ToLower().Contains(productFilter.Brand.ToLower()));

            if (!string.IsNullOrEmpty(productFilter.Code))
                query = query.Where(x => x.ProductCode.ToLower().Contains(productFilter.Code.ToLower()));

            if (!string.IsNullOrEmpty(productFilter.Color))
                query = query.Where(x => x.Color.ToLower().Contains(productFilter.Color.ToLower()));

            if (!string.IsNullOrEmpty(productFilter.Size))
                query = query.Where(x => x.Size.ToLower().Contains(productFilter.Size.ToLower()));

            if (!string.IsNullOrEmpty(productFilter.Source))
                query = query.Where(x => x.Source.ToLower().Contains(productFilter.Source.ToLower()));

            if (productFilter.Box.HasValue)
                query = query.Where(x => x.Box.Value == productFilter.Box);

            return await query.ToListAsync();
        }

        public Task<Product> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var productToUpdate = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == product.Id);

            productToUpdate.Brand = product.Brand;
            productToUpdate.Name = product.Name;
            productToUpdate.ProductCode = product.ProductCode;
            productToUpdate.Color = product.Color;
            productToUpdate.Size = product.Size;
            productToUpdate.Box = product.Box;
            productToUpdate.Source = product.Source;
            productToUpdate.DateOfPurchase = product.DateOfPurchase;
            productToUpdate.PurchasePrice = product.PurchasePrice;
            if (product.SaleDate != null)
                productToUpdate.SaleDate = product.SaleDate;
            if (product.SellingPrice.HasValue)
                productToUpdate.SellingPrice = product.SellingPrice;
            if (product.ShippingPrice.HasValue)
                productToUpdate.ShippingPrice = product.ShippingPrice;
            if (product.PriceWithoutShipping.HasValue)
                productToUpdate.PriceWithoutShipping = product.PriceWithoutShipping;
            if (product.Profit.HasValue)
                productToUpdate.Profit = product.Profit;

            productToUpdate.IsSold = product.IsSold;
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
