using MoneyManagment.Service.DTOs.Users;

namespace MoneyManagment.Service.Interfaces;

public interface IAuthService
{
    Task<LoginResultDto> AuthenticateAsync(string email, string password);
}

