namespace Origen.Api.Modules.Auth.DTOs
{
    public sealed class LoginResponse
    {
        public string AccessToken { get; init; } = string.Empty;

        public string TokenType { get; init; } = "Bearer";

        public long ExpiresIn { get; init; }

        public AuthenticatedUserResponse User { get; init; } = null!;
    }
}
