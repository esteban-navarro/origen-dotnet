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
        DateTime issuedAt = DateTime.UtcNow;
        DateTime expires = issuedAt.AddMinutes(_options.ExpirationMinutes);

        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Sub, user.Username),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        ];

        claims.AddRange(
            user.UserRoles
                .Select(ur => new Claim(
                    ClaimTypes.Role,
                    ur.Role.Name))
                .DistinctBy(c => c.Value));

        claims.AddRange(
            user.UserRoles
                .SelectMany(ur => ur.Role.RolePermissions)
                .Select(rp => new Claim(
                    "permission",
                    rp.Permission.Name))
                .DistinctBy(c => c.Value));

        JwtSecurityToken token = new(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            notBefore: issuedAt,
            expires: expires,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_options.Secret)),
                SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }

    public string? ExtractUsername(string token)
    {
        return ExtractClaim(
            token,
            principal => principal.FindFirstValue(
                JwtRegisteredClaimNames.Sub));
    }

    public T ExtractClaim<T>(
        string token,
        Func<ClaimsPrincipal, T> resolver)
    {
        ClaimsPrincipal principal = GetPrincipal(token);
        return resolver(principal);
    }

    public ClaimsPrincipal GetPrincipal(string token)
    {
        JwtSecurityTokenHandler handler = new();

        TokenValidationParameters validationParameters = new()
        {
            ValidateIssuer = true,
            ValidIssuer = _options.Issuer,

            ValidateAudience = true,
            ValidAudience = _options.Audience,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.Secret)),

            ValidateLifetime = true,

            ClockSkew = TimeSpan.Zero
        };

        return handler.ValidateToken(
            token,
            validationParameters,
            out _);
    }

    public bool IsTokenValid(
        string token,
        User user)
    {
        try
        {
            string? username = ExtractUsername(token);
            return username == user.Username;
        }
        catch
        {
            return false;
        }
    }

    public long GetExpirationInSeconds()
    {
        return (long)TimeSpan
            .FromMinutes(_options.ExpirationMinutes)
            .TotalSeconds;
    }

}