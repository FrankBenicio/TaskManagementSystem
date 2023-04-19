using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Context
{
    public static class ContextFake
    {
        public static async Task<TaskContext> Run()
        {
            var options = new DbContextOptionsBuilder<TaskContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new TaskContext(options);

            return await Task.FromResult(context);
        }
    }
}
