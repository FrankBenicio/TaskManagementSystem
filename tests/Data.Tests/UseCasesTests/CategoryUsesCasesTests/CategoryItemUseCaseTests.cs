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
    public class CategoryItemUseCaseTests
    {
        [Fact]
        public async Task ShouldReturnCategory()
        {
            var mockDatabase = await ContextFake.Run();
            var fixture = new Fixture();
            var model = fixture.Create<Category>();
            
             mockDatabase.Categories.Add(model);
            await mockDatabase.SaveChangesAsync();

            var useCase = new CategoryItemUseCase(mockDatabase);

           var result = await useCase.Execute(model.Id);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNotReturnCategory()
        {
            var mockDatabase = await ContextFake.Run();

            var useCase = new CategoryItemUseCase(mockDatabase);

            var result = await useCase.Execute(Guid.NewGuid());

            Assert.Null(result);
        }
    }
}
