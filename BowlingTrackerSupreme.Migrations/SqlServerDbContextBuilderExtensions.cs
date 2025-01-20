using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BowlingTrackerSupreme.Migrations;

public static class SqlServerDbContextBuilderExtensions
{
    public static SqlServerDbContextOptionsBuilder AllowMigrationManagement(this SqlServerDbContextOptionsBuilder builder)
        => builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
}