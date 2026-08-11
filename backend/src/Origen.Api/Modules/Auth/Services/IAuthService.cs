using Origen.Api.Modules.Auth.DTOs;

namespace Origen.Api.Modules.Auth.Services;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
}