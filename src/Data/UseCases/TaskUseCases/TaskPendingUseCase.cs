using Domain.UseCases.TaskUseCases.Interfaces;

namespace Data.UseCases.TaskUseCases
{
    public class TaskPendingUseCase : ITaskPendingUseCase
    {
        private readonly TaskContext context;

        public TaskPendingUseCase(TaskContext context)
        {
            this.context = context;
        }

        public async Task Execute(Guid id)
        {
            var task = await context.Tasks.FindAsync(id);

            task?.Pending();

            await context.SaveChangesAsync();
        }
    }
}
