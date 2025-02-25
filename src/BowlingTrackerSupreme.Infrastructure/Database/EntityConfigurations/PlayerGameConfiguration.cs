using BowlingTrackerSupreme.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BowlingTrackerSupreme.Infrastructure.Database.EntityConfigurations;

public class PlayerGameConfiguration : IEntityTypeConfiguration<PlayerGame> 
{
    public void Configure(EntityTypeBuilder<PlayerGame> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Frames)
            .WithOne(x => x.PlayerGame)
            .HasForeignKey(x => x.PlayerGameId);
    }
}