using System.Linq;
using System.Threading.Tasks;
using Domain.RDBMS.Entities;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using VietualSELaboratory.ViewModel;

namespace VietualSELaboratory.Controllers
{

    [Authorize]
    public class TaskController : Controller
    {
        private readonly IExerciseService _exerciseService;
        private readonly ILevelService _levelService;
        private readonly IQuestionService _questionService;

        public TaskController(IExerciseService exerciseService, ILevelService levelService, IQuestionService questionService)
        {
            _exerciseService = exerciseService;
            _levelService = levelService;
            _questionService = questionService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var query = _exerciseService.GetExercisesAsQueryable().AsNoTracking().OrderBy(m => m.Id);
            var model = await PagingList.CreateAsync(query, 5, page);
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var viewModel = new ExerciseViewModel()
            {
                Exercise = new Exercise(),
                Levels = await _levelService.GetAllLevelsAsync()
            };
            return View("TaskForm", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Save(SaveExerciseViewModel viewModel)
        {
            var exerciseId = await _exerciseService.AddExerciseAsync(viewModel.Exercise);

            foreach (var question in viewModel.QuestionViewModels)
            {
                await _questionService.SaveQuestionAsync(exerciseId, question);
            }

            return Content("Success");
        }
    }
}
