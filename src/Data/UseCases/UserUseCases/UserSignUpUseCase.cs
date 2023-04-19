using Domain.Models;
using Domain.UseCases.UserUseCases.Dto;
using Domain.UseCases.UserUseCases.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Data.UseCases.UserUseCases
{
    public class UserSignUpUseCase : IUserSignUpUseCase
    {
        private readonly UserManager<User> userManager;

        public UserSignUpUseCase(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> Execute(UserSignUp model)
        {
            User user = model;

            var result = await userManager.CreateAsync(user, user.Password);

            return result;
        }
    }
}
