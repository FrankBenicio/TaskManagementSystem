using Domain.UseCases.TaskUseCases.Dto;
using Domain.UseCases.TaskUseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.UseCases.TaskUseCases
{
    public class TaskListUseCase : ITaskListUseCase
    {
        private readonly TaskContext context;

        public TaskListUseCase(TaskContext context)
        {
            this.context = context;
        }

        public async Task<List<TaskItem>> Execute(string userId)
        {
            var tasks = await context.Tasks.Include(x => x.Category).Where(x => x.UserId == userId).ToListAsync();

            return tasks.Select(x =>
            {
                TaskItem task = x;

                return task;

            }).ToList();
        }
    }
}
