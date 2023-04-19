using Domain.UseCases.CategoryUseCases.Dto;
using Domain.UseCases.CategoryUseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.UseCases.CategoryUseCases
{
    public class CategoryListUseCase : ICategoryListUseCase
    {
        public readonly TaskContext context;

        public CategoryListUseCase(TaskContext context)
        {
            this.context = context;
        }

        public async Task<List<CategoryItem>> Execute(string userId)
        {
            var category = 
                await context.Categories
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return category.Select(x =>
            {
                CategoryItem category = x;

                return category;

            }).ToList();
        }
    }
}
