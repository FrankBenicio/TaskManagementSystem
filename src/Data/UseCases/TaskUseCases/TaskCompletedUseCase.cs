using Domain.UseCases.TaskUseCases.Interfaces;

namespace Data.UseCases.TaskUseCases
{
    public class TaskCompletedUseCase : ITaskCompletedUseCase
    {
        private readonly TaskContext context;

        public TaskCompletedUseCase(TaskContext context)
        {
            this.context = context;
        }

        public async Task Execute(Guid id)
        {
            var task = await context.Tasks.FindAsync(id);

            task?.Completed();

            await context.SaveChangesAsync();
        }
    }
}
