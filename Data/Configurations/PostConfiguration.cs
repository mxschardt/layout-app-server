using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Api.Models;

namespace Api.Data;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.Title);

        builder.Property(e => e.Title)
            .HasConversion<string>()
            .HasMaxLength(255);

    }
}