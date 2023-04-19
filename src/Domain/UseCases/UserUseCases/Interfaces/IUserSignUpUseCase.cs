using Domain.UseCases.UserUseCases.Dto;
using Microsoft.AspNetCore.Identity;

namespace Domain.UseCases.UserUseCases.Interfaces
{
    public interface IUserSignUpUseCase
    {
        Task<IdentityResult> Execute(UserSignUp model);
    }
}
