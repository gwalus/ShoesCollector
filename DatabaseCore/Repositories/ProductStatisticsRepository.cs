using DatabaseCore.DataContext;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCore.Repositories
{
    public class ProductStatisticsRepository : IProductStatisticsRepository, IProductDatesStatisticsRepository, IProductPricesStatisticsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DateTimeFormatInfo _dateTimeFormatInfo;

        public ProductStatisticsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dateTimeFormatInfo = new DateTimeFormatInfo()
            {
                ShortDatePattern = "dd.MM.yyyy"
            };
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
            var products = await _dbContext.Products.ToListAsync();
            
            return products.OrderBy(x => Convert.ToDateTime(x.DateOfPurchase, _dateTimeFormatInfo)).FirstOrDefault();
        }

        public async Task<Product> GetLatestPurchaseAsync()
        {
            var products = await _dbContext.Products.ToListAsync();

            return products.OrderByDescending(x => Convert.ToDateTime(x.DateOfPurchase, _dateTimeFormatInfo)).FirstOrDefault();
        }

        public async Task<Product> GetLatestSaleAsync()
        {
            var latestSale = await _dbContext.Products
                .Where(x => x.IsSold)
                .ToListAsync();

            return latestSale
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

        private static DateTime? ConvertStringToDateTime(string date) => Convert.ToDateTime(date, new DateTimeFormatInfo()
        {
            ShortDatePattern = "dd.MM.yyyy"
        });        
        private static int CalculateToDays(DateTime date) => (DateTime.Now - date).Days;
    }
}
