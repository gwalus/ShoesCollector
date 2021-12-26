using DatabaseCore.DataContext;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCore.Repositories
{
    public class ProductStatisticsRepository : IProductStatisticsRepository, IProductDatesStatisticsRepository, IProductPricesStatisticsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductStatisticsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<double> GetBestProfitAsync()
        {
            return await _dbContext.Products.MaxAsync(p => p.Profit.GetValueOrDefault());
        }

        public async Task<double> GetBiggestPurchaseAsync()
        {
            return await _dbContext.Products.MaxAsync(p => p.PurchasePrice);
        }

        public async Task<int> GetDaysOfFirstPurchaseAsync()
        {
            var firstPurchase = await GetFirstPurchaseAsync();

            var dateFirstPurchase = ConvertStringToDateTime(firstPurchase.DateOfPurchase);

            if (dateFirstPurchase != null)
                return CalculateToDays(dateFirstPurchase.Value);
            return -1;
        }

        public async Task<int> GetDaysOfLatestPurchaseAsync()
        {
            var latestPurchase = await GetLatestPurchaseAsync();

            var dateLatestPurchase = ConvertStringToDateTime(latestPurchase.DateOfPurchase);
            if (dateLatestPurchase != null)
                return CalculateToDays(dateLatestPurchase.Value);
            return -1;
        }

        public async Task<int> GetDaysOfLatestSaleAsync()
        {
            var latestSale = await GetLatestSaleAsync();

            var dateLatestSale = ConvertStringToDateTime(latestSale.SaleDate);
            if(dateLatestSale != null)
                return CalculateToDays(dateLatestSale.Value);
            return -1;
        }

        public async Task<Product> GetFirstPurchaseAsync()
        {
            return await _dbContext.Products.FirstOrDefaultAsync();
        }

        public async Task<Product> GetLatestPurchaseAsync()
        {
            var latestPuchase = await _dbContext.Products.ToListAsync();

            return latestPuchase
                .OrderByDescending(p => DateTime.TryParse(p.DateOfPurchase, out DateTime result))
                .FirstOrDefault();
        }

        public async Task<Product> GetLatestSaleAsync()
        {
            var latestSale = await _dbContext.Products.ToListAsync();

            return latestSale
                .Where(p => !string.IsNullOrEmpty(p.SaleDate))
                .OrderByDescending(p => DateTime.Parse(p.SaleDate))
                .FirstOrDefault();
        }

        public async Task<double> GetLowestProfitAsync()
        {
            return await _dbContext.Products.Where(p => p.Profit > 0).MinAsync(p => p.Profit.GetValueOrDefault());
        }

        public async Task<double> GetLowestPurchaseAsync()
        {
            return await _dbContext.Products.MinAsync(p => p.PurchasePrice);
        }

        private static DateTime? ConvertStringToDateTime(string date) => DateTime.TryParse(date, out DateTime result) ? result : null;
        private static int CalculateToDays(DateTime date) => (DateTime.Now - date).Days;
    }
}
