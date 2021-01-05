using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.RDBMS.Entities;

namespace Domain.Services.Interfaces
{
    public interface IQuestionService
    {
        Task SaveQuestionAsync(int exerciseId, QuestionViewModel viewModel);
        Task<List<Question>> GetQuestionsWithAnswers(int exerciseId);
    }
}
