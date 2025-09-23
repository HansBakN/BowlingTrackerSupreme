using BowlingTrackerSupreme.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BowlingTrackerSupreme.Infrastructure.Database.EntityConfigurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.CreatedOn)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();
        
        builder.Property(p => p.ModifiedOn)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();
    }
}