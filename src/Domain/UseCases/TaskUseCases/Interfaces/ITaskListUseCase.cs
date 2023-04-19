using Domain.UseCases.TaskUseCases.Dto;

namespace Domain.UseCases.TaskUseCases.Interfaces
{
    public interface ITaskListUseCase
    {
        Task<List<TaskItem>> Execute(string userId);
    }
}
