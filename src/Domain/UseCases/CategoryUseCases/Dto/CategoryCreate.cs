using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Domain.UseCases.CategoryUseCases.Dto
{
    public class CategoryCreate
    {
        [Required]
        public string Name { get; set; }
        public string? UserId { get; set; }

        public static implicit operator Category(CategoryCreate model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            return new Category(model.Name, model.UserId, Guid.NewGuid());
        }
    }
}
