using BowlingTrackerSupreme.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace BowlingTrackerSupreme.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddBowlingTrackerSupremeInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration, 
        Action<NpgsqlDbContextOptionsBuilder>? sqlServerBuilder = null)
    {
        services.AddDbContext<BowlingTrackerSupremeDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(nameof(BowlingTrackerSupremeDbContext)), builder =>
            {
                builder.MigrationsAssembly(typeof(BowlingTrackerSupremeDbContext).Assembly.FullName);
                builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                
                sqlServerBuilder?.Invoke(builder);
            });
        });
    }
}