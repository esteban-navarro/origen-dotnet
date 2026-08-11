using Origen.Api.Data;
using Origen.Api.Modules.Auth.Entities;

namespace Origen.Api.Modules.Auth.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly IApplicationDbContext _context;

    public UserRoleRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(UserRole userRole)
    {
        await _context.UserRoles.AddAsync(userRole);

        await _context.SaveChangesAsync();
    }
}