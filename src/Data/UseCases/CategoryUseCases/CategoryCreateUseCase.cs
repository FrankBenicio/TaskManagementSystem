using Domain.Models;
using Domain.UseCases.CategoryUseCases.Dto;
using Domain.UseCases.CategoryUseCases.Interfaces;

namespace Data.UseCases.CategoryUseCases
{
    public class CategoryCreateUseCase : ICategoryCreateUseCase
    {
        private readonly TaskContext context;

        public CategoryCreateUseCase(TaskContext context)
        {
            this.context = context;
        }

        public async System.Threading.Tasks.Task Execute(CategoryCreate model)
        {
            Category category = model;

            context.Add(category);
            await context.SaveChangesAsync();
        }
    }
}
