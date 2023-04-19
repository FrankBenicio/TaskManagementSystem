using AutoFixture;
using Data.Tests.Context;
using Data.UseCases.CategoryUseCases;
using Domain.UseCases.CategoryUseCases.Dto;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Data.Tests.UseCasesTests.CategoryUsesCasesTests
{
    public class CategoryCreateUseCaseTests
    {
        [Fact]
        public async Task ShouldCreateCategory()
        {
            var mockDatabase = await ContextFake.Run();
            var fixture = new Fixture();
            var model = fixture.Create<CategoryCreate>();

            var useCase = new CategoryCreateUseCase(mockDatabase);

            await useCase.Execute(model);

            var result = await mockDatabase.Categories.FirstOrDefaultAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNotCreateCategory()
        {
            var mockDatabase = await ContextFake.Run();
            var fixture = new Fixture();

            CategoryCreate model = null;

            var useCase = new CategoryCreateUseCase(mockDatabase);


            Func<Task> act = () => useCase.Execute(model);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(act);

            var result = await mockDatabase.Categories.FirstOrDefaultAsync();

            Assert.Null(result);
            Assert.Equal("Value cannot be null. (Parameter 'model')", exception.Message);
        }
    }
}
