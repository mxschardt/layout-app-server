using Api.Dto;
using Api.Models;
using AutoMapper;

namespace Api.Profiles;

public class UserProfiles : Profile
{
    public UserProfiles()
    {
        CreateMap<User, UserReadDto>();
        CreateMap<UserCreateDto, User>();
    }
}