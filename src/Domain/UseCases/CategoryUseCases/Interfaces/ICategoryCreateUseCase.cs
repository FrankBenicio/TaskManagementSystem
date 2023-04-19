using Domain.UseCases.CategoryUseCases.Dto;

namespace Domain.UseCases.CategoryUseCases.Interfaces
{
    public interface ICategoryCreateUseCase
    {
        Task Execute(CategoryCreate model);
    }
}
