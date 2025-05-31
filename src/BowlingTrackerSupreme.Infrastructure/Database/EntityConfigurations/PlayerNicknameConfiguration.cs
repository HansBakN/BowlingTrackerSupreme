using BowlingTrackerSupreme.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BowlingTrackerSupreme.Infrastructure.Database.EntityConfigurations
{
    public class PlayerNicknameConfiguration : IEntityTypeConfiguration<PlayerNickname>
    {
        public void Configure(EntityTypeBuilder<PlayerNickname> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Player)
                .WithMany(x => x.Nicknames)
                .IsRequired();

            builder.Property(x => x.Nickname)
                .IsRequired();

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
}
