using AutoFixture;
using Data.Tests.Context;
using Data.UseCases.CategoryUseCases;
using Data.UseCases.TaskUseCases;
using Domain.Models;
using Domain.UseCases.CategoryUseCases.Dto;
using Domain.UseCases.TaskUseCases.Dto;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Data.Tests.UseCasesTests.TaskUseCasesTests
{
    public class TaskCreateUseCaseTests
    {
        [Fact]
        public async Task ShouldCreateTask()
        {
            var mockDatabase = await ContextFake.Run();
            var fixture = new Fixture();

            var category = fixture.Create<Category>();
            mockDatabase.Categories.Add(category);  

            await mockDatabase.SaveChangesAsync();

            var model = fixture.Create<TaskCreate>();
            model.CategoryId = category.Id;

            var useCase = new TaskCreateUseCase(mockDatabase);

            await useCase.Execute(model);

            var result = await mockDatabase.Categories.FirstOrDefaultAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNotCreateTask()
        {
            var mockDatabase = await ContextFake.Run();
            var fixture = new Fixture();

            TaskCreate model = null;

            var useCase = new TaskCreateUseCase(mockDatabase);


            Func<Task> act = () => useCase.Execute(model);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(act);

            var result = await mockDatabase.Tasks.FirstOrDefaultAsync();

            Assert.Null(result);
            Assert.Equal("Value cannot be null. (Parameter 'model')", exception.Message);
        }
    }
}
