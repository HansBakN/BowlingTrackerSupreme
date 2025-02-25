using System.Reflection;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace BowlingTrackerSupreme.Migrations;

public static class SqlServerDbContextBuilderExtensions
{
    public static NpgsqlDbContextOptionsBuilder AllowMigrationManagement(this NpgsqlDbContextOptionsBuilder builder)
        => builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
}