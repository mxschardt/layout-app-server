using Api.Dto;
using Api.Models;
using AutoMapper;

namespace Api.Profiles;

public class PostProfiles : Profile
{
    public PostProfiles()
    {
        CreateMap<Post, PostReadDto>();
        CreateMap<PostCreateDto, Post>();
        CreateMap<PostUpdateDto, Post>();
    }
}