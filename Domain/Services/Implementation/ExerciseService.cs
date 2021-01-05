using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.RDBMS;
using Domain.RDBMS.Entities;
using Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.Implementation
{
    public class ExerciseService : IExerciseService
    {
        private readonly IRepository<Exercise> _exerciseRepository;
        public ExerciseService(IRepository<Exercise> exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<int> AddExerciseAsync(Exercise exercise)
        {
            if (exercise == null)
            {
                throw new ArgumentException("Exercise was null");
            }

            _exerciseRepository.Add(exercise);
            await _exerciseRepository.SaveChangesAsync();

            return exercise.Id;
        }

        public async Task<List<Exercise>> GetAllExercisesAsync()
        {
            return await _exerciseRepository.GetAll().ToListAsync();
        }

        public async Task<Exercise> GetExerciseByIdAsync(int id)
        {
            return await _exerciseRepository.FindByIdAsync(id);
        }

        public IQueryable<Exercise> GetExercisesAsQueryable()
        {
            return _exerciseRepository.GetAll();
        }

        public async Task<bool> RemoveExerciseAsync(int id)
        {
            var entity = await _exerciseRepository.FindByIdAsync(id);
            if (entity == null)
            {
                return false;
            }

            _exerciseRepository.Remove(entity);
            var affectedRows = await _exerciseRepository.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> UpdateExerciseAsync(Exercise exercise)
        {
            _exerciseRepository.Update(exercise);
            var affectedRows = await _exerciseRepository.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}
