using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Origen.Api.Modules.Auth.Entities;

namespace Origen.Api.Modules.Auth.Security;

public class JwtService : IJwtService
{
    private readonly JwtOptions _options;

    public JwtService(
        IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string GenerateToken(User user)
    {
        throw new NotImplementedException();
    }

    public string? ExtractUsername(string token)
    {
        throw new NotImplementedException();
    }

    public T ExtractClaim<T>(
        string token,
        Func<ClaimsPrincipal, T> resolver)
    {
        throw new NotImplementedException();
    }

    public ClaimsPrincipal GetPrincipal(string token)
    {
        throw new NotImplementedException();
    }

    public bool IsTokenValid(
        string token,
        User user)
    {
        throw new NotImplementedException();
    }
}