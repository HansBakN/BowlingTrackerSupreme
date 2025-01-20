using BowlingTrackerSupreme.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BowlingTrackerSupreme.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddBowlingTrackerSupremeInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration, 
        Action<SqlServerDbContextOptionsBuilder>? sqlServerBuilder)
    {
        services.AddDbContext<BowlingTrackerSupremeDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(nameof(BowlingTrackerSupremeDbContext)),
                sqlServerBuilder);
        });
        
        services.AddDbContextFactory<BowlingTrackerSupremeDbContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString(nameof(BowlingTrackerSupremeDbContext)), 
                x => x.MigrationsAssembly("BowlingTrackerSupreme.Migrations")));
    }
}