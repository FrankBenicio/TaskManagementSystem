using Domain.UseCases.TaskUseCases.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index([FromServices] ITaskListUseCase useCase)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await useCase.Execute(userId);

            ViewBag.Pending = result.Count(x => x.Status == Domain.Enums.Status.Pending);
            ViewBag.InProgress = result.Count(x => x.Status == Domain.Enums.Status.InProgress);
            ViewBag.Completed = result.Count(x => x.Status == Domain.Enums.Status.Completed);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}