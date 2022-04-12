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

            var formatInfo = new DateTimeFormatInfo()
            {
                ShortDatePattern = "dd.MM.yyyy"
            };

            var groupedSoldLossProducts = products
                .Where(x => x.IsSold && x.Profit < 0)
                .OrderByDescending(x => Convert.ToDateTime(x.SaleDate, formatInfo))
                .GroupBy(x => new { Convert.ToDateTime(x.SaleDate, formatInfo).Year, Convert.ToDateTime(x.SaleDate, formatInfo).Month })
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

            var formatInfo = new DateTimeFormatInfo()
            {
                ShortDatePattern = "dd.MM.yyyy"
            };

            var groupedPurchaseProducts = products
                .OrderByDescending(x => Convert.ToDateTime(x.DateOfPurchase, formatInfo))
                .GroupBy(product => new { Convert.ToDateTime(product.DateOfPurchase, formatInfo).Year, Convert.ToDateTime(product.DateOfPurchase, formatInfo).Month })
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

            var formatInfo = new DateTimeFormatInfo()
            {
                ShortDatePattern = "dd.MM.yyyy"
            };

            var groupedSoldProducts = products
                .Where(x => x.IsSold)
                .OrderByDescending(x => Convert.ToDateTime(x.SaleDate, formatInfo))
                .GroupBy(x => new { Convert.ToDateTime(x.SaleDate, formatInfo).Year, Convert.ToDateTime(x.SaleDate, formatInfo).Month })
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
