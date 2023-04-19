using Domain.UseCases.TaskUseCases.Dto;

namespace Domain.UseCases.TaskUseCases.Interfaces
{
    public interface ITaskCreateUseCase
    {
        Task Execute(TaskCreate model);
    }
}
