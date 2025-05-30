using BowlingTrackerSupreme.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BowlingTrackerSupreme.Infrastructure.Database;

public class BowlingTrackerSupremeDbContext(DbContextOptions<BowlingTrackerSupremeDbContext> options) 
    : DbContext(options)
{
    public DbSet<Player> PlayerSet { get; set; }
    public DbSet<Game> GameSet { get; set; }
    public DbSet<PlayerNickname> PlayerNicknameSet { get; set; }
    public DbSet<GamePlayer> GamePlayerSet { get; set; }
    public DbSet<Frame> FrameSet { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BowlingTrackerSupremeDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}