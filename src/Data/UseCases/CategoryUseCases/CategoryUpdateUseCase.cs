using Domain.UseCases.CategoryUseCases.Dto;
using Domain.UseCases.CategoryUseCases.Interfaces;

namespace Data.UseCases.CategoryUseCases
{
    public class CategoryUpdateUseCase : ICategoryUpdateUseCase
    {
        private readonly TaskContext context;

        public CategoryUpdateUseCase(TaskContext context)
        {
            this.context = context;
        }

        public async Task Execute(CategoryItem model)
        {
            Domain.Models.Category category = model;

            context.Categories.Update(category);

            await context.SaveChangesAsync();
        }
    }
}
