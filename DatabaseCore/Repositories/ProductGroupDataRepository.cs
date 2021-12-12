using DatabaseCore.DataContext;
using Domain.Dtos;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCore.Repositories
{
    public class ProductGroupDataRepository : IProductGroupDataRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductGroupDataRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductGroupData>> GetLossProductGroupData()
        {
            var products = await _dbContext.Products.ToListAsync();

            var groupedSoldLossProducts = products
                .Where(x => x.IsSold && x.Profit < 0)
                .OrderByDescending(x => DateTime.Parse(x.SaleDate))
                .GroupBy(x => new { DateTime.Parse(x.SaleDate).Year, DateTime.Parse(x.SaleDate).Month })
                .ToList();

            var productGroupDatas = new List<ProductGroupData>();

            foreach (var item in groupedSoldLossProducts)
            {
                var groupedData = new ProductGroupData()
                {
                    Year = item.Key.Year,
                    Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Key.Month),
                    Count = item.Count(),
                    Purchase = Math.Round(item.Sum(x => x.Profit.Value), 2),
                    Average = Math.Round((item.Sum(x => x.Profit.Value) / item.Count()), 2)
                };

                productGroupDatas.Add(groupedData);
            }

            return productGroupDatas;
        }

        public async Task<List<ProductGroupData>> GetPurchaseProductGroupData()
        {
            var products = await _dbContext.Products.ToListAsync();

            var groupedPurchaseProducts = products
                .OrderByDescending(product => DateTime.Parse(product.DateOfPurchase))
                .GroupBy(product => new { DateTime.Parse(product.DateOfPurchase).Year, DateTime.Parse(product.DateOfPurchase).Month })
                .ToList();

            var productGroupDatas = new List<ProductGroupData>();

            foreach (var item in groupedPurchaseProducts)
            {
                var groupedData = new ProductGroupData()
                {
                    Year = item.Key.Year,
                    Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Key.Month),
                    Count = item.Count(),
                    Purchase = Math.Round(item.Sum(x => x.PurchasePrice), 2),
                    Average = Math.Round((item.Sum(x => x.PurchasePrice) / item.Count()), 2)
                };

                productGroupDatas.Add(groupedData);
            }

            return productGroupDatas;
        }

        public async Task<List<ProductGroupData>> GetSoldProductGroupData()
        {
            var products = await _dbContext.Products.ToListAsync();

            var groupedSoldProducts = products
                .Where(x => x.IsSold)
                .OrderByDescending(x => DateTime.Parse(x.SaleDate))
                .GroupBy(x => new { DateTime.Parse(x.SaleDate).Year, DateTime.Parse(x.SaleDate).Month })
                .ToList();

            var productGroupDatas = new List<ProductGroupData>();

            foreach (var item in groupedSoldProducts)
            {
                var groupedData = new ProductGroupData()
                {
                    Year = item.Key.Year,
                    Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Key.Month),
                    Count = item.Count(),
                    Profit = Math.Round(item.Sum(x => x.Profit.Value), 2),
                    Average = Math.Round((item.Sum(x => x.Profit.Value) / item.Count()), 2)
                };

                productGroupDatas.Add(groupedData);
            }

            return productGroupDatas;
        }
    }
}
