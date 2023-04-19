using AutoFixture;
using Data.Tests.Context;
using Data.UseCases.CategoryUseCases;
using Domain.Models;
using Domain.UseCases.CategoryUseCases.Dto;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Task = System.Threading.Tasks.Task;

namespace Data.Tests.UseCasesTests.CategoryUsesCasesTests
{
    public class CategoryUpdateUseCaseTests
    {

        [Fact]
        public async Task ShouldNotUpdateCategory()
        {
            var mockDatabase = await ContextFake.Run();
            var fixture = new Fixture();

            CategoryItem model = null;

            var useCase = new CategoryUpdateUseCase(mockDatabase);


            Func<Task> act = () => useCase.Execute(model);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(act);

            var result = await mockDatabase.Categories.FirstOrDefaultAsync();

            Assert.Null(result);
            Assert.Equal("Value cannot be null. (Parameter 'model')", exception.Message);
        }
    }
}
