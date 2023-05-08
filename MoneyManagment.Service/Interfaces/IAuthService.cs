using MoneyManagment.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagment.Service.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResultDto> AuthenticateAsync(string email, string password);
    }
}
