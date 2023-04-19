namespace Domain.UseCases.TaskUseCases.Interfaces
{
    public interface ITaskInProgressUseCase
    {
        Task Execute(Guid id);
    }
}
