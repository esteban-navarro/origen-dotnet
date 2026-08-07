using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Origen.Api.Modules.Auth.Entities;

namespace Origen.Api.Modules.Auth.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnName("id");

        builder.Property(x => x.Username)
               .HasColumnName("username")
               .HasMaxLength(50)
               .IsRequired();

        builder.HasIndex(x => x.Username)
               .IsUnique();

        builder.Property(x => x.Email)
               .HasColumnName("email")
               .HasMaxLength(255)
               .IsRequired();

        builder.HasIndex(x => x.Email)
               .IsUnique();

        builder.Property(x => x.PasswordHash)
               .HasColumnName("password_hash")
               .HasMaxLength(255)
               .IsRequired();

        builder.Property(x => x.FirstName)
               .HasColumnName("first_name")
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(x => x.LastName)
               .HasColumnName("last_name")
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(x => x.Enabled)
               .HasColumnName("enabled")
               .IsRequired();

        builder.Property(x => x.CreatedAt)
               .HasColumnName("created_at")
               .IsRequired();

        builder.Property(x => x.UpdatedAt)
               .HasColumnName("updated_at")
               .IsRequired();
    }
}