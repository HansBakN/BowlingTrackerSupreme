using BowlingTrackerSupreme.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BowlingTrackerSupreme.Infrastructure.Database.EntityConfigurations;

public class FinalFrameConfiguration : IEntityTypeConfiguration<FinalFrame>
{
    public void Configure(EntityTypeBuilder<FinalFrame> builder)
    {
        builder.OwnsOne(x => x.ThirdRoll);
    }
}