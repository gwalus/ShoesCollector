using DatabaseCore.DataContext;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async Task<double> GetTotalsByFilterAsync(Expression<Func<Product, double>> func, bool? isSold)
        {
            var query = _dbContext.Products.AsQueryable();

            if (isSold != null && isSold.Value)
                query = query.Where(x => x.IsSold);
            if (isSold != null && isSold.Value == false)
                query = query.Where(x => !x.IsSold);

            return await query.SumAsync(func);
        }
    }
}
