using Microsoft.Extensions.Options;
using Origen.Api.Data;
using Origen.Api.Modules.Auth.Entities;
using Origen.Api.Modules.Auth.Repositories;
using Origen.Api.Modules.Auth.Security;

namespace Origen.Api.Modules.Auth.Bootstrap;

public class AdminUserInitializer
{
    private readonly AdminBootstrapOptions _options;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IApplicationDbContext _context;

    public AdminUserInitializer(
        IOptions<AdminBootstrapOptions> options,
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IUserRoleRepository userRoleRepository,
        IPasswordHasher passwordHasher,
        IApplicationDbContext context)
    {
        _options = options.Value;

        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _userRoleRepository = userRoleRepository;
        _passwordHasher = passwordHasher;
        _context = context;
    }

    public async Task InitializeAsync()
    {
        if (!_options.Enabled)
        {
            return;
        }

        if (_options.Admin is null)
        {
            throw new InvalidOperationException(
                "Bootstrap administrator configuration is missing.");
        }

        AdminOptions admin = _options.Admin;

        bool exists =
            await _userRepository.ExistsByUsernameAsync(
                admin.Username);

        if (exists)
        {
            return;
        }

        Role adminRole =
            await _roleRepository.FindByNameAsync(AuthorizationSeedData.AdminRole)
            ?? throw new InvalidOperationException(
                $"Role '{AuthorizationSeedData.AdminRole}' not found.");

        User user = new()
        {
            Username = admin.Username,
            Email = admin.Email,
            PasswordHash = _passwordHasher.Hash(admin.Password),
            FirstName = admin.FirstName,
            LastName = admin.LastName,
            Enabled = true
        };

        await _userRepository.AddAsync(user);

        UserRole userRole = new()
        {
            UserId = user.Id,
            RoleId = adminRole.Id
        };

        await _userRoleRepository.AddAsync(userRole);

        await _context.SaveChangesAsync();
    }
}