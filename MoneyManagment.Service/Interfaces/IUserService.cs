using MoneyManagment.Domain.Configurations;
using MoneyManagment.Domain.Entities;
using MoneyManagment.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagment.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserResultDto> AddAsync(UserCreationDto dto);
        Task<UserResultDto> ModifyAsync(long id, UserUpdateDto dto);
        Task<UserResultDto> RemoveAsync();
        Task<UserResultDto> RetrieveByIdAsync(long id);
        Task<User> RetrieveByEmailAsync(string email);
        Task<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams @params);
        Task<UserResultDto> PasswordChangeAsync(UserChangePasswordDto dto);
    }
}
