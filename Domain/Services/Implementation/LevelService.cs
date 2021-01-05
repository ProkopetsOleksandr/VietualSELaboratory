using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.RDBMS;
using Domain.RDBMS.Entities;
using Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.Implementation
{
    public class LevelService : ILevelService
    {
        private readonly IRepository<Level> _levelRepository;
        public LevelService(IRepository<Level> levelRepository)
        {
            _levelRepository = levelRepository;
        }

        public async Task<IEnumerable<Level>> GetAllLevelsAsync()
        {
            return await _levelRepository.GetAll().ToListAsync();
        }
    }
}
