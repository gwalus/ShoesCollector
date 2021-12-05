using Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ITotalsStatisticsRepository
    {
        Task<double> GetTotalsByFilterAsync(Expression<Func<Product, double>> func, bool? isSold);
    }
}
