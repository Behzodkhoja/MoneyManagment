using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MoneyManagment.Domain.Entities;
using MoneyManagment.Service.DTOs.Users;
using MoneyManagment.Service.Exceptions;
using MoneyManagment.Service.Interfaces;
using MoneyManagment.Shared.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoneyManagment.Service.Services;

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
        if (user == null || !PasswordHelper.Verify(password, user.Password))
            throw new MoneyManagmentException(400, "Email or password in correct");
        return new LoginResultDto
        {
            Token = GenerateToken(user)
        };
    }

    private string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        var tokenDescripter = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName)
            }),
            Audience = configuration["JWT:Audience"],
            Issuer = configuration["JWT:Issuer"],
            IssuedAt= DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(configuration["JWT:Expires"])),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescripter);
        return tokenHandler.WriteToken(token);
    }
}



