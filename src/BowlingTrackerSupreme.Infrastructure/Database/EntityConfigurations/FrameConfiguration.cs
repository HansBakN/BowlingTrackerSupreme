using BowlingTrackerSupreme.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BowlingTrackerSupreme.Infrastructure.Database.EntityConfigurations;

public class FrameConfiguration : IEntityTypeConfiguration<Frame>
{
    public void Configure(EntityTypeBuilder<Frame> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(f => f.CreatedOn)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("timezone('utc', now())");
        builder.Property(f => f.ModifiedOn)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("timezone('utc', now())");
        builder.OwnsOne(x => x.FirstRoll);
        builder.OwnsOne(x => x.SecondRoll);
        builder.Ignore(x => x.AllRolls);
    }
}