using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VietualSELaboratory.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Teacher")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
