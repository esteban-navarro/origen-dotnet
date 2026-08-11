using Microsoft.EntityFrameworkCore;

using Origen.Api.Data;
using Origen.Api.Modules.Auth.Entities;

namespace Origen.Api.Modules.Auth.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly IApplicationDbContext _context;

    public RoleRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Role?> FindByNameAsync(string name)
    {
        return await _context.Roles
            .FirstOrDefaultAsync(role => role.Name == name);
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Roles
            .AnyAsync(role => role.Name == name);
    }
}