using System.Linq;
using System.Threading.Tasks;
using Domain.RDBMS;
using Domain.RDBMS.Entities;
using Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.Implementation
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository<Statistics> _statisticsRepository;

        public StatisticsService(IRepository<Statistics> statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public IQueryable<Statistics> GetAllStatistics(string userId)
        {
            return _statisticsRepository
                .GetAll()
                .Include(m => m.Exercise)
                .ThenInclude(m => m.Questions)
                .ThenInclude(m => m.Answers)
                .Where(m => m.UserId == userId);
        }

        public async Task<Statistics> GetStatisticsById(int statisticsId)
        {
            return await _statisticsRepository
                .GetAll()
                .Include(m => m.Exercise)
                .ThenInclude(m => m.Questions)
                .ThenInclude(m => m.Answers)
                .Include(m => m.UserAnswers)
                .SingleOrDefaultAsync(m => m.Id == statisticsId);
        }
    }
}
