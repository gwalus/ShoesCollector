using DatabaseCore.DataContext;
using Domain.Dtos;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCore.Repositories
{
    public class ChartRepository : IChartRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ChartRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ChartBrandSeriesDto>> GetChartBrandSeriesAsync()
        {
            return await _dbContext.Products.GroupBy(x => x.Brand).Select(x => new ChartBrandSeriesDto
            {
                Name = x.Key,
                Count = x.Count(),
            }).ToListAsync();
        }

        public async Task<List<ChartColorSeriesDto>> GetChartColorSeriesAsync()
        {
            return await _dbContext.Products.GroupBy(x => x.Color).Select(x => new ChartColorSeriesDto
            {
                Name = x.Key,
                Count = x.Count(),
            }).ToListAsync();
        }

        public async Task<List<ChartSizeSeriesDto>> GetChartSizeSeriesAsync()
        {
            return await _dbContext.Products.GroupBy(x => x.Size).Select(x => new ChartSizeSeriesDto
            {
                Size = x.Key,
                Count = x.Count(),
            }).ToListAsync();
        }
    }
}
