using Domain.UseCases.CategoryUseCases.Dto;

namespace Domain.UseCases.CategoryUseCases.Interfaces
{
    public interface ICategoryUpdateUseCase
    {
        Task Execute(CategoryItem model);
    }
}
