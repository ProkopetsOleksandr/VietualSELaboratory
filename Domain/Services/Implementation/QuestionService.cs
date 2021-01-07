using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.RDBMS;
using Domain.RDBMS.Entities;
using Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Domain.Services.Implementation
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Answer> _answerRepository;
        public QuestionService(IRepository<Question> questionRepository, IRepository<Answer> answerRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }

        public async Task<List<Question>> GetQuestionsWithAnswers(int exerciseId)
        {
            return await _questionRepository.GetAll().Where(m => m.ExerciseId == exerciseId).Include(m => m.Answers).ToListAsync();
        }

        public async Task SaveQuestionAsync(int exerciseId, QuestionViewModel viewModel)
        {
            var question = new Question()
            {
                ExerciseId = exerciseId,
                Text = viewModel.Text
            };

            _questionRepository.Add(question);
            await _questionRepository.SaveChangesAsync();

            if (viewModel.Correct != null && viewModel.Correct.Any())
            {
                foreach (var correct in viewModel.Correct)
                {
                    _answerRepository.Add(new Answer()
                    {
                        QuestionId = question.Id,
                        Text = correct,
                        IsCorrect = true
                    });
                }
            }

            if (viewModel.Incorrect != null && viewModel.Incorrect.Any())
            {
                foreach (var incorrect in viewModel.Incorrect)
                {
                    _answerRepository.Add(new Answer()
                    {
                        QuestionId = question.Id,
                        Text = incorrect,
                        IsCorrect = false
                    });
                }
            }

            await _answerRepository.SaveChangesAsync();
        }
    }
}
