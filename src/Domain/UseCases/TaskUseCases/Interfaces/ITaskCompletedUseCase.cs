namespace Domain.UseCases.TaskUseCases.Interfaces
{
    public interface ITaskCompletedUseCase
    {
        Task Execute(Guid id);
    }
}
