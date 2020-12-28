using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.RDBMS.Entities;

namespace Domain.Services.Interfaces
{
    public interface IExerciseService
    {
        Task<Exercise> GetExerciseByIdAsync(int id);
        Task<List<Exercise>> GetAllExercisesAsync();
        Task<int> AddExerciseAsync(Exercise exercise);
        Task<bool> RemoveExerciseAsync(int id);
        Task<bool> UpdateExerciseAsync(Exercise exercise);
    }
}
