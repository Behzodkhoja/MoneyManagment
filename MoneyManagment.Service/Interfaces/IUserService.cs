using MoneyManagment.Domain.Configurations;
using MoneyManagment.Domain.Entities;
using MoneyManagment.Service.DTOs.Users;

namespace MoneyManagment.Service.Interfaces;

public interface IUserService
{
    Task<UserResultDto> AddAsync(UserCreationDto dto);
    Task<UserResultDto> ModifyAsync(long id, UserUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<UserResultDto> RetrieveByIdAsync(long id);
    Task<User> RetrieveByEmailAsync(string email);
    Task<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<UserResultDto> PasswordChangeAsync(UserChangePasswordDto dto);
}
