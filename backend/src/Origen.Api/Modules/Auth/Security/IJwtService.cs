using Origen.Api.Modules.Auth.Entities;
using System.Security.Claims;

namespace Origen.Api.Modules.Auth.Security;

public interface IJwtService
{
    string GenerateToken(User user);

    string? ExtractUsername(string token);

    T ExtractClaim<T>(
        string token,
        Func<ClaimsPrincipal, T> resolver);

    ClaimsPrincipal GetPrincipal(string token);

    bool IsTokenValid(
        string token,
        User user);

    long GetExpirationInSeconds();
}