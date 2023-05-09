using Microsoft.Extensions.Configuration;
using MoneyManagment.Service.DTOs.Users;
using MoneyManagment.Service.Interfaces;
using MoneyManagment.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagment.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService userService;
        private readonly IConfiguration configuration;

        public AuthService(IUserService userService, IConfiguration configuration)
        {
            this.userService = userService;
            this.configuration = configuration;
        }

        public async Task<LoginResultDto> AuthenticateAsync(string email, string password)
        {
            var user = await this.userService.RetrieveByEmailAsync(email);
            if(user == null || !PasswordHelper.Verify(password, user.Password))
        }
    }
}
