using Domain.Models;
using Domain.UseCases.UserUseCases.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Data.UseCases.UserUseCases
{
    public class UserSignOutUseCase : IUserSignOutUseCase
    {
        private readonly SignInManager<User> _signInManager;

        public UserSignOutUseCase(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async System.Threading.Tasks.Task Execute()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
