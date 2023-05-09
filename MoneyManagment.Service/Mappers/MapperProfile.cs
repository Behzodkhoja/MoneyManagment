using AutoMapper;
using MoneyManagment.Domain.Entities;
using MoneyManagment.Service.DTOs.Exposes;
using MoneyManagment.Service.DTOs.Users;

namespace MoneyManagment.Service.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile() 
    {
        CreateMap<User, UserCreationDto>().ReverseMap();
        CreateMap<User, UserResultDto>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();

        CreateMap<Expose, ExposeCreationDto>().ReverseMap();
        CreateMap<Expose, ExposeResultDto>().ReverseMap();
    }

}
