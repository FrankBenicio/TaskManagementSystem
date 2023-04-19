using Domain.UseCases.CategoryUseCases.Dto;

namespace Domain.UseCases.CategoryUseCases.Interfaces
{
    public interface ICategoryItemUseCase
    {
        Task<CategoryItem> Execute(Guid id);
    }
}
