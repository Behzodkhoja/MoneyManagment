using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoneyManagment.DAL.IRepository;
using MoneyManagment.Domain.Configurations;
using MoneyManagment.Domain.Entities;
using MoneyManagment.Service.DTOs.Users;
using MoneyManagment.Service.Exceptions;
using MoneyManagment.Service.Extensions;
using MoneyManagment.Service.Interfaces;
using MoneyManagment.Shared.Helpers;

namespace MoneyManagment.Service.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> userRepository;
    private readonly IMapper mapper;

    public UserService(IRepository<User> userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<UserResultDto> AddAsync(UserCreationDto dto)
    {
        var user = await this.userRepository.SelectAsync(u => u.Email == dto.Email);
        if (user != null)
            throw new MoneyManagmentException(409, "User already exists!");

        var mappedUser = this.mapper.Map<User>(dto);
        mappedUser.CreatedAt = DateTime.UtcNow;
        mappedUser.Password = PasswordHelper.Hash(dto.Password);
        var addedUser = await this.userRepository.InsertAsync(mappedUser);

        await this.userRepository.SaveAsync();

        return this.mapper.Map<UserResultDto>(addedUser);
    }

    public async Task<UserResultDto> ModifyAsync(long id, UserUpdateDto dto)
    {
        var user = await this.userRepository.SelectAsync(u => u.Id == id);
        if (user == null)
            throw new MoneyManagmentException(404, "Not found!");

        var modifiedUser = this.mapper.Map(dto, user);
        modifiedUser.UpdatedAt = DateTime.UtcNow;

        await this.userRepository.SaveAsync();

        return this.mapper.Map<UserResultDto>(modifiedUser);
    }

    public async Task<UserResultDto> PasswordChangeAsync(UserChangePasswordDto dto)
    {
        var user = await this.userRepository.SelectAsync(u => u.Email == dto.Email);
        if (user == null)
            throw new MoneyManagmentException(404, "Not found!");

        if (!PasswordHelper.Verify(dto.OldPassword, user.Password))
            throw new MoneyManagmentException(400, "Password is incorect!");

        if (dto.NewPassword != dto.OldPassword)
            throw new MoneyManagmentException(400, "Old and new Passwords are not equal!");

        user.Password = PasswordHelper.Hash(dto.NewPassword);

        await this.userRepository.SaveAsync();

        return this.mapper.Map<UserResultDto>(user);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await this.userRepository.SelectAsync(u => u.Id == id);
        if (user == null)
            throw new MoneyManagmentException(404, "Not found!");

        user.DeletedBy = HttpContextHelper.UserId;
        await this.userRepository.DeleteAsync(u => u.Id == id);

        await this.userRepository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var users = await this.userRepository.SelectAllAsync(u => !u.IsDeleted)
            .ToPagedList(@params)
            .ToListAsync();

        return this.mapper.Map<IEnumerable<UserResultDto>>(users);
    }
    public async Task<User> RetrieveByEmailAsync(string email)=>
        await this.userRepository.SelectAsync(u=>u.Email == email);

    public async Task<UserResultDto> RetrieveByIdAsync(long id)
    {
        var user = await this.userRepository.SelectAsync(u => u.Id == id && !u.IsDeleted);
        if (user == null)
            throw new MoneyManagmentException(404, "Not found!");

        return this.mapper.Map<UserResultDto>(user);
    }
}
       
        
        



