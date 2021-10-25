using DatabaseCore.DataContext;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<double> GetBestProfit()
        {
            return await _dbContext.Products.MaxAsync(p => p.Profit.GetValueOrDefault());
        }

        public async Task<double> GetBiggestPurchase()
        {
            return await _dbContext.Products.MaxAsync(p => p.PurchasePrice);
        }

        public async Task<int> GetDaysOfFirstPurchase()
        {
            var firstPurchase = await GetFirstPurchase();

            var dateFirstPurchase = ConvertStringToDateTime(firstPurchase.DateOfPurchase);

            return CalculateToDays(dateFirstPurchase);
        }

        public Task<int> GetDaysOfLatestPurchase()
        {
            throw new NotImplementedException();        
        }

        public Task<int> GetDaysOfLatestSale()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetFirstPurchase()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetLatestPurchase()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetLatestSale()
        {
            throw new NotImplementedException();
        }

        public Task<double> GetLowestProfit()
        {
            throw new NotImplementedException();
        }

        public Task<double> GetLowestPurchase()
        {
            throw new NotImplementedException();
        }

        private DateTime ConvertStringToDateTime(string date) => DateTime.Parse(date);
        private int CalculateToDays(DateTime date) => (DateTime.Now - date).Days;        
    }
}
