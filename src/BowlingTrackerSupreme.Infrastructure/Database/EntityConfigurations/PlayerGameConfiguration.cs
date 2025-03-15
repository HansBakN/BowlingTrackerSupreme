using BowlingTrackerSupreme.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BowlingTrackerSupreme.Infrastructure.Database.EntityConfigurations;

public class PlayerGameConfiguration : IEntityTypeConfiguration<PlayerGame> 
{
    public void Configure(EntityTypeBuilder<PlayerGame> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(p => p.CreatedOn)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("timezone('utc', now())");
        builder.Property(p => p.ModifiedOn)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("timezone('utc', now())");
        builder.HasMany(x => x.Frames)
            .WithOne(x => x.PlayerGame)
            .HasForeignKey(x => x.PlayerGameId);
    }
}