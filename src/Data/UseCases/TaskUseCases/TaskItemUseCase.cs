using Domain.UseCases.TaskUseCases.Dto;
using Domain.UseCases.TaskUseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.UseCases.TaskUseCases
{
    public class TaskItemUseCase : ITaskItemUseCase
    {
        private readonly TaskContext context;

        public TaskItemUseCase(TaskContext context)
        {
            this.context = context;
        }

        public async Task<TaskItem> Execute(Guid id)
        {
            var task = await context.Tasks.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);

            return task;
        }
    }
}
