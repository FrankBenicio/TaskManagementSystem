using Domain.UseCases.CategoryUseCases.Dto;

namespace Domain.UseCases.CategoryUseCases.Interfaces
{
    public interface ICategoryListUseCase
    {
        Task<List<CategoryItem>> Execute(string userId);
    }
}
