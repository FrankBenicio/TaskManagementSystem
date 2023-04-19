using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Domain.UseCases.UserUseCases.Dto
{
    public class UserSignUp
    {
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Tough passwords don't match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }

        public static implicit operator User(UserSignUp model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            return new User
            {
                Email = model.Email,
                EmailConfirmed = true,
                UserName = model.Email,
                Name = model.Name,
                Password = model.Password,
            };
        }
    }
}
