using DatabaseCore.DataContext;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatabaseCore.Repositories
{
    public class TotalsStatisticsRepository : ITotalsStatisticsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TotalsStatisticsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<double> GetTotalsByFilterAsync(Expression<Func<Product, double>> func)
        {
            return await _dbContext.Products.SumAsync(func);
        }
    }
}
