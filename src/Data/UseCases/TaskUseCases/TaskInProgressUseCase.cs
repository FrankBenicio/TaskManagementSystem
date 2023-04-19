using Domain.UseCases.TaskUseCases.Interfaces;

namespace Data.UseCases.TaskUseCases
{
    public class TaskInProgressUseCase : ITaskInProgressUseCase
    {
        private readonly TaskContext context;

        public TaskInProgressUseCase(TaskContext context)
        {
            this.context = context;
        }

        public async Task Execute(Guid id)
        {
            var task = await context.Tasks.FindAsync(id);

            task?.InProgress();

            await context.SaveChangesAsync();
        }
    }
}
