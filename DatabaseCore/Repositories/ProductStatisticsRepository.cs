﻿using DatabaseCore.DataContext;
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

        public async Task<int> GetDaysOfLatestPurchase()
        {
            var latestPurchase = await GetLatestPurchase();

            var dateLatestPurchase = ConvertStringToDateTime(latestPurchase.DateOfPurchase);

            return CalculateToDays(dateLatestPurchase);
        }

        public async Task<int> GetDaysOfLatestSale()
        {
            var latestSale = await GetLatestSale();

            var dateLatestSale = ConvertStringToDateTime(latestSale.SaleDate);

            return CalculateToDays(dateLatestSale);
        }

        public async Task<Product> GetFirstPurchase()
        {
            return await _dbContext.Products.FirstOrDefaultAsync();
        }

        public async Task<Product> GetLatestPurchase()
        {
            var latestPuchase = await _dbContext.Products.ToListAsync();

            return latestPuchase
                .OrderByDescending(p => DateTime.Parse(p.DateOfPurchase))
                .FirstOrDefault();
        }

        public async Task<Product> GetLatestSale()
        {
            var latestSale = await _dbContext.Products.ToListAsync();

            return latestSale
                .Where(p => !string.IsNullOrEmpty(p.SaleDate))
                .OrderByDescending(p => DateTime.Parse(p.SaleDate))
                .FirstOrDefault();
        }

        public async Task<double> GetLowestProfit()
        {
            return await _dbContext.Products.Where(p => p.Profit > 0).MinAsync(p => p.Profit.GetValueOrDefault());
        }

        public async Task<double> GetLowestPurchase()
        {
            return await _dbContext.Products.MinAsync(p => p.PurchasePrice);
        }

        private DateTime ConvertStringToDateTime(string date) => DateTime.Parse(date);
        private int CalculateToDays(DateTime date) => (DateTime.Now - date).Days;        
    }
}
