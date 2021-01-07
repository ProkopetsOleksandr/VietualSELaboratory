using System.Linq;
using System.Threading.Tasks;
using Domain.RDBMS.Entities;

namespace Domain.Services.Interfaces
{
    public interface IStatisticsService
    {
        IQueryable<Statistics> GetAllStatistics(string userId);
        Task<Statistics> GetStatisticsById(int statisticsId);
    }
}
