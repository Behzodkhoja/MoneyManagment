using MoneyManagment.Domain.Configurations;
using MoneyManagment.Domain.Entities;
using MoneyManagment.Service.DTOs.Users;

namespace MoneyManagment.Service.Interfaces;

public interface IUserService
{
    Task<UserResultDto> AddAsync(UserCreationDto dto);
    Task<UserResultDto> ModifyAsync(int id, UserUpdateDto dto);
    Task<bool> RemoveAsync(int id );
    Task<UserResultDto> RetrieveByIdAsync(int id);
    Task<User> RetrieveByEmailAsync(string email);
    Task<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<UserResultDto> PasswordChangeAsync(UserChangePasswordDto dto);
}
