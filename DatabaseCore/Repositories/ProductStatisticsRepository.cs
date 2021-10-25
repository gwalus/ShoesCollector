using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace DatabaseCore.Repositories
{
    public class ProductStatisticsRepository : IProductStatisticsRepository, IProductDatesStatisticsRepository, IProductPricesStatisticsRepository
    {
        public Task<double> GetBestProfit()
        {
            throw new NotImplementedException();
        }

        public Task<double> GetBiggestPurchase()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetDaysOfFirstPurchase()
        {
            throw new NotImplementedException();
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
    }
}
