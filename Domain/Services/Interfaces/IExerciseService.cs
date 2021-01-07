using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.RDBMS.Entities;

namespace Domain.Services.Interfaces
{
    public interface IExerciseService
    {
        IQueryable<Exercise> GetExercisesAsQueryable();
        Task<Exercise> GetExerciseByIdAsync(int id);
        Task<List<Exercise>> GetAllExercisesAsync();
        Task<int> AddExerciseAsync(Exercise exercise);
        Task<bool> RemoveExerciseAsync(int id);
        Task<bool> UpdateExerciseAsync(Exercise exercise);
        Task SaveExecution(string userId, SaveExecutionViewModel viewModel);
        Task<int[]> GetCompletedExercisesIds(string userId);
    }
}
