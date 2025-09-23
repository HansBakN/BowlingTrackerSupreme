using BowlingTrackerSupreme.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BowlingTrackerSupreme.Infrastructure.Database.EntityConfigurations;

public class FrameConfiguration : IEntityTypeConfiguration<Frame>
{
    public void Configure(EntityTypeBuilder<Frame> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.GamePlayer)
            .WithMany(x => x.Frames)
            .HasForeignKey(x => x.GamePlayerId)
            .IsRequired();

        builder.Property(x => x.Index)
            .IsRequired();
    }
}