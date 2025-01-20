using BowlingTrackerSupreme.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BowlingTrackerSupreme.Infrastructure.Database.EntityConfigurations;

public class FrameConfiguration : IEntityTypeConfiguration<Frame>
{
    public void Configure(EntityTypeBuilder<Frame> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.FirstRoll)
            .WithOne(x => x.Frame)
            .HasForeignKey<Roll>(x => x.FrameId);
        builder.HasOne(x => x.SecondRoll)
            .WithOne(x => x.Frame)
            .HasForeignKey<Roll>(x => x.FrameId);
    }
}