namespace Domain.UseCases.TaskUseCases.Interfaces
{
    public interface ITaskPendingUseCase
    {
        Task Execute(Guid id);
    }
}
