using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.RDBMS.Entities;

namespace Domain.Services.Interfaces
{
    public interface ILevelService
    {
        Task<IEnumerable<Level>> GetAllLevelsAsync();
    }
}
