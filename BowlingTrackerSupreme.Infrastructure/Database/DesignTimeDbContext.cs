using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BowlingTrackerSupreme.Infrastructure.Database;

public class DesignTimeDbContext : IDesignTimeDbContextFactory<BowlingTrackerSupremeDbContext>
{
    public BowlingTrackerSupremeDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BowlingTrackerSupremeDbContext>();
        optionsBuilder.UseSqlServer();
            
        return new BowlingTrackerSupremeDbContext(optionsBuilder.Options);
    }
}
