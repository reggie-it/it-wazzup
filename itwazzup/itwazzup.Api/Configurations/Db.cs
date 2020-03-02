using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using itwazzup.Persistence.Context;

namespace itwazzup.Api.Configurations
{
    public static class Db
    {
        internal static void RegisterEntityFramework(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<itwazzupDbContext>(opts =>
            {
                opts.UseSqlServer(configuration.GetConnectionString("Default"));
            });
        }

        internal static void ConfigureDatabaseMigrations(itwazzupDbContext context)
        {
            //Check if there are any pending migrations
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        internal static void SeedDatabase(itwazzupDbContext context)
        {

        }
    }
}