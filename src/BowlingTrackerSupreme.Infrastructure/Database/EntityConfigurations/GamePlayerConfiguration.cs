using BowlingTrackerSupreme.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BowlingTrackerSupreme.Infrastructure.Database.EntityConfigurations;

public class GamePlayerConfiguration : IEntityTypeConfiguration<GamePlayer> 
{
    public void Configure(EntityTypeBuilder<GamePlayer> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.PlayerNickname)
            .WithMany(x => x.GamePlayers)
            .HasForeignKey(x => x.PlayerNicknameId);
        
        builder.HasOne(x => x.Game)
            .WithMany(x => x.Players)
            .HasForeignKey(x => x.GameId)
            .IsRequired();
        
        builder.HasOne(x => x.Player)
            .WithMany(x => x.GameParticipations)
            .HasForeignKey(x => x.PlayerId)
            .IsRequired();
    }
}