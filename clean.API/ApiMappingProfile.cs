using AutoMapper;
using clean.API.Models;
using clean.Core.Entities;
using clean.Core.Models;

namespace clean.API
{
    public class ApiMappingProfile:Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<TaskItem, TaskPostModel>().ReverseMap();
            CreateMap<User, UserPostModel>().ReverseMap();
            CreateMap<UserProfile, UserProfilePostModel>().ReverseMap();
            CreateMap<Category, CategoryPostModel>().ReverseMap();
        }            
    }
}
