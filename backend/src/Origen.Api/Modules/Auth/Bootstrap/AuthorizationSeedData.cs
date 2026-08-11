namespace Origen.Api.Modules.Auth.Bootstrap
{
    public static class AuthorizationSeedData
    {
        public const string AdminRole = "ADMIN";

        public const string UserRole = "USER";

        public const string UserReadPermission = "USER_READ";

        public const string UserCreatePermission = "USER_CREATE";

        public const string UserUpdatePermission = "USER_UPDATE";

        public const string UserDeletePermission = "USER_DELETE";

        public static readonly Guid AdminRoleId =
            Guid.Parse("11111111-1111-1111-1111-111111111111");

        public static readonly Guid UserRoleId =
            Guid.Parse("22222222-2222-2222-2222-222222222222");

        public static readonly Guid UserReadPermissionId =
            Guid.Parse("33333333-3333-3333-3333-333333333333");

        public static readonly Guid UserCreatePermissionId =
            Guid.Parse("44444444-4444-4444-4444-444444444444");

        public static readonly Guid UserUpdatePermissionId =
            Guid.Parse("55555555-5555-5555-5555-555555555555");

        public static readonly Guid UserDeletePermissionId =
            Guid.Parse("66666666-6666-6666-6666-666666666666");
    }    
}
