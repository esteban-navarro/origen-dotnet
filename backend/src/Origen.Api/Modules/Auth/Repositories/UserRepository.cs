using Microsoft.EntityFrameworkCore;
using Origen.Api.Data;
using Origen.Api.Modules.Auth.Entities;

namespace Origen.Api.Modules.Auth.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext _context;

    public UserRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    private IQueryable<User> UsersWithAuthorization()
    {
        return _context.Users
            .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                    .ThenInclude(r => r.RolePermissions)
                        .ThenInclude(rp => rp.Permission);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await UsersWithAuthorization()
            .FirstOrDefaultAsync(u =>
                u.Username.ToLower() == username.ToLower());
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u =>
                u.Email.ToLower() == email.ToLower());
    }

    public async Task<bool> ExistsByUsernameAsync(string username)
    {
        return await _context.Users
            .AnyAsync(u =>
                u.Username.ToLower() == username.ToLower());
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _context.Users
            .AnyAsync(u =>
                u.Email.ToLower() == email.ToLower());
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }
    public async Task<User> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }


    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);

        await _context.SaveChangesAsync();
    }
}