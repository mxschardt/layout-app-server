using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Api.Models;

namespace Api.Data;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.UserName)
            .IsUnique();

        builder.Property(e => e.Name)
            .HasMaxLength(255);

        builder.Property(e => e.UserName)
           .HasMaxLength(255);

        builder.Property(e => e.Email)
            .HasMaxLength(255);

        builder.HasMany(u => u.Posts)
            .WithOne()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}