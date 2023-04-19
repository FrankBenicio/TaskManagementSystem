using AutoFixture;
using Data.Tests.Context;
using Data.UseCases.TaskUseCases;
using Domain.Enums;
using Domain.Models;
using Domain.UseCases.TaskUseCases.Dto;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Data.Tests.UseCasesTests.TaskUseCasesTests
{
    public class TaskPendingUseCaseTests
    {
        [Fact]
        public async Task ShouldPendingTask()
        {
            var mockDatabase = await ContextFake.Run();
            var fixture = new Fixture();

            var category = fixture.Create<Category>();
            mockDatabase.Categories.Add(category);

            await mockDatabase.SaveChangesAsync();

            var model = fixture.Create<TaskCreate>();
            model.CategoryId = category.Id;

            var useCaseCreate = new TaskCreateUseCase(mockDatabase);

            await useCaseCreate.Execute(model);

            var useCase = new TaskPendingUseCase(mockDatabase);

            var task = await mockDatabase.Tasks.FirstOrDefaultAsync();

            await useCase.Execute(task.Id);

            var taskPending = await mockDatabase.Tasks.FirstOrDefaultAsync();

            Assert.Equal(Status.Pending, taskPending.Status);

        }
    }
}
