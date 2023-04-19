using Domain.UseCases.CategoryUseCases.Dto;
using Domain.UseCases.CategoryUseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.UseCases.CategoryUseCases
{
    public class CategoryItemUseCase : ICategoryItemUseCase
    {
        public readonly TaskContext context;

        public CategoryItemUseCase(TaskContext context)
        {
            this.context = context;
        }

        public async Task<CategoryItem> Execute(Guid id)
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return category;
        }
    }
}
