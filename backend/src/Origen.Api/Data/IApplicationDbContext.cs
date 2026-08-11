using Microsoft.EntityFrameworkCore;

using Origen.Api.Modules.Auth.Entities;

namespace Origen.Api.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }

    DbSet<Role> Roles { get; }

    DbSet<Permission> Permissions { get; }

    DbSet<UserRole> UserRoles { get; }

    DbSet<RolePermission> RolePermissions { get; }

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}