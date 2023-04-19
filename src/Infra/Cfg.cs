using Infra.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Infra
{
    [ExcludeFromCodeCoverage]
    public static class Cfg
    {
        public static void AddCfgDatabase(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<TaskContext>(x =>
                   x.EnableSensitiveDataLogging()
                    .UseSqlServer(connectionString: Configuration.GetConnectionString("Database"), sqlServerOptionsAction: sqlOptions => sqlOptions.EnableRetryOnFailure())
               );
        }

        public static void AddCfgIdentity(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<IdentityContext>(x =>
                x.UseSqlServer(connectionString: Configuration.GetConnectionString("Database"), sqlServerOptionsAction: sqlOptions => sqlOptions.EnableRetryOnFailure())
            );

            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<IdentityContext>()
                    .AddDefaultTokenProviders();
        }
    }
}
