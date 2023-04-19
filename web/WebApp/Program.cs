using Data;
using Domain.Models;
using Infra;
using Microsoft.AspNetCore.Identity;
using Task = System.Threading.Tasks.Task;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddCfgDatabase(builder.Configuration);
            builder.Services.AddCfgIdentity(builder.Configuration);
            builder.Services.AddCfgData();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Index";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            builder.Services.AddAuthentication();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            using (var scope = app.Services.CreateScope())
            {

                var serviceProvider = scope.ServiceProvider;
                CreateUser.Executar(serviceProvider).Wait();
            }

            app.Run();
        }
    }

    public static class CreateUser
    {
        public static async Task Executar(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            var user = new User
            {
                Email = "user1@task.com",
                EmailConfirmed = true,
                UserName = "user1@task.com",
                Name = "User 01"
            };
            User userExist = await userManager.FindByNameAsync(user.Email);

            if (userExist is null)
            {
                var result = await userManager.CreateAsync(user, "Admin@10314039");

            }
        }
    }
}