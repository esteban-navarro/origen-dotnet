using Origen.Api.Modules.Auth.DTOs;
using Origen.Api.Modules.Auth.Entities;
using Origen.Api.Modules.Auth.Repositories;
using Origen.Api.Modules.Auth.Security;

namespace Origen.Api.Modules.Auth.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;

    public AuthService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtService jwtService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        User? user =
            await _userRepository.FindByUsernameAsync(request.Username);

        if (user is null)
        {
            throw new UnauthorizedAccessException(
                "Invalid username or password.");
        }

        bool validPassword =
        _passwordHasher.Verify(
            request.Password,
            user.PasswordHash);

        if (!validPassword)
        {
            throw new UnauthorizedAccessException(
                "Invalid username or password.");
        }

        string accessToken =
            _jwtService.GenerateToken(user);

        throw new NotImplementedException();

    }
}