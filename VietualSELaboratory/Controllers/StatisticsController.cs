using System.Linq;
using System.Threading.Tasks;
using Domain.RDBMS.Entities;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace VietualSELaboratory.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStatisticsService _statisticsService;
        public StatisticsController(UserManager<ApplicationUser> userManager, IStatisticsService statisticsService)
        {
            _userManager = userManager;
            _statisticsService = statisticsService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            var statistics = _statisticsService.GetAllStatistics(applicationUser.Id).AsNoTracking().OrderByDescending(m => m.ExecutionDate);
            var paginatedStatistics = await PagingList.CreateAsync(statistics, 5, page);

            return View(paginatedStatistics);
        }

        public async Task<IActionResult> TaskOverview(int statisticsId)
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            var statistics = await _statisticsService.GetStatisticsById(statisticsId);

            return View(statistics);
        }
    }
}
