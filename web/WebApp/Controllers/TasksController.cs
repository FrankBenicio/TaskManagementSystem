using Domain.UseCases.CategoryUseCases.Interfaces;
using Domain.UseCases.TaskUseCases.Dto;
using Domain.UseCases.TaskUseCases.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace WebApp.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        public async Task<IActionResult> Index([FromServices] ITaskListUseCase useCase)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await useCase.Execute(userId);

            return View(result);
        }

        public async Task<IActionResult> Create([FromServices] ICategoryListUseCase useCase)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var categories = await useCase.Execute(userId);
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromServices] ICategoryListUseCase categoryUseCase, [FromServices] ITaskCreateUseCase useCase, TaskCreate model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.UserId = userId;

            if (!ModelState.IsValid)
            {
                var categories = await categoryUseCase.Execute(userId);
                ViewBag.Categories = new SelectList(categories, "Id", "Name", model.CategoryId);
                return View(model);

            }

            await useCase.Execute(model);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Details([FromServices] ITaskItemUseCase useCase, Guid id)
        {
            var result = await useCase.Execute(id);

            return View(result);
        }

        
        public async Task<IActionResult> InProgress([FromServices] ITaskInProgressUseCase useCase, Guid id)
        {      
            await useCase.Execute(id);

            return RedirectToAction("Details", new { id });

        }

       
        public async Task<IActionResult> Completed([FromServices] ITaskCompletedUseCase useCase, Guid id)
        {      
            await useCase.Execute(id);

            return RedirectToAction("Details", new { id });

        }

        public async Task<IActionResult> Pending([FromServices] ITaskPendingUseCase useCase, Guid id)
        {      
            await useCase.Execute(id);

            return RedirectToAction("Details", new { id });

        }
    }
}
