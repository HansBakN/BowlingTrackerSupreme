using BowlingTrackerSupreme.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BowlingTrackerSupreme.Infrastructure.Database.EntityConfigurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(g => g.CreatedOn)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();
        
        builder.Property(g => g.ModifiedOn)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();
    }
}