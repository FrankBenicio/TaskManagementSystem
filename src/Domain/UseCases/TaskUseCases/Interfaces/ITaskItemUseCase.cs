using Domain.UseCases.TaskUseCases.Dto;

namespace Domain.UseCases.TaskUseCases.Interfaces
{
    public interface ITaskItemUseCase
    {
        Task<TaskItem> Execute(Guid id);
    }
}
