using Domain.UseCases.UserUseCases.Dto;
using Domain.UseCases.UserUseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromServices] IUserSignInUseCase useCase, UserSignIn userSignIn)
        {
            if (!ModelState.IsValid)
                return View(userSignIn);

            var result = await useCase.Execute(userSignIn);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(userSignIn);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromServices] IUserSignUpUseCase useCase, UserSignUp userSignUp)
        {
            if (!ModelState.IsValid)
                return View(userSignUp);

            var result = await useCase.Execute(userSignUp);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View(userSignUp);
        }

        public async Task<IActionResult> SignOut([FromServices] IUserSignOutUseCase useCase)
        {
            await useCase.Execute();

            return RedirectToAction("Index");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
