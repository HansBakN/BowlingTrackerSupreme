using BowlingTrackerSupreme.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BowlingTrackerSupreme.Infrastructure.Database.EntityConfigurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany<Player>(x => x.Participants)
            .WithMany(x => x.GameParticipation);
        builder.HasOne(x => x.WinningPlayer)
            .WithMany()
            .HasForeignKey(x => x.WinningPlayerId);
        builder.HasMany(x => x.PlayerGames)
            .WithOne(x => x.Game)
            .HasForeignKey(x => x.GameId);
    }
}