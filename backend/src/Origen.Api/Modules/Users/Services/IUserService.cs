using Origen.Api.Modules.Users.DTO.Requests;
using Origen.Api.Modules.Users.DTO.Responses;

namespace Origen.Api.Modules.Users.Services;

public interface IUserService
{
    Task<List<UserResponse>> GetAllAsync();

    Task<UserResponse?> GetByIdAsync(Guid id);

    Task<UserResponse> CreateAsync(CreateUserRequest request);

    Task<UserResponse?> UpdateAsync(Guid id, UpdateUserRequest request);

    Task<bool> DeleteAsync(Guid id);
}