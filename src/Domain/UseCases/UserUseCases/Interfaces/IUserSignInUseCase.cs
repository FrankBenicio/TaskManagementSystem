using Domain.UseCases.UserUseCases.Dto;
using Microsoft.AspNetCore.Identity;

namespace Domain.UseCases.UserUseCases.Interfaces
{
    public interface IUserSignInUseCase
    {
        Task<SignInResult> Execute(UserSignIn model);
    }
}
