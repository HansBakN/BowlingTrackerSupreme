using BowlingTrackerSupreme.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BowlingTrackerSupreme.Infrastructure.Database.EntityConfigurations;

public class FrameConfiguration : IEntityTypeConfiguration<Frame>
{
    public void Configure(EntityTypeBuilder<Frame> builder)
    {
        builder.HasKey(x => x.Id);
        builder.OwnsOne(x => x.FirstRoll);
        builder.OwnsOne(x => x.SecondRoll);
        builder.Ignore(x => x.AllRolls);
    }
}