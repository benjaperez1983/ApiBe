using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Server.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddDatabase(
           this IServiceCollection services,
           IConfiguration configuration)
           => services
               .AddDbContext<ApiBEDbContext>(options => options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   x => x.MigrationsHistoryTable("__EFMigrationsHistory")));
    }
}
