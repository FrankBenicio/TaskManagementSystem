using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        [NotMapped]
        public string Password { get; set; }
    }
}
