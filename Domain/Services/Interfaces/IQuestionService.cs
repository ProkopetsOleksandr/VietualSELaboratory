using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IQuestionService
    {
        Task SaveQuestionAsync(int exerciseId, QuestionViewModel viewModel);
    }
}
