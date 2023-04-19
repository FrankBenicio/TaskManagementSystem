
using Domain.UseCases.TaskUseCases.Dto;
using Domain.UseCases.TaskUseCases.Interfaces;

namespace Data.UseCases.TaskUseCases
{
    public class TaskCreateUseCase : ITaskCreateUseCase
    {
        private readonly TaskContext context;

        public TaskCreateUseCase(TaskContext context)
        {
            this.context = context;
        }

        public async Task Execute(TaskCreate model)
        {
            Domain.Models.Task task = model;

            context.Add(task);

            await context.SaveChangesAsync();
        }
    }
}
