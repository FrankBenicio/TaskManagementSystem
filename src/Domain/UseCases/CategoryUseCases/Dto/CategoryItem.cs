using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Domain.UseCases.CategoryUseCases.Dto
{
    public class CategoryItem
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? UserId { get; set; }

        public static implicit operator Category(CategoryItem model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            return new Category(model.Name, model.UserId, model.Id);
        }

        public static implicit operator CategoryItem(Category model)
        {
            if (model is null)
                return null;

            return new CategoryItem
            {
                Id = model.Id,
                Name = model.Name,
                UserId = model.UserId,
            };
        }
    }
}
