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
    public class CategoryListUseCaseTests
    {
        [Fact]
        public async Task ShouldReturnCategories()
        {
            var mockDatabase = await ContextFake.Run();
            var fixture = new Fixture();
            var model = fixture.Create<Category>();
            
             mockDatabase.Categories.Add(model);
            await mockDatabase.SaveChangesAsync();

            var useCase = new CategoryListUseCase(mockDatabase);

           var result = await useCase.Execute(model.UserId);

            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task ShouldNotReturnCategories()
        {
            var mockDatabase = await ContextFake.Run();

            var useCase = new CategoryListUseCase(mockDatabase);

            var result = await useCase.Execute(Guid.NewGuid().ToString());

            Assert.True(result.Count == 0);
        }
    }
}
