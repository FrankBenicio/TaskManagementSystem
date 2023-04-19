using Domain.Models;
using Domain.UseCases.UserUseCases.Dto;
using Domain.UseCases.UserUseCases.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Data.UseCases.UserUseCases
{
    public class UserSignInUseCase : IUserSignInUseCase
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        public UserSignInUseCase(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<SignInResult> Execute(UserSignIn model)
        {
            var user = await userManager.FindByNameAsync(model.Email);
            
            var result = await signInManager.PasswordSignInAsync(user: user, isPersistent: false, password: model.Password, lockoutOnFailure: true);
            
            return result;
        }
    }
}
