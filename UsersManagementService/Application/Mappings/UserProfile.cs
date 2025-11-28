using AutoMapper;
using InnoShop.UsersManagementService.Application.Dtos.Requests;
using InnoShop.UsersManagementService.Application.Dtos.Responses;
using InnoShop.UsersManagementService.Domain.Entities;

namespace InnoShop.UsersManagementService.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>()
            .ForMember(dest => dest.Username,
                opt => opt.Condition(src => src.Username is not null))
            .ForMember(dest => dest.Email,
                opt => opt.Condition(src => src.Email is not null))
            .ForMember(dest => dest.Role,
                opt => opt.Condition(src => src.Role.HasValue));
    }
}
