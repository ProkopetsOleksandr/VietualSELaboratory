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
        private readonly IRepository<Statistics> _statisticsRepository;
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<UserAnswers> _userAnswersRepository;
        public ExerciseService(
            IRepository<Exercise> exerciseRepository, 
            IRepository<Statistics> statisticsRepository, 
            IRepository<Question> questionRepository,
            IRepository<UserAnswers> userAnswersRepository)
        {
            _exerciseRepository = exerciseRepository;
            _statisticsRepository = statisticsRepository;
            _questionRepository = questionRepository;
            _userAnswersRepository = userAnswersRepository;
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

        public async Task<int[]> GetCompletedExercisesIds(string userId)
        {
            return await _statisticsRepository
                .GetAll()
                .Where(m => m.UserId == userId)
                .Select(m => m.ExerciseId).ToArrayAsync();
        }

        public async Task<Exercise> GetExerciseByIdAsync(int id)
        {
            return await _exerciseRepository
                .GetAll()
                .Include(m => m.Level)
                .Include(m => m.Questions)
                .ThenInclude(m => m.Answers)
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();
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

        public async Task SaveExecution(string userId, SaveExecutionViewModel viewModel)
        {
            var grade = GetGrade(viewModel.Answers);
            var statistics = new Statistics()
            {
                ExerciseId = viewModel.ExerciseId,
                UserId = userId,
                Grade = grade,
                ExecutionDate = DateTime.Now
            };

            _statisticsRepository.Add(statistics);
            await _statisticsRepository.SaveChangesAsync();

            foreach (var answer in viewModel.Answers)
            {
                _userAnswersRepository.Add(new UserAnswers()
                {
                    StatisticsId = statistics.Id,
                    QuestionId = answer.QuestionId,
                    CorrectAnswers = string.Join(",", answer.Correct),
                    IncorrectAnswers = string.Join(",", answer.Incorrect)
                }); 
            }

            await _userAnswersRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateExerciseAsync(Exercise exercise)
        {
            _exerciseRepository.Update(exercise);
            var affectedRows = await _exerciseRepository.SaveChangesAsync();
            return affectedRows > 0;
        }

        private double GetGrade(List<SaveAnswerViewModel> answers)
        {
            var ids = answers.Select(m => m.QuestionId);
            var questions = _questionRepository
                .GetAll()
                .Include(m => m.Answers)
                .Where(m => ids.Contains(m.Id));

            // this is temporary approach
            return questions.Count();
        }
    }
}
