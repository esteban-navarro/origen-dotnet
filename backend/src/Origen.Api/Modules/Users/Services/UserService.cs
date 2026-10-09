using Origen.Api.Modules.Auth.Bootstrap;
using Origen.Api.Modules.Auth.Entities;
using Origen.Api.Modules.Auth.Repositories;
using Origen.Api.Modules.Auth.Security;
using Origen.Api.Modules.Users.DTO.Requests;
using Origen.Api.Modules.Users.DTO.Responses;

namespace Origen.Api.Modules.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    public UserService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IRoleRepository roleRepository,
        IUserRoleRepository userRoleRepository)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _roleRepository = roleRepository;
        _userRoleRepository = userRoleRepository;
    }

    public async Task<List<UserResponse>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        return users.Select(MapToResponse).ToList();
    }

    public async Task<UserResponse?> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        return user is null ? null : MapToResponse(user);
    }

    public async Task<UserResponse> CreateAsync(CreateUserRequest request)
    {
        var existingUsername =
            await _userRepository.FindByUsernameAsync(request.Username);

        if (existingUsername is not null)
        {
            throw new InvalidOperationException(
                "Username already exists.");
        }

        var existingEmail =
            await _userRepository.FindByEmailAsync(request.Email);

        if (existingEmail is not null)
        {
            throw new InvalidOperationException(
                "Email already exists.");
        }

        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = _passwordHasher.Hash(request.Password),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Enabled = request.Enabled
        };

        var createdUser = await _userRepository.CreateAsync(user);

        Role? defaultRole =
            await _roleRepository.FindByNameAsync(
                AuthorizationSeedData.UserRole);

        if (defaultRole is null)
        {
            throw new InvalidOperationException(
                "Default user role not found.");
        }

        UserRole userRole = new()
        {
            UserId = createdUser.Id,
            RoleId = defaultRole.Id
        };

        await _userRoleRepository.AddAsync(userRole);

        return MapToResponse(createdUser);
    }

    public async Task<UserResponse?> UpdateAsync(
        Guid id,
        UpdateUserRequest request)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user is null)
        {
            return null;
        }

        var existingUsername =
            await _userRepository.FindByUsernameAsync(request.Username);

        if (existingUsername is not null &&
            existingUsername.Id != id)
        {
            throw new InvalidOperationException(
                "Username already exists.");
        }

        var existingEmail =
            await _userRepository.FindByEmailAsync(request.Email);

        if (existingEmail is not null &&
            existingEmail.Id != id)
        {
            throw new InvalidOperationException(
                "Email already exists.");
        }

        user.Username = request.Username;
        user.Email = request.Email;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Enabled = request.Enabled;

        await _userRepository.UpdateAsync(user);

        return MapToResponse(user);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user is null)
        {
            return false;
        }

        await _userRepository.DeleteAsync(user);

        return true;
    }

    private static UserResponse MapToResponse(User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Enabled = user.Enabled,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }
}