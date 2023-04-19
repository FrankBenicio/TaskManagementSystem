using Domain.UseCases.CategoryUseCases.Dto;
using Domain.UseCases.CategoryUseCases.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApp.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        public async Task<IActionResult> Index([FromServices] ICategoryListUseCase useCase)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await useCase.Execute(userId);

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromServices] ICategoryCreateUseCase useCase, CategoryCreate model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.UserId = userId;

            if (!ModelState.IsValid)
                return View(model);

            await useCase.Execute(model);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit([FromServices] ICategoryItemUseCase useCase, Guid id)
        {
            var category = await useCase.Execute(id);

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromServices] ICategoryUpdateUseCase useCase, CategoryItem model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.UserId = userId;

            if (!ModelState.IsValid)
                return View(model);

            await useCase.Execute(model);

            return RedirectToAction("Index");

        }
    }
}
