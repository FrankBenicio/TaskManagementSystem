using Data.UseCases.CategoryUseCases;
using Data.UseCases.TaskUseCases;
using Data.UseCases.UserUseCases;
using Domain.UseCases.CategoryUseCases.Interfaces;
using Domain.UseCases.TaskUseCases.Interfaces;
using Domain.UseCases.UserUseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class Cfg
    {
        public static void AddCfgData(this IServiceCollection services)
        {
            //Category
            services.AddTransient<ICategoryUpdateUseCase, CategoryUpdateUseCase>();
            services.AddTransient<ICategoryListUseCase, CategoryListUseCase>();
            services.AddTransient<ICategoryItemUseCase, CategoryItemUseCase>();
            services.AddTransient<ICategoryCreateUseCase, CategoryCreateUseCase>();


            //Task
            services.AddTransient<ITaskCreateUseCase, TaskCreateUseCase>();
            services.AddTransient<ITaskInProgressUseCase, TaskInProgressUseCase>();
            services.AddTransient<ITaskCompletedUseCase, TaskCompletedUseCase>();
            services.AddTransient<ITaskListUseCase, TaskListUseCase>();
            services.AddTransient<ITaskItemUseCase, TaskItemUseCase>();
            services.AddTransient<ITaskPendingUseCase, TaskPendingUseCase>();

            //User
            services.AddTransient<IUserSignUpUseCase, UserSignUpUseCase>();
            services.AddTransient<IUserSignInUseCase, UserSignInUseCase>();
            services.AddTransient<IUserSignOutUseCase, UserSignOutUseCase>();
        }
    }
}
