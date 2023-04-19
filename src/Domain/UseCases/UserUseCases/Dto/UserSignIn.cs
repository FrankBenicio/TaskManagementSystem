using System.ComponentModel.DataAnnotations;

namespace Domain.UseCases.UserUseCases.Dto
{
    public class UserSignIn
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
