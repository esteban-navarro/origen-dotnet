using Microsoft.EntityFrameworkCore.Migrations;
using Origen.Api.Modules.Auth.Bootstrap;

#nullable disable

namespace Origen.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[]
                {
                    "id",
                    "name",
                    "description"
                },
                values: new object[,]
                {
                    {
                        AuthorizationSeedData.AdminRoleId,
                        AuthorizationSeedData.AdminRole,
                        "System administrator"
                    },
                    {
                        AuthorizationSeedData.UserRoleId,
                        AuthorizationSeedData.UserRole,
                        "Standard application user"
                    }
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[]
                {
                    "id",
                    "name",
                    "description"
                },
                values: new object[,]
                {
                    {
                        AuthorizationSeedData.UserReadPermissionId,
                        AuthorizationSeedData.UserReadPermission,
                        "Read users"
                    },
                    {
                        AuthorizationSeedData.UserCreatePermissionId,
                        AuthorizationSeedData.UserCreatePermission,
                        "Create users"
                    },
                    {
                        AuthorizationSeedData.UserUpdatePermissionId,
                        AuthorizationSeedData.UserUpdatePermission,
                        "Update users"
                    },
                    {
                        AuthorizationSeedData.UserDeletePermissionId,
                        AuthorizationSeedData.UserDeletePermission,
                        "Delete users"
                    }
                });

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[]
                {
                    "role_id",
                    "permission_id"
                },
                values: new object[,]
                {
                    {
                        AuthorizationSeedData.AdminRoleId,
                        AuthorizationSeedData.UserReadPermissionId
                    },
                    {
                        AuthorizationSeedData.AdminRoleId,
                        AuthorizationSeedData.UserCreatePermissionId
                    },
                    {
                        AuthorizationSeedData.AdminRoleId,
                        AuthorizationSeedData.UserUpdatePermissionId
                    },
                    {
                        AuthorizationSeedData.AdminRoleId,
                        AuthorizationSeedData.UserDeletePermissionId
                    },
                    {
                        AuthorizationSeedData.UserRoleId,
                        AuthorizationSeedData.UserReadPermissionId
                    }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "role_id", "permission_id" },
                keyValues: new object[]
                {
            AuthorizationSeedData.UserRoleId,
            AuthorizationSeedData.UserReadPermissionId
                });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "role_id", "permission_id" },
                keyValues: new object[]
                {
            AuthorizationSeedData.AdminRoleId,
            AuthorizationSeedData.UserReadPermissionId
                });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "role_id", "permission_id" },
                keyValues: new object[]
                {
            AuthorizationSeedData.AdminRoleId,
            AuthorizationSeedData.UserCreatePermissionId
                });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "role_id", "permission_id" },
                keyValues: new object[]
                {
            AuthorizationSeedData.AdminRoleId,
            AuthorizationSeedData.UserUpdatePermissionId
                });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "role_id", "permission_id" },
                keyValues: new object[]
                {
            AuthorizationSeedData.AdminRoleId,
            AuthorizationSeedData.UserDeletePermissionId
                });

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: AuthorizationSeedData.UserReadPermissionId);

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: AuthorizationSeedData.UserCreatePermissionId);

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: AuthorizationSeedData.UserUpdatePermissionId);

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: AuthorizationSeedData.UserDeletePermissionId);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: AuthorizationSeedData.AdminRoleId);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: AuthorizationSeedData.UserRoleId);
        }
    }
}
