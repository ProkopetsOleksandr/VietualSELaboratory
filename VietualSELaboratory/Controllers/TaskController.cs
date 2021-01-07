using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.RDBMS.Entities;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public TaskController(
            IExerciseService exerciseService, 
            ILevelService levelService, 
            IQuestionService questionService, 
            UserManager<ApplicationUser> userManager)
        {
            _exerciseService = exerciseService;
            _levelService = levelService;
            _questionService = questionService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            var completedTasks = await _exerciseService.GetCompletedExercisesIds(applicationUser.Id);

            var query = _exerciseService.GetExercisesAsQueryable().AsNoTracking().OrderBy(m => m.Id);
            var exercises = await PagingList.CreateAsync(query, 5, page);

            var viewModel = new ShowTasksViewModel()
            {
                CompletedTasksIds = completedTasks,
                Exercises = exercises
            };
            return View(viewModel);
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

        public async Task<ActionResult> View(int taskId)
        {
            var exercise = await _exerciseService.GetExerciseByIdAsync(taskId);
            var questions = await _questionService.GetQuestionsWithAnswers(exercise.Id);

            var viewModel = new ExerciseViewViewModel()
            {
                Exercise = exercise,
                Questions = questions
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Save(SaveExerciseViewModel viewModel)
        {
            var exerciseId = await _exerciseService.AddExerciseAsync(viewModel.Exercise);

            foreach (var question in viewModel.QuestionViewModels)
            {
                await _questionService.SaveQuestionAsync(exerciseId, question);
            }

            return Ok();
        }

        public async Task<ActionResult> Execute(int taskId)
        {
            var exercise = await _exerciseService.GetExerciseByIdAsync(taskId);
            return View(exercise);
        }

        public async Task<ActionResult> SaveExecution(SaveExecutionViewModel viewModel)
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            await _exerciseService.SaveExecution(applicationUser.Id, viewModel);
            return Ok();
        }
    }
}