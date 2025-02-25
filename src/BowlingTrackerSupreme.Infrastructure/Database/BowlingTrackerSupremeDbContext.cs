using BowlingTrackerSupreme.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BowlingTrackerSupreme.Infrastructure.Database;

public class BowlingTrackerSupremeDbContext(DbContextOptions<BowlingTrackerSupremeDbContext> options) 
    : DbContext(options)
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Roll> Rolls { get; set; }
    public DbSet<PlayerGame> PlayerGames { get; set; }
    public DbSet<Frame> Frames { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BowlingTrackerSupremeDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}