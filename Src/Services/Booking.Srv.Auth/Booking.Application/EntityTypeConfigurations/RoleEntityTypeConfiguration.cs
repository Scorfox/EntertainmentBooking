using Booking.Auth.Srv.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Application.EntityTypeConfigurations;

public class RoleTypeConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasIndex(i => i.Name)
            .IsUnique();

        builder.HasMany<User>()
            .WithOne(user => user.Role)
            .HasForeignKey(e => e.RoleId);
    }
}