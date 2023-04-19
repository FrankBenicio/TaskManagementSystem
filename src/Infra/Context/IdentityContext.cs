using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Context
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public IConfiguration Configuration { get; }

        public IdentityContext(IConfiguration configuration, DbContextOptions<IdentityContext> options) : base(options)
        {
            Configuration = configuration;
        }

    }
}
